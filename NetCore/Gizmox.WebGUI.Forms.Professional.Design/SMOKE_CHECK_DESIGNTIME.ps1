$ErrorActionPreference = "Stop"

$root = "C:\Projects\VWG"
$project = Join-Path $root "NetCore\Gizmox.WebGUI.Forms.Professional.Design\Gizmox.WebGUI.Forms.Professional.Design.csproj"

# Ensure binaries are fresh for smoke validation.
$null = dotnet build $project -c Debug -v minimal

$outputDir = Join-Path $root "NetCore\Gizmox.WebGUI.Forms.Professional.Design\bin\Debug\net8.0-windows"
if (-not (Test-Path $outputDir)) {
    throw "Missing smoke-check output directory: $outputDir"
}

Get-ChildItem $outputDir -Filter "*.dll" | ForEach-Object {
    [void][System.Reflection.Assembly]::LoadFrom($_.FullName)
}

$results = New-Object System.Collections.Generic.List[object]

function Add-CheckResult {
    param(
        [string]$Check,
        [bool]$Pass,
        [string]$Detail
    )

    $results.Add([pscustomobject]@{
        Check = $Check
        Result = if ($Pass) { "PASS" } else { "FAIL" }
        Detail = $Detail
    })
}

function Get-SingleAttributeArgument {
    param(
        [Type]$DeclaringType,
        [string]$PropertyName,
        [string]$AttributeTypeFullName
    )

    $property = $DeclaringType.GetProperty($PropertyName)
    if ($null -eq $property) {
        throw "Property '$PropertyName' was not found on $($DeclaringType.FullName)"
    }

    $attribute = $property.GetCustomAttributesData() |
        Where-Object { $_.AttributeType.FullName -eq $AttributeTypeFullName } |
        Select-Object -First 1

    if ($null -eq $attribute) {
        throw "$AttributeTypeFullName was not found on $($DeclaringType.FullName).$PropertyName"
    }

    return [string]$attribute.ConstructorArguments[0].Value
}

function Get-TypeAttributeArgument {
    param(
        [Type]$DeclaringType,
        [string]$AttributeTypeFullName
    )

    $attribute = $DeclaringType.GetCustomAttributesData() |
        Where-Object { $_.AttributeType.FullName -eq $AttributeTypeFullName } |
        Select-Object -First 1

    if ($null -eq $attribute) {
        throw "$AttributeTypeFullName was not found on $($DeclaringType.FullName)"
    }

    return [string]$attribute.ConstructorArguments[0].Value
}

function Invoke-NonPublicInstanceMethod {
    param(
        [object]$Instance,
        [string]$MethodName,
        [object[]]$Arguments
    )

    $method = $Instance.GetType().GetMethod($MethodName, [System.Reflection.BindingFlags]"Instance, NonPublic")
    if ($null -eq $method) {
        throw "Method '$MethodName' was not found on $($Instance.GetType().FullName)"
    }

    return $method.Invoke($Instance, $Arguments)
}

# Check 1: GoogleMap.MapOverlays points to the migrated Professional.Design editor and resolves.
try {
    $editorTypeName = Get-SingleAttributeArgument -DeclaringType ([Gizmox.WebGUI.Forms.Professional.GoogleMap]) -PropertyName "MapOverlays" -AttributeTypeFullName "System.ComponentModel.EditorAttribute"
    $resolvedType = [Type]::GetType($editorTypeName, $false)
    $pass = ($editorTypeName -eq "Gizmox.WebGUI.Forms.Google.GoogleOverlayCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design") -and ($null -ne $resolvedType)
    Add-CheckResult -Check "GoogleMap.MapOverlays editor" -Pass $pass -Detail "$editorTypeName => $($resolvedType.FullName)"
}
catch {
    Add-CheckResult -Check "GoogleMap.MapOverlays editor" -Pass $false -Detail $_.Exception.Message
}

# Check 2: GoogleMap.MapLayers points to the migrated Professional.Design editor and resolves.
try {
    $editorTypeName = Get-SingleAttributeArgument -DeclaringType ([Gizmox.WebGUI.Forms.Professional.GoogleMap]) -PropertyName "MapLayers" -AttributeTypeFullName "System.ComponentModel.EditorAttribute"
    $resolvedType = [Type]::GetType($editorTypeName, $false)
    $pass = ($editorTypeName -eq "Gizmox.WebGUI.Forms.Google.GoogleLayerCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design") -and ($null -ne $resolvedType)
    Add-CheckResult -Check "GoogleMap.MapLayers editor" -Pass $pass -Detail "$editorTypeName => $($resolvedType.FullName)"
}
catch {
    Add-CheckResult -Check "GoogleMap.MapLayers editor" -Pass $false -Detail $_.Exception.Message
}

# Check 3: GoogleMapHeatMapLayer.DataPoints points to the migrated Professional.Design editor and resolves.
try {
    $editorTypeName = Get-SingleAttributeArgument -DeclaringType ([Gizmox.WebGUI.Forms.Google.GoogleMapHeatMapLayer]) -PropertyName "DataPoints" -AttributeTypeFullName "System.ComponentModel.EditorAttribute"
    $resolvedType = [Type]::GetType($editorTypeName, $false)
    $pass = ($editorTypeName -eq "Gizmox.WebGUI.Forms.Google.GoogleLocationCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design") -and ($null -ne $resolvedType)
    Add-CheckResult -Check "GoogleMapHeatMapLayer.DataPoints editor" -Pass $pass -Detail "$editorTypeName => $($resolvedType.FullName)"
}
catch {
    Add-CheckResult -Check "GoogleMapHeatMapLayer.DataPoints editor" -Pass $false -Detail $_.Exception.Message
}

# Check 4: Overlay editor instantiates and returns the expected display text.
try {
    $editor = [Gizmox.WebGUI.Forms.Google.GoogleOverlayCollectionEditor]::new()
    $value = [Gizmox.WebGUI.Forms.Google.GoogleMapMarkerOverlay]::new()
    $displayText = [string](Invoke-NonPublicInstanceMethod -Instance $editor -MethodName "GetDisplayText" -Arguments @($value))
    $pass = $displayText -eq "GoogleMapMarkerOverlay"
    Add-CheckResult -Check "Overlay editor display text" -Pass $pass -Detail $displayText
}
catch {
    Add-CheckResult -Check "Overlay editor display text" -Pass $false -Detail $_.Exception.ToString()
}

# Check 5: Layer editor instantiates and returns the expected display text.
try {
    $editor = [Gizmox.WebGUI.Forms.Google.GoogleLayerCollectionEditor]::new()
    $value = [Gizmox.WebGUI.Forms.Google.GoogleMapTrafficLayer]::new()
    $displayText = [string](Invoke-NonPublicInstanceMethod -Instance $editor -MethodName "GetDisplayText" -Arguments @($value))
    $pass = $displayText -eq "TrafficLayer"
    Add-CheckResult -Check "Layer editor display text" -Pass $pass -Detail $displayText
}
catch {
    Add-CheckResult -Check "Layer editor display text" -Pass $false -Detail $_.Exception.ToString()
}

# Check 6: StackPanel points to the migrated Professional.Design controller and resolves.
try {
    $controllerTypeName = Get-TypeAttributeArgument -DeclaringType ([Gizmox.WebGUI.Forms.StackPanel]) -AttributeTypeFullName "Gizmox.WebGUI.Forms.Design.DesignTimeControllerAttribute"
    $resolvedType = [Type]::GetType($controllerTypeName, $false)
    $pass = ($controllerTypeName -eq "Gizmox.WebGUI.Forms.Professional.Design.Controllers.StackPanelController, Gizmox.WebGUI.Forms.Professional.Design") -and ($null -ne $resolvedType)
    Add-CheckResult -Check "StackPanel design-time controller" -Pass $pass -Detail "$controllerTypeName => $($resolvedType.FullName)"
}
catch {
    Add-CheckResult -Check "StackPanel design-time controller" -Pass $false -Detail $_.Exception.Message
}

# Check 7: The migrated StackPanel controller preserves the expected constructor surface.
try {
    $controllerType = [Type]::GetType("Gizmox.WebGUI.Forms.Professional.Design.Controllers.StackPanelController, Gizmox.WebGUI.Forms.Professional.Design", $true)
    $ctorSignatures = $controllerType.GetConstructors() | ForEach-Object {
        ($_.GetParameters() | ForEach-Object { $_.ParameterType.FullName }) -join ", "
    }

    $expected = @(
        "Gizmox.WebGUI.Common.Interfaces.IContext, System.Object, System.Object",
        "Gizmox.WebGUI.Common.Interfaces.IContext, System.Object"
    )

    $missing = $expected | Where-Object { $_ -notin $ctorSignatures }
    $pass = ($missing.Count -eq 0) -and ($controllerType.BaseType.FullName -eq "Gizmox.WebGUI.Client.Controllers.StackPanelController")
    Add-CheckResult -Check "StackPanel controller surface" -Pass $pass -Detail (($ctorSignatures + "BaseType=$($controllerType.BaseType.FullName)") -join " | ")
}
catch {
    Add-CheckResult -Check "StackPanel controller surface" -Pass $false -Detail $_.Exception.ToString()
}

$results | Format-Table -AutoSize

if ($results.Result -contains "FAIL") {
    throw "Focused design-time smoke check failed."
}

Write-Host "Focused design-time smoke check passed."