$ErrorActionPreference = "Stop"

$root = "C:\Projects\VWG"
$project = Join-Path $root "NetCore\Gizmox.WebGUI.Forms.Office.Design\Gizmox.WebGUI.Forms.Office.Design.csproj"

# Ensure binaries are fresh for smoke validation.
$null = dotnet build $project -c Debug -v minimal

$outOfficeDesign = Join-Path $root "NetCore\Gizmox.WebGUI.Forms.Office.Design\bin\Debug\net8.0-windows\Gizmox.WebGUI.Forms.Office.Design.dll"
$outOffice = Join-Path $root "NetCore\Gizmox.WebGUI.Forms.Office\bin\Debug\net8.0-windows\Gizmox.WebGUI.Forms.Office.dll"
$outForms = Join-Path $root "NetCore\Gizmox.WebGUI.Forms\bin\Debug\net8.0-windows\Gizmox.WebGUI.Forms.dll"
$outCommon = Join-Path $root "NetCore\Gizmox.WebGUI.Common\bin\Debug\net8.0-windows\Gizmox.WebGUI.Common.dll"
$outClient = Join-Path $root "NetCore\Gizmox.WebGUI.Client\bin\Debug\net8.0-windows\Gizmox.WebGUI.Client.dll"

$assemblies = @($outCommon, $outForms, $outClient, $outOffice, $outOfficeDesign)
foreach ($asmPath in $assemblies) {
    if (-not (Test-Path $asmPath)) {
        throw "Missing assembly for smoke check: $asmPath"
    }
    [void][System.Reflection.Assembly]::LoadFrom($asmPath)
}

$stubCode = @"
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

public sealed class SmokeEditorService : IWindowsFormsEditorService
{
    public Control LastControl { get; private set; }

    public void DropDownControl(Control control)
    {
        LastControl = control;
        if (control is ListBox lb && lb.Items.Count > 1)
        {
            lb.SelectedIndex = 1;
        }
    }

    public void CloseDropDown() { }

    public DialogResult ShowDialog(Form dialog)
    {
        return DialogResult.OK;
    }
}

public sealed class SmokeProvider : IServiceProvider
{
    private readonly object _service;

    public SmokeProvider(object service)
    {
        _service = service;
    }

    public object GetService(Type serviceType)
    {
        return serviceType == typeof(IWindowsFormsEditorService) ? _service : null;
    }
}

public sealed class SmokeContext : ITypeDescriptorContext
{
    public object Instance { get; set; }
    public IContainer Container { get; set; }
    public PropertyDescriptor PropertyDescriptor => null;

    public object GetService(Type serviceType)
    {
        return null;
    }

    public bool OnComponentChanging()
    {
        return true;
    }

    public void OnComponentChanged() { }
}
"@

Add-Type -TypeDefinition $stubCode -ReferencedAssemblies @(
    "System.Runtime.dll",
    "System.dll",
    "System.ComponentModel.dll",
    "System.ComponentModel.Primitives.dll",
    "System.ComponentModel.TypeConverter.dll",
    "System.Windows.Forms.dll"
)

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

# Check 1: Office.Design editor type loads.
try {
    $editorType = [Type]::GetType("Gizmox.WebGUI.Forms.Office.Design.Editors.RibbonBarPageContextualTabGroupEditor, Gizmox.WebGUI.Forms.Office.Design", $true)
    Add-CheckResult -Check "Editor type load" -Pass $true -Detail $editorType.FullName
}
catch {
    Add-CheckResult -Check "Editor type load" -Pass $false -Detail $_.Exception.Message
}

# Check 2: RibbonBarPage.ContextualTabGroup points to Office.Design editor.
try {
    $prop = [Gizmox.WebGUI.Forms.RibbonBarPage].GetProperty("ContextualTabGroup")
    $editorAttribute = $prop.GetCustomAttributesData() |
        Where-Object { $_.AttributeType.FullName -eq "System.ComponentModel.EditorAttribute" } |
        Select-Object -First 1

    if ($null -eq $editorAttribute) {
        throw "EditorAttribute was not found on RibbonBarPage.ContextualTabGroup"
    }

    $editorTypeNameArg = [string]$editorAttribute.ConstructorArguments[0].Value
    $pass = $editorTypeNameArg -like "Gizmox.WebGUI.Forms.Office.Design.Editors.RibbonBarPageContextualTabGroupEditor*"
    Add-CheckResult -Check "RibbonBarPage editor attribute" -Pass $pass -Detail $editorTypeNameArg
}
catch {
    Add-CheckResult -Check "RibbonBarPage editor attribute" -Pass $false -Detail $_.Exception.Message
}

# Check 3: Invoke editor EditValue with fake design-time context/service.
try {
    $ribbon = [Gizmox.WebGUI.Forms.RibbonBar]::new()
    $page = [Gizmox.WebGUI.Forms.RibbonBarPage]::new("Smoke")
    [void]$ribbon.Pages.Add($page)

    $group = [Gizmox.WebGUI.Forms.ContextualTabGroup]::new("SmokeGroup")
    [void]$ribbon.ContextualTabGroups.Add($group)

    $context = [SmokeContext]::new()
    $context.Instance = $page
    $context.Container = [System.ComponentModel.Container]::new()

    $service = [SmokeEditorService]::new()
    $provider = [SmokeProvider]::new($service)
    $editor = [Gizmox.WebGUI.Forms.Office.Design.Editors.RibbonBarPageContextualTabGroupEditor]::new()

    $result = $editor.EditValue($context, $provider, $null)
    $pass = ($result -is [Gizmox.WebGUI.Forms.ContextualTabGroup]) -and ($result.Text -eq "SmokeGroup")

    $detail = if ($null -eq $result) {
        "Returned null"
    }
    else {
        "Returned type=$($result.GetType().FullName), text=$($result.Text)"
    }

    Add-CheckResult -Check "Editor EditValue flow" -Pass $pass -Detail $detail
}
catch {
    Add-CheckResult -Check "Editor EditValue flow" -Pass $false -Detail $_.Exception.ToString()
}

$results | Format-Table -AutoSize

if ($results.Result -contains "FAIL") {
    throw "Focused design-time smoke check failed."
}

Write-Host "Focused design-time smoke check passed."
