using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated";
        if (!Directory.Exists(baseDir))
        {
            Console.WriteLine("Directory not found: " + baseDir);
            return;
        }

        var files = Directory.GetFiles(baseDir, "*.cs", SearchOption.AllDirectories);
        Console.WriteLine($"Patching {files.Length} files...");

        int patchedCount = 0;

        foreach (var file in files)
        {
            string content = File.ReadAllText(file);
            string originalContent = content;

            // 1. Fix ITimer ambiguity in Gizmox.WebGUI.Forms namespace files
            if (content.Contains("ITimer") && content.Contains("namespace Gizmox.WebGUI.Forms"))
            {
                if (!content.Contains("using ITimer = Gizmox.WebGUI.Common.Interfaces.ITimer;"))
                {
                    content = content.Replace(
                        "using Gizmox.WebGUI.Common.Interfaces;",
                        "using Gizmox.WebGUI.Common.Interfaces;\nusing ITimer = Gizmox.WebGUI.Common.Interfaces.ITimer;");
                }
            }

            // 2. Fix CS0273/CS0507: "protected internal get" on a "protected override" property 
            //    The accessor must be MORE restrictive than the property itself.
            //    We strip the redundant "protected internal" from the getter to make it just "get"
            content = Regex.Replace(
                content,
                @"(protected override \w+ \w+\s*\{)\s*\r?\n\s*protected internal get",
                "$1\r\n\t\t\tget");

            // 3. Fix CS0308: ILSpy artifact - field references written as fieldName<TypeArg>
            //    e.g. mobjSingleCallMethodStore<AccelerometerEventArgs> = ...
            //    --> mobjSingleCallMethodStore = ...
            //    Pattern: an identifier followed by a single-level generic-argument in a statement context
            //    (not in a type declaration or new expression). We identify them by looking for:
            //      - identifier<TypeIdent> =  (assignment)
            //      - identifier<TypeIdent> ==  (comparison)
            //      - if (identifier<TypeIdent> (conditional)
            //    Strip the <TypeIdent> from the field access (not from type declarations or new expressions)
            content = Regex.Replace(
                content,
                @"\b(mobj\w+)<[A-Za-z][A-Za-z0-9]*>(\s*(==|!=|=(?!=)))",
                "$1$2"
            );
            content = Regex.Replace(
                content,
                @"\b(mobj\w+)<[A-Za-z][A-Za-z0-9]*>(\s*\))",
                "$1$2"
            );

            // 4. Fix CS0507: FireEvent access modifier -- must be protected (base is protected)
            //    Already handled by splitter but catch any remaining:
            content = content.Replace(
                "public override void FireEvent(IEvent",
                "protected override void FireEvent(IEvent");

            // 5. Fix CS0528: IEnumerable listed twice in interface list
            //    Remove a duplicate ", IEnumerable" if it already has IEnumerable listed
            content = Regex.Replace(
                content,
                @"(interface \w+ : [^{]*), IEnumerable\b([^<][^{]*), IEnumerable\b",
                "$1$2"
            );

            if (content != originalContent)
            {
                File.WriteAllText(file, content);
                patchedCount++;
            }
        }

        Console.WriteLine($"General patches applied to {patchedCount} files.");

        // Now do specific targeted fixes:
        
        // Fix ZoneDescriptor.cs - CloneWithoutReferences missing generic type param
        FixZoneDescriptor();
        
        // Fix ProxyTabControl.cs - GetProxyPropertyValue needs <T> (already has it; verify)
        FixProxyTabControl();
        
        // Fix ObjectBox.cs - Collection without generic arg
        FixObjectBox();

        // Fix Device integration components - Store type args, Action<> signatures
        FixDeviceComponents();

        // Fix remaining bare generic usages across all files
        FixBareGenerics(baseDir);

        // Fix ToolStripItem IArrangedElement CS0737
        FixToolStripItem();

        // Fix AdministrationContent Comparer
        FixAdministrationContentSorter();

        Console.WriteLine("All patches complete.");
    }

    static void FixZoneDescriptor()
    {
        string path = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated\Gizmox\WebGUI\Forms\ZoneDescriptor.cs";
        if (!File.Exists(path)) return;
        
        string content = File.ReadAllText(path);
        string original = content;
        
        // CS0115: 'ZoneDescriptor.CloneWithoutReferences<T>()': no suitable method found to override
        // The base class DockedObjectDescriptor must declare this as a generic method.
        // In ZoneDescriptor the method appears as:
        //   internal override T CloneWithoutReferences()
        // It needs to be:
        //   internal override T CloneWithoutReferences<T>()
        content = content.Replace(
            "internal override T CloneWithoutReferences()",
            "internal override T CloneWithoutReferences<T>()");
        
        if (content != original)
        {
            File.WriteAllText(path, content);
            Console.WriteLine("Fixed ZoneDescriptor.cs.");
        }
    }

    static void FixProxyTabControl()
    {
        string path = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated\Gizmox\WebGUI\Forms\ProxyTabControl.cs";
        if (!File.Exists(path)) return;
        
        string content = File.ReadAllText(path);
        string original = content;
        
        // If GetProxyPropertyValue lacks <T>, add it:
        content = Regex.Replace(content,
            @"public override T GetProxyPropertyValue\(string",
            "public override T GetProxyPropertyValue<T>(string");
        
        if (content != original)
        {
            File.WriteAllText(path, content);
            Console.WriteLine("Fixed ProxyTabControl.cs.");
        }
    }

    static void FixObjectBox()
    {
        string path = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated\Gizmox\WebGUI\Forms\Hosts\ObjectBox.cs";
        if (!File.Exists(path)) return;
        
        string content = File.ReadAllText(path);
        string original = content;
        
        content = Regex.Replace(content, @": Collection([^<])", ": Collection<object>$1");
        content = Regex.Replace(content, @"new Collection\(\)", "new Collection<object>()");
        
        if (content != original)
        {
            File.WriteAllText(path, content);
            Console.WriteLine("Fixed ObjectBox.cs.");
        }
    }

    static void FixBareGenerics(string baseDir)
    {
        int count = 0;
        foreach (var file in Directory.GetFiles(baseDir, "*.cs", SearchOption.AllDirectories))
        {
            string content = File.ReadAllText(file);
            string original = content;

            // CS0305: Using generic type 'List<T>' requires 1 type argument
            // Fix bare "new List()" -> "new List<object>()"
            content = Regex.Replace(content, @"new List\(\)", "new List<object>()");
            // Fix bare "List " as local variable type in declarations - but only in method/property bodies
            // Target pattern: (^\s+)(List )(\w+\s*=) or (List )(\w+\s*;) -- local variable declarations
            content = Regex.Replace(content, @"(\s)List (\w+\s*=\s*new List)", "$1List<object> $2<object>");
            content = Regex.Replace(content, @"(\s)List (\w+\s*;)", "$1List<object> $2");

            // CS0305: BidirectionalSkinValue<T> and BidirectionalSkinProperty<T>
            content = Regex.Replace(content, @"\bBidirectionalSkinValue\b(?!<)", "BidirectionalSkinValue<object>");
            content = Regex.Replace(content, @"\bBidirectionalSkinProperty\b(?!<)", "BidirectionalSkinProperty<object>");

            // CS0305: ObservableCollection, UniqueObservableCollection, SuspendableObservableCollection
            content = Regex.Replace(content, @"\bObservableCollection\b(?!<)", "ObservableCollection<object>");
            content = Regex.Replace(content, @"\bUniqueObservableCollection\b(?!<)", "UniqueObservableCollection<object>");
            content = Regex.Replace(content, @"\bSuspendableObservableCollection\b(?!<)", "SuspendableObservableCollection<object>");

            if (content != original)
            {
                File.WriteAllText(file, content);
                count++;
            }
        }
        Console.WriteLine($"Fixed bare generics in {count} files.");
    }

    static void FixToolStripItem()
    {
        string path = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated\Gizmox\WebGUI\Forms\ToolStripItem.cs";
        if (!File.Exists(path)) return;
        
        string content = File.ReadAllText(path);
        string original = content;

        // CS0737: 'ToolStripItem' does not implement interface member 'IArrangedElement.GetValue<T>'
        // because 'SerializableObject.GetValue<T>' is not public.
        // Fix: add explicit public interface implementations that delegate to base.
        // The class inherits SerializableObject which has GetValue<T>/SetValue<T> as non-public.
        // We add public explicit implementations directly in ToolStripItem.
        // Look for the class body opening and inject them right after the opening brace.
        // Pattern: "public abstract class ToolStripItem : Component, IDropTarget, IArrangedElement..."
        // We insert before the first static field declaration.
        string injection = @"
        // Explicit IArrangedElement implementations (CS0737 fix - SerializableObject.GetValue/SetValue are not public)
        T IArrangedElement.GetValue<T>(Gizmox.WebGUI.Common.Interfaces.SerializableProperty key) => GetValue<T>(key);
        void IArrangedElement.SetValue<T>(Gizmox.WebGUI.Common.Interfaces.SerializableProperty key, T value) => SetValue(key, value);
";
        // Find the first "private static readonly SerializableProperty" and insert before it
        var match = Regex.Match(content, @"(\n\t\tprivate static readonly SerializableProperty \w+\s*=)");
        if (match.Success)
        {
            content = content.Insert(match.Index, injection);
        }

        if (content != original)
        {
            File.WriteAllText(path, content);
            Console.WriteLine("Fixed ToolStripItem.cs.");
        }
    }

    static void FixAdministrationContentSorter()
    {
        // CS0535: 'AdministrationContent.AdministrationContentSorter' does not implement interface member 'IComparer.Compare(object?, object?)'
        // The class implements IComparer<AdministrationContent> but IComparer (non-generic) needs an object? overload
        string path = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated\Gizmox\WebGUI\Forms\Administration\AdministrationContent.cs";
        if (!File.Exists(path)) return;
        
        string content = File.ReadAllText(path);
        string original = content;

        // Replace bare "IComparer" (non-generic) with "IComparer<AdministrationContent>" where it appears as interface declaration
        content = Regex.Replace(content,
            @"\bclass AdministrationContentSorter\s*:\s*IComparer\b(?!<)",
            "class AdministrationContentSorter : IComparer<AdministrationContent>");

        if (content != original)
        {
            File.WriteAllText(path, content);
            Console.WriteLine("Fixed AdministrationContent.cs.");
        }
    }

    static void FixDeviceComponents()
    {
        var deviceDir = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\Generated\Gizmox\WebGUI\Forms\DeviceIntegration";
        if (!Directory.Exists(deviceDir)) return;

        // Map: file name -> EventArgs type for SingleCallMethodStore/MultipleCallMethodStore
        var fixes = new (string FileName, string EventArgs)[]
        {
            ("Accelerometer.cs", "AccelerometerEventArgs"),
            ("Compass.cs", "CompassEventArgs"),
            ("Camera.cs", "CameraEventArgs"),
            ("Capture.cs", "CaptureEventArgs"),
            ("Contacts.cs", "ContactsEventArgs"),
            ("Connection.cs", "ConnectionEventArgs"),
            ("DeviceInfo.cs", "DeviceInfoEventArgs"),
            ("DeviceEvents.cs", "DeviceEventArgs"),
            ("DeviceMedia.cs", "DeviceMediaEventArgs"),
            ("FileManager.cs", "FileManagementEventArgs"),
            ("Geolocation.cs", "GeolocationEventArgs"),
            ("Globalization.cs", "GlobalizationEventArgs"),
            ("Notifications.cs", "NotificationEventArgs"),
            ("Storage.cs", "StorageEventArgs"),
        };

        foreach (var (fileName, eventArgs) in fixes)
        {
            var path = Path.Combine(deviceDir, fileName);
            if (!File.Exists(path)) continue;

            string content = File.ReadAllText(path);
            string original = content;

            // Fix field declarations without type arg:
            content = Regex.Replace(content, @"\bSingleCallMethodStore\b(?!<)", "SingleCallMethodStore<" + eventArgs + ">");
            content = Regex.Replace(content, @"\bMultipleCallMethodStore\b(?!<)", "MultipleCallMethodStore<" + eventArgs + ">");

            // Fix field ACCESS with spurious type args: mobjSingleCallMethodStore<TypeArg> = ...  or  if (mobjX<TypeArg> ...)
            // These are ILSpy artifact: field name written as fieldname<typearg> in access context
            // Strip the <typearg> from identifier access (not from type declarations). After prior fix above
            // the declarations are already correct - only accesses remain.
            content = Regex.Replace(content,
                @"\b(mobj(?:Single|Multiple)CallMethod(?:Store|Store))<[A-Za-z][A-Za-z0-9]*>",
                "$1");

            // Fix missing Action<> type args for method parameters & events:
            content = Regex.Replace(content, @"event Action ([A-Za-z]+)\s*\{", "event Action<" + eventArgs + "> $1 {");
            content = Regex.Replace(content, @"void GetCurrent([A-Za-z]+)\(Action objCallback\)", "void GetCurrent$1(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void GetPicture\(Action objCallback\)", "void GetPicture(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void GetPicture\(Action objCallback, CameraOptions", "void GetPicture(Action<" + eventArgs + "> objCallback, CameraOptions");
            content = Regex.Replace(content, @"void Cleanup\(Action objCallback\)", "void Cleanup(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void CaptureAudio\(Action objCallback\)", "void CaptureAudio(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void CaptureAudio\(([^)]+), Action objCallback\)", "void CaptureAudio($1, Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void CaptureImage\(Action objCallback\)", "void CaptureImage(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void CaptureImage\(([^)]+), Action objCallback\)", "void CaptureImage($1, Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void CaptureVideo\(Action objCallback\)", "void CaptureVideo(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void CaptureVideo\(([^)]+), Action objCallback\)", "void CaptureVideo($1, Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"void GetCurrentHeading\(Action objCallback\)", "void GetCurrentHeading(Action<" + eventArgs + "> objCallback)");

            if (content != original)
            {
                File.WriteAllText(path, content);
                Console.WriteLine("Fixed " + fileName);
            }
        }

        // Subfolders: CaptureComponents, ContactsData, FileManagement, MediaComponents, StorageComponents
        FixDeviceSubfolder(Path.Combine(deviceDir, "CaptureComponents"), "CaptureEventArgs");
        FixDeviceSubfolder(Path.Combine(deviceDir, "ContactsData"), "ContactsEventArgs");
        FixDeviceSubfolder(Path.Combine(deviceDir, "FileManagement"), "FileManagementEventArgs");
        FixDeviceSubfolder(Path.Combine(deviceDir, "MediaComponents"), "MediaEventArgs");
        FixDeviceSubfolder(Path.Combine(deviceDir, "StorageComponents"), "StorageEventArgs");
    }

    static void FixDeviceSubfolder(string dir, string eventArgs)
    {
        if (!Directory.Exists(dir)) return;
        foreach (var path in Directory.GetFiles(dir, "*.cs"))
        {
            string content = File.ReadAllText(path);
            string original = content;
            content = Regex.Replace(content, @"\bSingleCallMethodStore\b(?!<)", "SingleCallMethodStore<" + eventArgs + ">");
            content = Regex.Replace(content, @"\bMultipleCallMethodStore\b(?!<)", "MultipleCallMethodStore<" + eventArgs + ">");
            // Strip spurious type args from field accesses:
            content = Regex.Replace(content, @"\b(mobj(?:Single|Multiple)CallMethodStore)<[A-Za-z][A-Za-z0-9]*>", "$1");
            content = Regex.Replace(content, @"event Action ([A-Za-z]+)\s*\{", "event Action<" + eventArgs + "> $1 {");
            content = Regex.Replace(content, @"\(Action objCallback\)", "(Action<" + eventArgs + "> objCallback)");
            content = Regex.Replace(content, @"\(EventHandler obj([A-Za-z]+)\)", "(EventHandler<" + eventArgs + "> obj$1)");
            content = Regex.Replace(content, @"GetFormatData\(EventHandler<", "GetFormatData(EventHandler<");
            if (content != original) { File.WriteAllText(path, content); Console.WriteLine("Fixed " + Path.GetFileName(path)); }
        }
    }
}
