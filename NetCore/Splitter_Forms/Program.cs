using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms";
        string filePath = Path.Combine(baseDir, "Gizmox.WebGUI.Forms.decompiled.cs.bak");
        string outDir = Path.Combine(baseDir, "Generated");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        Console.WriteLine("Reading " + filePath);
        string code = File.ReadAllText(filePath);

        // Strip assembly attributes (SDK auto-generates; cause CS0579)
        code = Regex.Replace(code, @"\[assembly:[^\]]+\]\s*", "");

        // ILSpy / decompiler artifact cleanup
        Console.WriteLine("Cleaning artifacts...");
        code = code.Replace("Gen_<", "<").Replace("Gen_(", "(");
        
        // Use Regex to avoid double generics like List<object><object>
        code = Regex.Replace(code, @"\bReadOnlyCollectionGen_(?!<)", "ReadOnlyCollection<object>");
        code = Regex.Replace(code, @"\bListGen_(?!<)", "List<object>");
        code = Regex.Replace(code, @"\bICollectionGen_(?!<)", "ICollection<object>");
        code = Regex.Replace(code, @"\bQueueGen_(?!<)", "Queue<object>");

        // Also handle the cases where they ARE followed by < (just remove the Gen_ prefix)
        code = code.Replace("ReadOnlyCollectionGen_", "ReadOnlyCollection");
        code = code.Replace("ListGen_", "List");
        code = code.Replace("ICollectionGen_", "ICollection");
        code = code.Replace("QueueGen_", "Queue");

        // Fix class X where Y : Z -> class X<Y> where Y : Z (constraint without type param)
        code = Regex.Replace(code, @"\bclass\s+(\w+)\s+where\s+(\w+)\s*:", "class $1<$2> where $2 :");

        // BidirectionalSkinValue/BidirectionalSkinProperty used without type arg (ILSpy loses generic info)
        code = Regex.Replace(code, @"\bBidirectionalSkinValue(?!\s*<|Converter)", "BidirectionalSkinValue<object>");
        code = Regex.Replace(code, @"\bBidirectionalSkinProperty(?!\s*<|Converter)", "BidirectionalSkinProperty<object>");


        // Generic method T GetProxyPropertyValue(string, T) -> T GetProxyPropertyValue<T>(string, T)
        code = Regex.Replace(code, @"(\s)T GetProxyPropertyValue\s*\(\s*string\s+strPropertyName\s*,\s*T\s+", "$1T GetProxyPropertyValue<T>(string strPropertyName, T ");

        // FireEvent: base is protected, override must not widen - change public to protected
        code = Regex.Replace(code, @"public override void FireEvent\(IEvent objEvent\)", "protected override void FireEvent(IEvent objEvent)");

        // AdministrationContentSorter: IComparer needs Compare(object?, object?) - use IComparer<AdministrationContent> instead
        code = Regex.Replace(code, @"public class AdministrationContentSorter : IComparer\b", "public class AdministrationContentSorter : IComparer<AdministrationContent>");


        // Method with constraint but no generic param: TContextType GetContaxt(...) where TContextType : class
        code = Regex.Replace(code, @"internal TContextType GetContaxt\s*\(\s*string\s+strMethodKey\s*\)\s+where TContextType : class", "internal TContextType GetContaxt<TContextType>(string strMethodKey) where TContextType : class");

        // IArrangedElement: T GetValue/SetValue need generic method (interface and explicit impl)
        code = Regex.Replace(code, @"\bT GetValue\s*\(\s*SerializableProperty\s+", "T GetValue<T>(SerializableProperty ");
        code = Regex.Replace(code, @"void SetValue\s*\(\s*SerializableProperty\s+objSerializableProperty\s*,\s*T\s+objValue\s*\)", "void SetValue<T>(SerializableProperty objSerializableProperty, T objValue)");
        code = Regex.Replace(code, @"T IArrangedElement\.GetValue\s*\(\s*SerializableProperty\s+", "T IArrangedElement.GetValue<T>(SerializableProperty ");
        code = Regex.Replace(code, @"void IArrangedElement\.SetValue\s*\(\s*SerializableProperty\s+objSerializableProperty\s*,\s*T\s+objValue\s*\)", "void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue)");

        // ListBox.ObjectCollectionComparer: IComparer -> IComparer<ListBox.ListBoxItem>
        code = Regex.Replace(code, @"ObjectCollectionComparer : IComparer\b", "ObjectCollectionComparer : IComparer<ListBox.ListBoxItem>");
        code = Regex.Replace(code, @"int IComparer\.Compare\s*\(\s*ListBoxItem\s+", "int IComparer<ListBoxItem>.Compare(ListBoxItem ");

        // JsonUtils fix: generic Deserialize
        code = Regex.Replace(code, @"public static T Deserialize\(string strJSON\)", "public static T Deserialize<T>(string strJSON)");
        // Resolve JsonUtils.Deserialize duplicate conflict
        code = Regex.Replace(code, @"public static JObject Deserialize\(string strJSON\)\s*{\s*return JsonConvert\.DeserializeObject\(strJSON\) as JObject;\s*}", "public static JObject DeserializeJObject(string strJSON) { return JsonConvert.DeserializeObject(strJSON) as JObject; }");

        // Component.cs access modifier fixes
        code = Regex.Replace(code, @"protected override bool IsSerializableObjectInitializing\s*{\s*protected internal get", "protected override bool IsSerializableObjectInitializing { get");
        code = Regex.Replace(code, @"protected override int SerializableFieldStorageInitialSize\s*{\s*protected internal get", "protected override int SerializableFieldStorageInitialSize { get");

        // SingleCallMethodStore/MultipleCallMethodStore fixes
        // Inner class shadowing/missing type arg
        code = Regex.Replace(code, @"private class ContextualData<TEventArgsType> where TEventArgsType : EventArgs", "private class ContextualData");
        code = Regex.Replace(code, @"private Dictionary<string, ContextualData> mobjContextualMethodsIndexByMethodKey;", "private Dictionary<string, ContextualData> mobjContextualMethodsIndexByMethodKey;"); // already correct usage if nested class is not generic
        
        // Usages of MethodStore without type args: use <EventArgs> as fallback if we can't determine specific type
        // Use a lookbehind for common keywords to avoid matching property names in some cases
        // Avoid constructors (followed by '(')
        code = Regex.Replace(code, @"(?<=\b(?:private|public|protected|internal|new|static|readonly)\s+)\b(Single|Multiple)CallMethodStore\b(?!\s*<)(?!\s*\()", "$1CallMethodStore<EventArgs>");
        // Fix initializations specifically
        code = Regex.Replace(code, @"new (Single|Multiple)CallMethodStore\(\)", "new $1CallMethodStore<EventArgs>()");

        // Fix CloneWithoutReferences generic method
        code = Regex.Replace(code, @"\bT CloneWithoutReferences\(\)", "T CloneWithoutReferences<T>()");

        

        // Fix specific method calls that need explicit type arguments
        // GetContaxt calls
        code = Regex.Replace(code, @"(\w+)\s*=\s*(\w+)\.GetContaxt\s*\(", (Match m) => {
            string varName = m.Groups[1].Value;
            string storeName = m.Groups[2].Value;
            string typeArg = "object";
            if (varName.Contains("contaxt"))
            {
                if (storeName.Contains("Entry")) typeArg = "Entry";
                else if (storeName.Contains("DirectoryReader")) typeArg = "DirectoryReader";
                else if (storeName.Contains("FileWriter")) typeArg = "FileEntry";
            }
            return $"{varName} = {storeName}.GetContaxt<{typeArg}>(";
        });

        // TryGetError calls
        code = Regex.Replace(code, @"DeviceEventArgs\.TryGetError\s*\(\s*(\w+)\s*,\s*out\s+((?:var\s+)?\w+)\s*\)", (Match m) => {
            string eventVar = m.Groups[1].Value;
            string outVarDecl = m.Groups[2].Value; // includes 'var ' if present
            string outVar = outVarDecl.Replace("var ", "").Trim();
            string typeArg = "EmptyDeviceEventArgs";
            
            // Infer type from variable name or surrounding context if possible
            if (outVar.Contains("args") || outVar.Contains("Event"))
            {
                // Common mapping in Gizmox
                if (outVar.Contains("FileSystem")) typeArg = "Gizmox.WebGUI.Common.Device.FileManagement.FileSystemEventArgs";
                else if (outVar.Contains("Metadata")) typeArg = "MetadataEventArgs";
                else if (outVar.Contains("Entry")) typeArg = "EntryEventArgs";
                else if (outVar.Contains("FileWriter")) typeArg = "FileWriterEventArgs";
                else if (outVar.Contains("File")) typeArg = "FileEventArgs";
                else if (outVar.Contains("Battery")) typeArg = "DeviceBatteryEventArgs";
            }
            return $"DeviceEventArgs.TryGetError<{typeArg}>({eventVar}, out {outVarDecl})";
        });

        // Fix more type-not-found issues like 'T' in non-generic context
        code = Regex.Replace(code, @"public static T Deserialize<T>\(string strJSON\)", "public static T Deserialize<T>(string strJSON)"); // already handled above

        // Fix explicit interface implementations that lost generic arguments
        code = Regex.Replace(code, @"void IComponent\.Site\.set", "void IComponent.Site.set"); // generic fix if needed

        Console.WriteLine("Parsing syntax tree...");
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        string usings = string.Join("\n", root.Usings.Select(u => u.ToFullString().TrimEnd()));

        if (Directory.Exists(outDir)) Directory.Delete(outDir, true);
        Directory.CreateDirectory(Path.Combine(outDir, "Global"));
        
        int count = 0;

        var allTypes = root.DescendantNodes().OfType<BaseTypeDeclarationSyntax>()
            .Where(t => t.Parent is NamespaceDeclarationSyntax || t.Parent is CompilationUnitSyntax);

        foreach (var type in allTypes)
        {
            string className = type.Identifier.Text;
            var typeDecl = type as TypeDeclarationSyntax;
            if (typeDecl != null && typeDecl.TypeParameterList != null && typeDecl.TypeParameterList.Parameters.Count > 0)
            {
                className += "`" + typeDecl.TypeParameterList.Parameters.Count;
            }

            string nsName = GetNamespace(type);
            string dir = outDir;
            if (!string.IsNullOrEmpty(nsName))
            {
                dir = Path.Combine(outDir, nsName.Replace(".", "\\"));
            }
            else
            {
                dir = Path.Combine(outDir, "Global");
            }
            Directory.CreateDirectory(dir);

            string typeCode = type.ToFullString();

            if (!(type is EnumDeclarationSyntax))
            {
                // Unified generic inference for List, Collection, and Special Collections
                // Use a broader lookbehind to catch local variables and assignments, but avoid property names
                // Negative lookahead (?!\s*[<.=,!]) ensures we don't match properties like 'if (List != null)'
                typeCode = Regex.Replace(typeCode, @"(?m)(?<=\b(?:public|private|protected|internal|static|readonly|new|partial|sealed|override|virtual|abstract|var)\s+|[:<,\(\[]\s*|^[ \t]*)\b(List|Collection|ObservableCollection|SuspendableObservableCollection|UniqueObservableCollection)\b(?!\s*[<.=,!])(?!\s*\b(?:is|as)\b)(?<!\b(?:ArrayList|IList|ICollection|IEnumerable|BindingSource|AccessibleRole|BindingsCollection|View|CurrencyManager|BaseCollection|ToolBarButtonCollection)\s+)", (Match m) => {
                    string baseType = m.Groups[1].Value;
                    
                    // Special cases where we can't infer from overrides
                    if (className == "ProxySet") return $"{baseType}<ProxyComponent>";
                    if (className == "ProxySets") return $"{baseType}<ProxySet>";

                    // Try smart inference from overrides
                    string body = typeCode.Substring(m.Index);
                    if (body.Length > 10000) body = body.Substring(0, 10000);
                    Match mOverride = Regex.Match(body, @"protected override void (InsertItem|SetItem)\(int \w+, (\w+) \w+\)");
                    if (mOverride.Success)
                    {
                        return $"{baseType}<{mOverride.Groups[2].Value}>";
                    }
                    
                    return $"{baseType}<object>";
                });
            }

            // Fix GetHandler(EventName) -> GetHandler(EventNameEvent)
            // This is needed because 'EventName' matches the event name itself, causing CS0079
            typeCode = Regex.Replace(typeCode, @"GetHandler\((ParentChanged|Resize|TextChanged|CausesValidationChanged|TextChangedQueued|BindingContextChanged|BackgroundImageChanged|BackgroundImageLayoutChanged|FontChanged|ForeColorChanged|PaddingChanged|CursorChanged|VisibleChanged|HelpRequested|AutoSizeChanged|SizeChanged|ControlAdded|ControlRemoved|ControlEditing|MouseDown|MouseUp|DoubleClick|Click|ControlSelected|ControlDropped|MouseClick|KeyDown|KeyPress|KeyUp|GotFocus|LostFocus|Validated|Validating|SelectedIndexChanged|SelectedIndexChangedQueued|SelectionChangeCommitted|DropDown|DropDownClosed)\)", "GetHandler($1Event)");
            
            // Fix static event registrations in static constructor
            if (className == "ComboBox")
            {
                typeCode = typeCode.Replace("SelectedIndexChangedQueued = SerializableEvent.Register", "SelectedIndexChangedQueuedEvent = SerializableEvent.Register");
                typeCode = typeCode.Replace("SelectedIndexChanged = SerializableEvent.Register", "SelectedIndexChangedEvent = SerializableEvent.Register");
                typeCode = typeCode.Replace("SelectionChangeCommitted = SerializableEvent.Register", "SelectionChangeCommittedEvent = SerializableEvent.Register");
                typeCode = typeCode.Replace("DropDown = SerializableEvent.Register", "DropDownEvent = SerializableEvent.Register");
                typeCode = typeCode.Replace("DropDownClosed = SerializableEvent.Register", "DropDownClosedEvent = SerializableEvent.Register");
            }

            // --- Class-Specific Fixes ---
            // (Keeping the existing class-specific fixes logic)
            if (className == "ListBox")
            {
                typeCode = Regex.Replace(typeCode, @"int IComparer<ListBoxItem>\.Compare\(ListBoxItem objFirstListBoxItem, ListBoxItem objSecondListBoxItem\)", "int IComparer<ListBoxItem>.Compare(ListBoxItem? objFirstListBoxItem, ListBoxItem? objSecondListBoxItem)");
            }

            if (className == "Contact")
            {
                typeCode = Regex.Replace(typeCode, @"private IList GetContactsCollectionProperty\(string strPropertyName\) where T : class", "private IList GetContactsCollectionProperty<T>(string strPropertyName) where T : class");
            }

            if (className == "Timer")
            {
                typeCode = typeCode.Replace("public class Timer : ComponentBase, ITimer", "public class Timer : ComponentBase, Gizmox.WebGUI.Common.Interfaces.ITimer");
                typeCode = typeCode.Replace("int ITimer.TimerID", "int Gizmox.WebGUI.Common.Interfaces.ITimer.TimerID");
                typeCode = typeCode.Replace("int ITimer.Interval", "int Gizmox.WebGUI.Common.Interfaces.ITimer.Interval");
                typeCode = typeCode.Replace("bool ITimer.Enabled", "bool Gizmox.WebGUI.Common.Interfaces.ITimer.Enabled");
                typeCode = typeCode.Replace("int ITimer.InvokeTimer()", "int Gizmox.WebGUI.Common.Interfaces.ITimer.InvokeTimer()");
                typeCode = typeCode.Replace("int ITimer.GetNextInvokation(", "int Gizmox.WebGUI.Common.Interfaces.ITimer.GetNextInvokation(");
                typeCode = typeCode.Replace("((ITimer)this)", "((Gizmox.WebGUI.Common.Interfaces.ITimer)this)");
            }

            if (className == "NumericUpDownAccelerationCollection")
            {
                // Fix duplicate IEnumerable and missing ICollection members
                typeCode = typeCode.Replace(", IEnumerable, IEnumerable", ", IEnumerable");
                // Remove existing dummy implementations if they exist (including their attributes) - specific regex to avoid over-matching
                typeCode = typeCode.Replace("[Obsolete(\"Not implemented. Added for migration compatibility\")]\r\n\t\t[Browsable(false)]\r\n\t\t[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]\r\n\t\tIEnumerator IEnumerable.GetEnumerator()\r\n\t\t{\r\n\t\t\treturn null;\r\n\t\t}", "");
                typeCode = typeCode.Replace("[Obsolete(\"Not implemented. Added for migration compatibility\")]\n\t\t[Browsable(false)]\n\t\t[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]\n\t\tIEnumerator IEnumerable.GetEnumerator()\n\t\t{\n\t\t\treturn null;\n\t\t}", "");
                // Inject our implementations
                typeCode = Regex.Replace(typeCode, @"public class NumericUpDownAccelerationCollection : MarshalByRefObject, ICollection, IEnumerable\s*\{", 
                    "public class NumericUpDownAccelerationCollection : MarshalByRefObject, ICollection, IEnumerable\n\t{\n\t\tpublic object SyncRoot => this;\n\t\tpublic bool IsSynchronized => false;\n\t\tIEnumerator IEnumerable.GetEnumerator() { return null; }", RegexOptions.Singleline);
            }

            if (className == "ObjectBoxSkin")
            {
                typeCode = typeCode.Replace("typeof(FormBox)", "typeof(Gizmox.WebGUI.Forms.Hosts.FormBox)");
            }

            if (className == "SingleCallMethodStore`1")
            {
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs>()", "internal SingleCallMethodStore()");
            }

            if (className == "MultipleCallMethodStore`1")
            {
                typeCode = typeCode.Replace("internal MultipleCallMethodStore<EventArgs>()", "internal MultipleCallMethodStore()");
            }

            if (className == "ProxySet")
            {
                typeCode = typeCode.Replace(": List,", ": List<ProxyComponent>,");
                typeCode = typeCode.Replace("new List()", "new List<ProxyComponent>()");
            }

            if (className == "ProxySets")
            {
                typeCode = typeCode.Replace(": List,", ": List<ProxySet>,");
                typeCode = typeCode.Replace("new List()", "new List<ProxySet>()");
            }

            if (className == "Zone" || className == "DockedSplitContainer")
            {
                typeCode = typeCode.Replace("List<object> windows =", "List<DockingWindow> windows =");
                typeCode = typeCode.Replace("List<object> Windows", "List<DockingWindow> Windows");
                typeCode = typeCode.Replace("List<object> list =", "List<DockingWindow> list =");
                typeCode = typeCode.Replace("new List<object>()", "new List<DockingWindow>()");
                typeCode = typeCode.Replace("internal List<object>", "internal List<DockingWindow>");
            }

            // Fix potential property corruption (e.g., CurrencyManager.List, BindingSource.List)
            // When 'List' (property) is used as an argument or receiver, it shouldn't have generic arguments
            string classGeneric = "List<" + className + ">";
            typeCode = typeCode.Replace("List<object>[", "List[");
            typeCode = typeCode.Replace(classGeneric + "[", "List[");
            typeCode = typeCode.Replace("(List<object>)", "(List)");
            typeCode = typeCode.Replace("(" + classGeneric + ")", "(List)");
            typeCode = typeCode.Replace("(List<object>,", "(List,");
            typeCode = typeCode.Replace("(" + classGeneric + ",", "(List,");
            typeCode = typeCode.Replace(", List<object>)", ", List)");
            typeCode = typeCode.Replace(", " + classGeneric + ")", ", List)");

            if (className == "AdministrationFooterPanel")
            {
                typeCode = typeCode.Replace("List<object> mobjLabels", "List<Label> mobjLabels");
                typeCode = typeCode.Replace("mobjLabels = new List<object>()", "mobjLabels = new List<Label>()");
                // Avoid duplicate public if already present
                if (!typeCode.Contains("public void SetLabels"))
                {
                    typeCode = Regex.Replace(typeCode, @"void SetLabels\(List(<[^>]*>)? objDatas\)", "public void SetLabels(List<StatusData> objDatas)");
                }
                else
                {
                    typeCode = Regex.Replace(typeCode, @"public void SetLabels\(List(<[^>]*>)? objDatas\)", "public void SetLabels(List<StatusData> objDatas)");
                }
            }
            if (className == "ContentProperties")
            {
                typeCode = Regex.Replace(typeCode, @"\bList(<[^>]*>)?\s+mobjStatusData\b", "List<StatusData> mobjStatusData");
                typeCode = Regex.Replace(typeCode, @"\bpublic\s+List(<[^>]*>)?\s+StatusData\b", "public List<StatusData> StatusData");
                typeCode = Regex.Replace(typeCode, @"\bnew\s+List(<[^>]*>)?\(\)", "new List<StatusData>()");
            }

            if (className == "ContentChangeNotifierUserControl")
            {
                typeCode = typeCode.Replace("ContentChanged = SerializableEvent.Register", "ContentChangedEvent = SerializableEvent.Register");
            }
            
            // Clean global fix for GetStatus using placeholders to avoid doubling
            if (typeCode.Contains("GetStatus()"))
            {
                typeCode = Regex.Replace(typeCode, @"public\s+(abstract|override|virtual)\s+\b(List(<[^>]*>)?|List)\s+GetStatus\(\)", "___SIGNATURE_GET_STATUS___($1)");
                typeCode = typeCode.Replace("___SIGNATURE_GET_STATUS___(abstract)", "public abstract List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> GetStatus()");
                typeCode = typeCode.Replace("___SIGNATURE_GET_STATUS___(override)", "public override List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> GetStatus()");
                typeCode = typeCode.Replace("___SIGNATURE_GET_STATUS___(virtual)", "public virtual List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> GetStatus() { return null; }");
                
                // Ensure using
                if (!typeCode.Contains("using Gizmox.WebGUI.Forms.Administration.Abstract;")) {
                     typeCode = typeCode.Replace("using System;", "using System;\nusing Gizmox.WebGUI.Forms.Administration.Abstract;");
                }
            }
            
            if (className == "Contact")
            {
                typeCode = typeCode.Replace("IList list = GetNullableProperty<List<object>>(strPropertyName);", "IList<T> list = (IList<T>)(object)GetNullableProperty<List<object>>(strPropertyName);");
                
                // ParseFromJson fixes
                typeCode = typeCode.Replace("PhoneNumbers = new List<object>(array);", "PhoneNumbers = new List<ContactField>(array);");
                typeCode = typeCode.Replace("URLs = new List<object>(array2);", "URLs = new List<ContactField>(array2);");
                typeCode = typeCode.Replace("Emails = new List<object>(array3);", "Emails = new List<ContactField>(array3);");
                typeCode = typeCode.Replace("Addresses = new List<object>(array4);", "Addresses = new List<ContactAddress>(array4);");
                typeCode = typeCode.Replace("Organizations = new List<object>(array5);", "Organizations = new List<ContactOrganization>(array5);");
                typeCode = typeCode.Replace("IMs = new List<object>(array6);", "IMs = new List<ContactField>(array6);");
                typeCode = typeCode.Replace("Categories = new List<object>(array7);", "Categories = new List<ContactField>(array7);");
                typeCode = typeCode.Replace("Photos = new List<object>(array8);", "Photos = new List<ContactField>(array8);");

                // DeepCopy fixes
                typeCode = typeCode.Replace("contact.Addresses = new List<object>(Addresses);", "contact.Addresses = new List<ContactAddress>(Addresses);");
                typeCode = typeCode.Replace("contact.Emails = new List<object>(Emails);", "contact.Emails = new List<ContactField>(Emails);");
                typeCode = typeCode.Replace("contact.Categories = new List<object>(Categories);", "contact.Categories = new List<ContactField>(Categories);");
                typeCode = typeCode.Replace("contact.IMs = new List<object>(IMs);", "contact.IMs = new List<ContactField>(IMs);");
                typeCode = typeCode.Replace("contact.Organizations = new List<object>(Organizations);", "contact.Organizations = new List<ContactOrganization>(Organizations);");
                typeCode = typeCode.Replace("contact.PhoneNumbers = new List<object>(PhoneNumbers);", "contact.PhoneNumbers = new List<ContactField>(PhoneNumbers);");
                typeCode = typeCode.Replace("contact.Photos = new List<object>(Photos);", "contact.Photos = new List<ContactField>(Photos);");
                typeCode = typeCode.Replace("contact.URLs = new List<object>(URLs);", "contact.URLs = new List<ContactField>(URLs);");
            }

            if (className == "Contacts")
            {
                typeCode = typeCode.Replace("List<object> list = null;", "List<IContact> list = null;");
                typeCode = typeCode.Replace("list = new List<object>();", "list = new List<IContact>();");
            }
            
            // General fixes for overrides of GetStatus
            if (typeCode.Contains("GetStatus()"))
            {
                typeCode = Regex.Replace(typeCode, @"public\s+override\s+\b(List(<[^>]*>)?|List)\s+GetStatus\(\)", "public override List<Gizmox.WebGUI.Forms.Administration.Abstract.StatusData> GetStatus()");
                if (!typeCode.Contains("using Gizmox.WebGUI.Forms.Administration.Abstract;"))
                {
                    typeCode = typeCode.Replace("using System;", "using System;\nusing Gizmox.WebGUI.Forms.Administration.Abstract;");
                }
            }
            typeCode = typeCode.Replace("List<global::Gizmox.WebGUI.Forms.Administration.Abstract.StatusData>", "List<StatusData>");

            if (className == "WatchedDeviceComponent")
            {
                nsName = "Gizmox.WebGUI.Forms.DeviceIntegration.Abstract";
                typeCode = typeCode.Trim();
                // If it has a double-closing brace at the end, remove one
                typeCode = Regex.Replace(typeCode, @"\}\s*\}\s*$", "}");
                // Ensure it ends with at least one brace
                if (!typeCode.EndsWith("}")) typeCode += "\n\t}";
            }

            if (className == "Accelerometer")
            {
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> mobjSingleCallMethodStore;", "private SingleCallMethodStore<AccelerometerEventArgs> mobjSingleCallMethodStore;");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> mobjMultipleCallMethodStore;", "private MultipleCallMethodStore<AccelerometerEventArgs> mobjMultipleCallMethodStore;");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<AccelerometerEventArgs>()");
                typeCode = typeCode.Replace("new MultipleCallMethodStore<EventArgs>()", "new MultipleCallMethodStore<AccelerometerEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"public void GetCurrentAcceleration\(Action<EventArgs> objCallback\)", "public void GetCurrentAcceleration(Action<AccelerometerEventArgs> objCallback)");
                typeCode = Regex.Replace(typeCode, @"public event Action<EventArgs> AccelerationChanged", "public event Action<AccelerometerEventArgs> AccelerationChanged");
            }

            if (className == "Geolocation")
            {
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCallMethodStore", "private SingleCallMethodStore<GeolocationEventArgs> SingleCallMethodStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> MultipleCallMethodStore", "private MultipleCallMethodStore<GeolocationEventArgs> MultipleCallMethodStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> mobjSingleCallMethodStore;", "private SingleCallMethodStore<GeolocationEventArgs> mobjSingleCallMethodStore;");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> mobjMultipleCallMethodStore;", "private MultipleCallMethodStore<GeolocationEventArgs> mobjMultipleCallMethodStore;");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<GeolocationEventArgs>()");
                typeCode = typeCode.Replace("new MultipleCallMethodStore<EventArgs>()", "new MultipleCallMethodStore<GeolocationEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"public void GetPosition\(Action<EventArgs> objCallback\)", "public void GetPosition(Action<GeolocationEventArgs> objCallback)");
                typeCode = Regex.Replace(typeCode, @"public event Action<EventArgs> PositionChanged", "public event Action<GeolocationEventArgs> PositionChanged");
            }

            if (className == "Camera")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjCameraMethodStore", "SingleCallMethodStore<CameraEventArgs> mobjCameraMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjClearMethodStore", "SingleCallMethodStore<CleanupEventArgs> mobjClearMethodStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<CameraEventArgs>()");
                typeCode = typeCode.Replace("mobjClearMethodStore = new SingleCallMethodStore<CameraEventArgs>()", "mobjClearMethodStore = new SingleCallMethodStore<CleanupEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"public void GetPicture\(Action objCallback", "public void GetPicture(Action<CameraEventArgs> objCallback");
                typeCode = Regex.Replace(typeCode, @"public void Cleanup\(Action objCallback\)", "public void Cleanup(Action<CleanupEventArgs> objCallback)");
            }

            if (className == "Capture")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjCaptureEventArgsStore", "SingleCallMethodStore<CaptureEventArgs> mobjCaptureEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjMediaFileDataEventArgsStore", "SingleCallMethodStore<MediaFileDataEventArgs> mobjMediaFileDataEventArgsStore");
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs> CaptureEventArgsStore", "internal SingleCallMethodStore<CaptureEventArgs> CaptureEventArgsStore");
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs> MediaFileDataEventArgsStore", "internal SingleCallMethodStore<MediaFileDataEventArgs> MediaFileDataEventArgsStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<CaptureEventArgs>()");
                typeCode = typeCode.Replace("mobjMediaFileDataEventArgsStore = new SingleCallMethodStore<CaptureEventArgs>()", "mobjMediaFileDataEventArgsStore = new SingleCallMethodStore<MediaFileDataEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"\bCaptureAudio\(Action", "CaptureAudio(Action<CaptureEventArgs>");
                typeCode = Regex.Replace(typeCode, @"\bCaptureImage\(Action", "CaptureImage(Action<CaptureEventArgs>");
                typeCode = Regex.Replace(typeCode, @"\bCaptureVideo\(Action", "CaptureVideo(Action<CaptureEventArgs>");
                typeCode = typeCode.Replace("internal void GetFormatData(MediaFile objMediaFile, EventHandler objCallback)", "internal void GetFormatData(MediaFile objMediaFile, EventHandler<MediaFileDataEventArgs> objCallback)");
            }

            if (className == "Compass")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjSingleCallMethodStore", "SingleCallMethodStore<CompassEventArgs> mobjSingleCallMethodStore");
                typeCode = typeCode.Replace("MultipleCallMethodStore<EventArgs> mobjMultipleCallMethodStore", "MultipleCallMethodStore<CompassEventArgs> mobjMultipleCallMethodStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<CompassEventArgs>()");
                typeCode = typeCode.Replace("new MultipleCallMethodStore<EventArgs>()", "new MultipleCallMethodStore<CompassEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"public event Action HeadingChanged", "public event Action<CompassEventArgs> HeadingChanged");
                typeCode = Regex.Replace(typeCode, @"public void GetCurrentHeading\(Action objCallback\)", "public void GetCurrentHeading(Action<CompassEventArgs> objCallback)");
            }

            if (className == "Connection")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjSingleCallMethodStore", "SingleCallMethodStore<ConnectionEventArgs> mobjSingleCallMethodStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<ConnectionEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"public void GetConnection\(Action objCallback\)", "public void GetConnection(Action<ConnectionEventArgs> objCallback)");
            }

            if (className == "Contacts")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjFindContactsCallbackStore", "SingleCallMethodStore<FindContactsEventArgs> mobjFindContactsCallbackStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjRemoveContactCallbackStore", "SingleCallMethodStore<EmptyDeviceEventArgs> mobjRemoveContactCallbackStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjSaveContactCallbackStore", "SingleCallMethodStore<SaveContactEventArgs> mobjSaveContactCallbackStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<FindContactsEventArgs>()"); 
                typeCode = typeCode.Replace("mobjRemoveContactCallbackStore ?? new SingleCallMethodStore<FindContactsEventArgs>()", "mobjRemoveContactCallbackStore ?? new SingleCallMethodStore<EmptyDeviceEventArgs>()");
                typeCode = typeCode.Replace("mobjSaveContactCallbackStore ?? new SingleCallMethodStore<FindContactsEventArgs>()", "mobjSaveContactCallbackStore ?? new SingleCallMethodStore<SaveContactEventArgs>()");
                typeCode = typeCode.Replace("public void FindContacts(EventHandler<EventArgs> objMethod, ContactFindOptions objOptions)", "public void FindContacts(EventHandler<FindContactsEventArgs> objMethod, ContactFindOptions objOptions)");
            }

            if (className == "FileManager")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjEntryMetadataEventStore", "SingleCallMethodStore<MetadataEventArgs> mobjEntryMetadataEventStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjEntryEventArgsStore", "SingleCallMethodStore<EntryEventArgs> mobjEntryEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjEmptyArgsStore", "SingleCallMethodStore<EmptyDeviceEventArgs> mobjEmptyArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjToUrlEventArgsStore", "SingleCallMethodStore<ToUrlEventArgs> mobjToUrlEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjDirectoryReaderEventArgsStore", "SingleCallMethodStore<DirectoryReaderEventArgs> mobjDirectoryReaderEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjFileEventArgsStore", "SingleCallMethodStore<FileEventArgs> mobjFileEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjFileWriterEventArgsStore", "SingleCallMethodStore<FileWriterEventArgs> mobjFileWriterEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjFileUploadEventArgsStore", "SingleCallMethodStore<FileUploadEventArgs> mobjFileUploadEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjFileDownloadEventArgsStore", "SingleCallMethodStore<FileDownloadEventArgs> mobjFileDownloadEventArgsStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<EmptyDeviceEventArgs>()"); 
                typeCode = typeCode.Replace("mobjEntryMetadataEventStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjEntryMetadataEventStore = new SingleCallMethodStore<MetadataEventArgs>()");
                typeCode = typeCode.Replace("mobjEntryEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjEntryEventArgsStore = new SingleCallMethodStore<EntryEventArgs>()");
                typeCode = typeCode.Replace("mobjToUrlEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjToUrlEventArgsStore = new SingleCallMethodStore<ToUrlEventArgs>()");
                typeCode = typeCode.Replace("mobjDirectoryReaderEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjDirectoryReaderEventArgsStore = new SingleCallMethodStore<DirectoryReaderEventArgs>()");
                typeCode = typeCode.Replace("mobjFileEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjFileEventArgsStore = new SingleCallMethodStore<FileEventArgs>()");
                typeCode = typeCode.Replace("mobjFileWriterEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjFileWriterEventArgsStore = new SingleCallMethodStore<FileWriterEventArgs>()");
                typeCode = typeCode.Replace("mobjFileUploadEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjFileUploadEventArgsStore = new SingleCallMethodStore<FileUploadEventArgs>()");
                typeCode = typeCode.Replace("mobjFileDownloadEventArgsStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjFileDownloadEventArgsStore = new SingleCallMethodStore<FileDownloadEventArgs>()");
            }

            if (className == "Notifications")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjAlertStore", "SingleCallMethodStore<EmptyDeviceEventArgs> mobjAlertStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjConfirmStore", "SingleCallMethodStore<ConfirmEventArgs> mobjConfirmStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjBeepStore", "SingleCallMethodStore<EmptyDeviceEventArgs> mobjBeepStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjVibrateStore", "SingleCallMethodStore<EmptyDeviceEventArgs> mobjVibrateStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<EmptyDeviceEventArgs>()");
                typeCode = typeCode.Replace("mobjConfirmStore = new SingleCallMethodStore<EmptyDeviceEventArgs>()", "mobjConfirmStore = new SingleCallMethodStore<ConfirmEventArgs>()");
            }

            if (className == "Globalization")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjSingleCallMethodStore", "SingleCallMethodStore<GlobalizationEventArgs> mobjSingleCallMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjSingleDateCallMethodStore", "SingleCallMethodStore<GlobalizationDateEventArgs> mobjSingleDateCallMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjInfoSingleCallMethodStore", "SingleCallMethodStore<GlobalizationInfoEventArgs> mobjInfoSingleCallMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjDatePatternSingleCallMethodStore", "SingleCallMethodStore<GlobalizationDatePatternEventArgs> mobjDatePatternSingleCallMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjNumberPatternSingleCallMethodStore", "SingleCallMethodStore<GlobalizationNumberPatternEventArgs> mobjNumberPatternSingleCallMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjCurrencyPatternSingleCallMethodStore", "SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> mobjCurrencyPatternSingleCallMethodStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjListSingleCallMethodStore", "SingleCallMethodStore<GlobalizationListEventArgs> mobjListSingleCallMethodStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<GlobalizationEventArgs>()");
                typeCode = typeCode.Replace("mobjSingleDateCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>()", "mobjSingleDateCallMethodStore = new SingleCallMethodStore<GlobalizationDateEventArgs>()");
                typeCode = typeCode.Replace("mobjInfoSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>()", "mobjInfoSingleCallMethodStore = new SingleCallMethodStore<GlobalizationInfoEventArgs>()");
                typeCode = typeCode.Replace("mobjDatePatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>()", "mobjDatePatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationDatePatternEventArgs>()");
                typeCode = typeCode.Replace("mobjNumberPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>()", "mobjNumberPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationNumberPatternEventArgs>()");
                typeCode = typeCode.Replace("mobjCurrencyPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>()", "mobjCurrencyPatternSingleCallMethodStore = new SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs>()");
                typeCode = typeCode.Replace("mobjListSingleCallMethodStore = new SingleCallMethodStore<GlobalizationEventArgs>()", "mobjListSingleCallMethodStore = new SingleCallMethodStore<GlobalizationListEventArgs>()");
            }

            if (className == "DeviceMedia")
            {
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjMediaPositionEventArgsStore", "SingleCallMethodStore<MediaPositionEventArgs> mobjMediaPositionEventArgsStore");
                typeCode = typeCode.Replace("SingleCallMethodStore<EventArgs> mobjMediaEventArgsStore", "SingleCallMethodStore<MediaEventArgs> mobjMediaEventArgsStore");
                typeCode = typeCode.Replace("Dictionary<string, MultipleCallMethodStore<EventArgs>> mobjMediaIdPositionChangedStoreMap", "Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>> mobjMediaIdPositionChangedStoreMap");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>()", "new SingleCallMethodStore<MediaPositionEventArgs>()");
                typeCode = typeCode.Replace("mobjMediaEventArgsStore = new SingleCallMethodStore<MediaPositionEventArgs>()", "mobjMediaEventArgsStore = new SingleCallMethodStore<MediaEventArgs>()");
                typeCode = typeCode.Replace("new MultipleCallMethodStore<EventArgs>()", "new MultipleCallMethodStore<MediaPositionEventArgs>()");
                typeCode = typeCode.Replace("MultipleCallMethodStore<EventArgs> value = null;", "MultipleCallMethodStore<MediaPositionEventArgs> value = null;");
            }

            if (className == "DeviceEvents")
            {
                typeCode = Regex.Replace(typeCode, @"private MultipleCallMethodStore<EventArgs> (\w+EventStore)", "private MultipleCallMethodStore<EmptyDeviceEventArgs> $1");
                typeCode = typeCode.Replace("new MultipleCallMethodStore<EventArgs>()", "new MultipleCallMethodStore<EmptyDeviceEventArgs>()");
                typeCode = typeCode.Replace("mobjBatteryCriticalEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>()", "mobjBatteryCriticalEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>()");
                typeCode = typeCode.Replace("mobjBatteryLowEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>()", "mobjBatteryLowEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>()");
                typeCode = typeCode.Replace("mobjBatteryStatusEventStore = new MultipleCallMethodStore<EmptyDeviceEventArgs>()", "mobjBatteryStatusEventStore = new MultipleCallMethodStore<DeviceBatteryEventArgs>()");
                typeCode = Regex.Replace(typeCode, @"public event Action<EventArgs> (\w+)", "public event Action<EmptyDeviceEventArgs> $1");
                typeCode = typeCode.Replace("public event Action<EmptyDeviceEventArgs> BatteryCritical", "public event Action<DeviceBatteryEventArgs> BatteryCritical");
                typeCode = typeCode.Replace("public event Action<EmptyDeviceEventArgs> BatteryLow", "public event Action<DeviceBatteryEventArgs> BatteryLow");
                typeCode = typeCode.Replace("public event Action<EmptyDeviceEventArgs> BatteryStatusChanged", "public event Action<DeviceBatteryEventArgs> BatteryStatusChanged");
            }

            if (className == "Database")
            {
                typeCode = typeCode.Replace("Transaction(EventHandler objCallback)", "Transaction(EventHandler<TransactionEventArgs> objCallback)");
            }

            if (className == "SQLTransaction")
            {
                typeCode = typeCode.Replace("ExecuteSQL(EventHandler objMethod, string strSQLCommand)", "ExecuteSQL(EventHandler<SQLResultEventArgs> objMethod, string strSQLCommand)");
            }

            if (className == "Entry")
            {
                typeCode = typeCode.Replace("GetMetadata(EventHandler objHandler)", "GetMetadata(EventHandler<MetadataEventArgs> objHandler)");
                typeCode = typeCode.Replace("SetMetadata(MetadataDictionary objValues, EventHandler objHandler)", "SetMetadata(MetadataDictionary objValues, EventHandler<EmptyDeviceEventArgs> objHandler)");
                typeCode = typeCode.Replace("CopyTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler objCallback)", "CopyTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("MoveTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler objCallback)", "MoveTo(IDirectoryEntry objParentDirectory, string strNewName, EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("GetParent(EventHandler objCallback)", "GetParent(EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("Remove(EventHandler objCallback)", "Remove(EventHandler<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("ToUrl(EventHandler objCallback)", "ToUrl(EventHandler<ToUrlEventArgs> objCallback)");
            }

            if (className == "DirectoryEntry")
            {
                typeCode = typeCode.Replace("void IDirectoryEntry.GetFile(string strFilePath, FlagsOptions objOptions, EventHandler objCallback)", "void IDirectoryEntry.GetFile(string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("void IDirectoryEntry.GetDirectory(string strDirectoryPath, FlagsOptions objOptions, EventHandler objCallback)", "void IDirectoryEntry.GetDirectory(string strDirectoryPath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("GetDirectory(string strDirectoryPath, FlagsOptions objOptions, EventHandler objCallback)", "GetDirectory(string strDirectoryPath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("GetFile(string strFilePath, FlagsOptions objOptions, EventHandler objCallback)", "GetFile(string strFilePath, FlagsOptions objOptions, EventHandler<EntryEventArgs> objCallback)");
                typeCode = typeCode.Replace("RemoveRecursively(EventHandler objCallback)", "RemoveRecursively(EventHandler<EmptyDeviceEventArgs> objCallback)");
            }

            if (className == "FileEntry")
            {
                typeCode = typeCode.Replace("File(EventHandler objCallback)", "File(EventHandler<FileEventArgs> objCallback)");
                typeCode = typeCode.Replace("CreateWriter(EventHandler objCallback)", "CreateWriter(EventHandler<FileWriterEventArgs> objCallback)");
            }

            if (className == "DirectoryReader")
            {
                typeCode = typeCode.Replace("ReadEntries(EventHandler objCallback)", "ReadEntries(EventHandler<DirectoryReaderEventArgs> objCallback)");
            }

            if (className == "FileWriter")
            {
                typeCode = typeCode.Replace("SetAbortEvent(EventHandler objCallback)", "SetAbortEvent(EventHandler<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetErrorEvent(EventHandler objCallback)", "SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetWriteEvent(EventHandler objCallback)", "SetWriteEvent(EventHandler<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetWriteEndEvent(EventHandler objCallback)", "SetWriteEndEvent(EventHandler<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetWriteStartEvent(EventHandler objCallback)", "SetWriteStartEvent(EventHandler<EmptyDeviceEventArgs> objCallback)");
            }

            if (className == "Accelerometer")
            {
                typeCode = typeCode.Replace("public event Action AccelerationChanged", "public event Action<AccelerometerEventArgs> AccelerationChanged");
                typeCode = typeCode.Replace("void GetCurrentAcceleration(Action objCallback)", "void GetCurrentAcceleration(Action<AccelerometerEventArgs> objCallback)");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCallMethodStore", "private SingleCallMethodStore<AccelerometerEventArgs> SingleCallMethodStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> MultipleCallMethodStore", "private MultipleCallMethodStore<AccelerometerEventArgs> MultipleCallMethodStore");
            }

            if (className == "Compass")
            {
                typeCode = typeCode.Replace("public event Action HeadingChanged", "public event Action<CompassEventArgs> HeadingChanged");
                typeCode = typeCode.Replace("void GetCurrentHeading(Action objCallback)", "void GetCurrentHeading(Action<CompassEventArgs> objCallback)");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCallMethodStore", "private SingleCallMethodStore<CompassEventArgs> SingleCallMethodStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> MultipleCallMethodStore", "private MultipleCallMethodStore<CompassEventArgs> MultipleCallMethodStore");
            }

            if (className == "Geolocation")
            {
                typeCode = typeCode.Replace("public event Action PositionChanged", "public event Action<GeolocationEventArgs> PositionChanged");
                typeCode = typeCode.Replace("void GetPosition(Action objCallback)", "void GetPosition(Action<GeolocationEventArgs> objCallback)");
                typeCode = typeCode.Replace("void GetPosition(Action objCallback, PositionOptions objOptions)", "void GetPosition(Action<GeolocationEventArgs> objCallback, PositionOptions objOptions)");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCallMethodStore", "private SingleCallMethodStore<GeolocationEventArgs> SingleCallMethodStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> MultipleCallMethodStore", "private MultipleCallMethodStore<GeolocationEventArgs> MultipleCallMethodStore");
            }

            // Clean up any remaining mangled patterns
            typeCode = typeCode.Replace("List<object><object>", "List<object>");
            typeCode = typeCode.Replace("()object", "()");
            typeCode = typeCode.Replace("new List<object>()object", "new List<object>()");

            string[] eventNames = new string[] {
                "AvailableChanged", "BackColorChanged", "Click", "DisplayStyleChanged",
                "EnabledChanged", "ForeColorChanged", "LocationChanged", "OwnerChanged",
                "RightToLeftChanged", "VisibleChanged", "Enter", "GotFocus", "KeyDown",
                "KeyPress", "KeyUp", "Leave", "LostFocus", "Validated", "Validating",
                "CheckedChanged", "CheckStateChanged"
            };

            foreach (string eventName in eventNames)
            {
                typeCode = typeCode.Replace("GetHandler(" + eventName + ")", "GetHandler(" + eventName + "Event)");
                typeCode = typeCode.Replace("AddHandler(" + eventName + ",", "AddHandler(" + eventName + "Event,");
                typeCode = typeCode.Replace("RemoveHandler(" + eventName + ",", "RemoveHandler(" + eventName + "Event,");
                typeCode = typeCode.Replace("HasHandler(" + eventName + ")", "HasHandler(" + eventName + "Event)");
                typeCode = typeCode.Replace("AddCriticalHandler(" + eventName + ",", "AddCriticalHandler(" + eventName + "Event,");
                typeCode = typeCode.Replace("RemoveCriticalHandler(" + eventName + ",", "RemoveCriticalHandler(" + eventName + "Event,");
                typeCode = typeCode.Replace(eventName + " = SerializableEvent.Register", eventName + "Event = SerializableEvent.Register");
            }

            if (className == "Globalization")
            {
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCallMethodStore", "private SingleCallMethodStore<GlobalizationEventArgs> SingleCallMethodStore");
            }

            if (className == "Notifications")
            {
                typeCode = typeCode.Replace("Alert(string strMessage, AlertOptions objOptions, Action objCallback)", "Alert(string strMessage, AlertOptions objOptions, Action<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("Confirm(string strMessage, ConfirmOptions objOptions, Action objCallback)", "Confirm(string strMessage, ConfirmOptions objOptions, Action<ConfirmEventArgs> objCallback)");
                typeCode = typeCode.Replace("Beep(int intTimes, Action objCallback)", "Beep(int intTimes, Action<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("Vibrate(int intDuirationInMilliseconds, Action objCallback)", "Vibrate(int intDuirationInMilliseconds, Action<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("private Action GetNullAction()", "private Action<EmptyDeviceEventArgs> GetNullAction()");
            }

            if (className == "Capture")
            {
                typeCode = typeCode.Replace("public void CaptureAudio(AudioCaptureOptions objOptions, Action objCallback)", "public void CaptureAudio(AudioCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)");
                typeCode = typeCode.Replace("public void CaptureImage(ImageCaptureOptions objOptions, Action objCallback)", "public void CaptureImage(ImageCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)");
                typeCode = typeCode.Replace("public void CaptureVideo(VideoCaptureOptions objOptions, Action objCallback)", "public void CaptureVideo(VideoCaptureOptions objOptions, Action<CaptureEventArgs> objCallback)");
                typeCode = typeCode.Replace("private void CaptureOnline(string strCaptureType, DevicePropertyDictionary objOptions, Action objCallback)", "private void CaptureOnline(string strCaptureType, DevicePropertyDictionary objOptions, Action<CaptureEventArgs> objCallback)");
            }

            if (className == "FileTransfer")
            {
                typeCode = typeCode.Replace("Download(string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler objCallback)", "Download(string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler<FileDownloadEventArgs> objCallback)");
                typeCode = typeCode.Replace("Upload(string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler objCallback)", "Upload(string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler<FileUploadEventArgs> objCallback)");
            }

            if (className == "Contact")
            {
                typeCode = typeCode.Replace("public void Remove(EventHandler objMethod)", "public void Remove(EventHandler<EmptyDeviceEventArgs> objMethod)");
                typeCode = typeCode.Replace("public void Save(EventHandler objMethod)", "public void Save(EventHandler<SaveContactEventArgs> objMethod)");
                
                typeCode = typeCode.Replace("public IList PhoneNumbers", "public IList<ContactField> PhoneNumbers");
                typeCode = typeCode.Replace("public IList Emails", "public IList<ContactField> Emails");
                typeCode = typeCode.Replace("public IList Addresses", "public IList<ContactAddress> Addresses");
                typeCode = typeCode.Replace("public IEnumerable IMs", "public IEnumerable<ContactField> IMs");
                typeCode = typeCode.Replace("public IList Organizations", "public IList<ContactOrganization> Organizations");
                typeCode = typeCode.Replace("public IList Photos", "public IList<ContactField> Photos");
                typeCode = typeCode.Replace("public IList Categories", "public IList<ContactField> Categories");
                typeCode = typeCode.Replace("public IList URLs", "public IList<ContactField> URLs");
                
                typeCode = typeCode.Replace("private IList GetContactsCollectionProperty<T>(string strPropertyName) where T : class", "private IList<T> GetContactsCollectionProperty<T>(string strPropertyName) where T : class");
            }

            if (className == "Contacts")
            {
                typeCode = typeCode.Replace("public void FindContacts(EventHandler objMethod, ContactFindOptions objOptions)", "public void FindContacts(EventHandler<FindContactsEventArgs> objMethod, ContactFindOptions objOptions)");
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs> FindContactsCallbackStore", "internal SingleCallMethodStore<FindContactsEventArgs> FindContactsCallbackStore");
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs> RemoveContactCallbackStore", "internal SingleCallMethodStore<EmptyDeviceEventArgs> RemoveContactCallbackStore");
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs> SaveContactCallbackStore", "internal SingleCallMethodStore<SaveContactEventArgs> SaveContactCallbackStore");
            }

            if (className == "DeviceInfo")
            {
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> mobjSingleCallMethodStore;", "private SingleCallMethodStore<DeviceInfoEventArgs> mobjSingleCallMethodStore;");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCallMethodStore", "private SingleCallMethodStore<DeviceInfoEventArgs> SingleCallMethodStore");
                typeCode = typeCode.Replace("new SingleCallMethodStore<EventArgs>();", "new SingleCallMethodStore<DeviceInfoEventArgs>();");
                typeCode = typeCode.Replace("public void GetDeviceInfo(Action objCallback)", "public void GetDeviceInfo(Action<DeviceInfoEventArgs> objCallback)");
            }

            if (className == "DeviceEvents")
            {
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjBatteryCriticalEventStore;", "private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryCriticalEventStore;");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjBatteryLowEventStore;", "private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryLowEventStore;");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EmptyDeviceEventArgs> mobjBatteryStatusEventStore;", "private MultipleCallMethodStore<DeviceBatteryEventArgs> mobjBatteryStatusEventStore;");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EmptyDeviceEventArgs> BatteryCriticalEventStore", "private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryCriticalEventStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EmptyDeviceEventArgs> BatteryLowEventStore", "private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryLowEventStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EmptyDeviceEventArgs> BatteryStatusEventStore", "private MultipleCallMethodStore<DeviceBatteryEventArgs> BatteryStatusEventStore");
                typeCode = typeCode.Replace("public event Action Pause", "public event Action<EmptyDeviceEventArgs> Pause");
                typeCode = typeCode.Replace("public event Action Resume", "public event Action<EmptyDeviceEventArgs> Resume");
                typeCode = typeCode.Replace("public event Action Online", "public event Action<EmptyDeviceEventArgs> Online");
                typeCode = typeCode.Replace("public event Action Offline", "public event Action<EmptyDeviceEventArgs> Offline");
                typeCode = typeCode.Replace("public event Action BackButtonPressed", "public event Action<EmptyDeviceEventArgs> BackButtonPressed");
                typeCode = typeCode.Replace("public event Action MenuButtonPressed", "public event Action<EmptyDeviceEventArgs> MenuButtonPressed");
                typeCode = typeCode.Replace("public event Action SearchButtonPressed", "public event Action<EmptyDeviceEventArgs> SearchButtonPressed");
                typeCode = typeCode.Replace("public event Action StartCallButtonPressed", "public event Action<EmptyDeviceEventArgs> StartCallButtonPressed");
                typeCode = typeCode.Replace("public event Action EndCallButtonPressed", "public event Action<EmptyDeviceEventArgs> EndCallButtonPressed");
                typeCode = typeCode.Replace("public event Action VolumeDownButtonPressed", "public event Action<EmptyDeviceEventArgs> VolumeDownButtonPressed");
                typeCode = typeCode.Replace("public event Action VolumeUpButtonPressed", "public event Action<EmptyDeviceEventArgs> VolumeUpButtonPressed");
                typeCode = typeCode.Replace("public event Action BatteryCritical", "public event Action<DeviceBatteryEventArgs> BatteryCritical");
                typeCode = typeCode.Replace("public event Action BatteryLow", "public event Action<DeviceBatteryEventArgs> BatteryLow");
                typeCode = typeCode.Replace("public event Action BatteryStatusChanged", "public event Action<DeviceBatteryEventArgs> BatteryStatusChanged");
                typeCode = typeCode.Replace("private void RaiseDeviceEvent(EmptyDeviceEventArgs objArgs, MultipleCallMethodStore objDeviceMethodStore)", "private void RaiseDeviceEvent(EmptyDeviceEventArgs objArgs, MultipleCallMethodStore<EmptyDeviceEventArgs> objDeviceMethodStore)");
                typeCode = typeCode.Replace("private void RaiseDeviceEvent(DeviceBatteryEventArgs objArgs, MultipleCallMethodStore objBatteryMethodStore)", "private void RaiseDeviceEvent(DeviceBatteryEventArgs objArgs, MultipleCallMethodStore<DeviceBatteryEventArgs> objBatteryMethodStore)");
            }

            if (className == "DeviceMedia")
            {
                typeCode = typeCode.Replace("private Dictionary<string, MultipleCallMethodStore> mobjMediaIdPositionChangedStoreMap = new Dictionary<string, MultipleCallMethodStore>();", "private Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>> mobjMediaIdPositionChangedStoreMap = new Dictionary<string, MultipleCallMethodStore<MediaPositionEventArgs>>();");
                typeCode = typeCode.Replace("internal SingleCallMethodStore<EventArgs> MediaPositionEventArgsStore", "internal SingleCallMethodStore<MediaPositionEventArgs> MediaPositionEventArgsStore");
                typeCode = typeCode.Replace("private MultipleCallMethodStore<EventArgs> GetPositionChangedStore(Media objMedia)", "private MultipleCallMethodStore<MediaPositionEventArgs> GetPositionChangedStore(Media objMedia)");
                typeCode = typeCode.Replace("MultipleCallMethodStore value = null;", "MultipleCallMethodStore<MediaPositionEventArgs> value = null;");
                typeCode = typeCode.Replace("MultipleCallMethodStore positionChangedStore = GetPositionChangedStore(objMedia);", "MultipleCallMethodStore<MediaPositionEventArgs> positionChangedStore = GetPositionChangedStore(objMedia);");
                typeCode = typeCode.Replace("foreach (MultipleCallMethodStore value in mobjMediaIdPositionChangedStoreMap.Values)", "foreach (MultipleCallMethodStore<MediaPositionEventArgs> value in mobjMediaIdPositionChangedStoreMap.Values)");
            }

            if (className == "FileManager")
            {
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> FileDownloadEventArgsStore", "internal SingleCallMethodStore<FileDownloadEventArgs> FileDownloadEventArgsStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> EmptyArgsStore", "internal SingleCallMethodStore<EmptyDeviceEventArgs> EmptyArgsStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> EntryEventArgsStore", "private SingleCallMethodStore<EntryEventArgs> EntryEventArgsStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> FileUploadEventArgsStore", "private SingleCallMethodStore<FileUploadEventArgs> FileUploadEventArgsStore");
                
                typeCode = typeCode.Replace("Download(FileTransfer objFileTransfer, string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler objCallback)", "Download(FileTransfer objFileTransfer, string strSourceUrl, string strDestinationFileFullPath, bool blnTrustAllHosts, EventHandler<FileDownloadEventArgs> objCallback)");
                typeCode = typeCode.Replace("Upload(FileTransfer objFileTransfer, string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler objCallback)", "Upload(FileTransfer objFileTransfer, string strFullFilePath, string strUploadUrl, FileUploadOptions objOptions, bool blnTrustAllHosts, EventHandler<FileUploadEventArgs> objCallback)");
                typeCode = typeCode.Replace("ResolveLocalFileSystemURI(string strFileUri, Action objCallback)", "ResolveLocalFileSystemURI(string strFileUri, Action<EntryEventArgs> objCallback)");
            }

            if (className == "DockedWindowsCollection")
            {
                typeCode = typeCode.Replace("public int Count => mobjWindowsIndexByWindowName.Count;", @"public int Count => mobjWindowsIndexByWindowName.Count;
        void ICollection.CopyTo(Array array, int index) { ((ICollection)mobjWindowsIndexByWindowName.Values).CopyTo(array, index); }
        bool ICollection.IsSynchronized => false;
        object ICollection.SyncRoot => ((ICollection)mobjWindowsIndexByWindowName.Values).SyncRoot;");
                typeCode = typeCode.Replace("public class DockedWindowsCollection : ICollection, IEnumerable, IEnumerable", "public class DockedWindowsCollection : ICollection, IEnumerable");
            }

            if (className == "FileReader")
            {
                typeCode = typeCode.Replace("SetAbortEvent(EventHandler objCallback)", "SetAbortEvent(EventHandler<FileReaderEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetErrorEvent(EventHandler objCallback)", "SetErrorEvent(EventHandler<FileReaderEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetLoadStartEvent(EventHandler objCallback)", "SetLoadStartEvent(EventHandler<FileReaderEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetLoadEvent(EventHandler objCallback)", "SetLoadEvent(EventHandler<FileReaderEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetLoadEndEvent(EventHandler objCallback)", "SetLoadEndEvent(EventHandler<FileReaderEventArgs> objCallback)");
                
                typeCode = typeCode.Replace("private EventHandler mobjAbortCallback;", "private EventHandler<FileReaderEventArgs> mobjAbortCallback;");
                typeCode = typeCode.Replace("private EventHandler mobjErrorCallback;", "private EventHandler<FileReaderEventArgs> mobjErrorCallback;");
                typeCode = typeCode.Replace("private EventHandler mobjLoadEndCallback;", "private EventHandler<FileReaderEventArgs> mobjLoadEndCallback;");
                typeCode = typeCode.Replace("private EventHandler mobjLoadCallback;", "private EventHandler<FileReaderEventArgs> mobjLoadCallback;");
                typeCode = typeCode.Replace("private EventHandler mobjLoadStartCallback;", "private EventHandler<FileReaderEventArgs> mobjLoadStartCallback;");
            }

            if (className == "Globalization")
            {
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleDateCallMethodStore", "private SingleCallMethodStore<GlobalizationDateEventArgs> SingleDateCallMethodStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleDatePatternCallMethodStore", "private SingleCallMethodStore<GlobalizationDatePatternEventArgs> SingleDatePatternCallMethodStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleNumberCallMethodStore", "private SingleCallMethodStore<GlobalizationNumberPatternEventArgs> SingleNumberCallMethodStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleCurrencyCallMethodStore", "private SingleCallMethodStore<GlobalizationCurrencyPatternEventArgs> SingleCurrencyCallMethodStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleListCallMethodStore", "private SingleCallMethodStore<GlobalizationListEventArgs> SingleListCallMethodStore");
                typeCode = typeCode.Replace("private SingleCallMethodStore<EventArgs> SingleInfoCallMethodStore", "private SingleCallMethodStore<GlobalizationInfoEventArgs> SingleInfoCallMethodStore");

                typeCode = typeCode.Replace("getGlobalizationInfo(Action objCallback)", "getGlobalizationInfo(Action<GlobalizationInfoEventArgs> objCallback)");
                typeCode = typeCode.Replace("dateToString(DateTime objDateTime, Action objCallback, GlobalizationDateOptions objOptions)", "dateToString(DateTime objDateTime, Action<GlobalizationEventArgs> objCallback, GlobalizationDateOptions objOptions)");
                typeCode = typeCode.Replace("stringToDate(string strStringInput, Action objCallback, GlobalizationDateOptions objOptions)", "stringToDate(string strStringInput, Action<GlobalizationDateEventArgs> objCallback, GlobalizationDateOptions objOptions)");
                typeCode = typeCode.Replace("getDatePattern(Action objCallback, GlobalizationDateOptions objOptions)", "getDatePattern(Action<GlobalizationDatePatternEventArgs> objCallback, GlobalizationDateOptions objOptions)");
                typeCode = typeCode.Replace("getDateNames(Action objCallback, GlobalizationDateNameOptions objOptions)", "getDateNames(Action<GlobalizationListEventArgs> objCallback, GlobalizationDateNameOptions objOptions)");
                typeCode = typeCode.Replace("isDayLightSavingsTime(DateTime objDateTime, Action objCallback)", "isDayLightSavingsTime(DateTime objDateTime, Action<GlobalizationEventArgs> objCallback)");
                typeCode = typeCode.Replace("numberToString(double dblNumber, Action objCallback, GlobalizationNumberOptions objOptions)", "numberToString(double dblNumber, Action<GlobalizationEventArgs> objCallback, GlobalizationNumberOptions objOptions)");
                typeCode = typeCode.Replace("stringToNumber(string strStringInput, Action objCallback, GlobalizationNumberOptions objOptions)", "stringToNumber(string strStringInput, Action<GlobalizationEventArgs> objCallback, GlobalizationNumberOptions objOptions)");
                typeCode = typeCode.Replace("getNumberPattern(Action objCallback, GlobalizationNumberOptions objOptions)", "getNumberPattern(Action<GlobalizationNumberPatternEventArgs> objCallback, GlobalizationNumberOptions objOptions)");
                typeCode = typeCode.Replace("getCurrencyPattern(string strCurrencyCode, Action objCallback)", "getCurrencyPattern(string strCurrencyCode, Action<GlobalizationCurrencyPatternEventArgs> objCallback)");
            }

            if (className == "Media")
            {
                typeCode = typeCode.Replace("private EventHandler mobjSuccessCallback;", "private EventHandler<MediaEventArgs> mobjSuccessCallback;");
                typeCode = typeCode.Replace("private EventHandler mobjErrorCallback;", "private EventHandler<EmptyDeviceEventArgs> mobjErrorCallback;");
                typeCode = typeCode.Replace("private EventHandler mobjMediaStateCallback;", "private EventHandler<MediaStateEventArgs> mobjMediaStateCallback;");
                typeCode = typeCode.Replace("public event Action PositionChanged", "public event Action<MediaPositionEventArgs> PositionChanged");
                typeCode = typeCode.Replace("GetCurrentPosition(EventHandler objCallback)", "GetCurrentPosition(EventHandler<MediaPositionEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetSuccessEvent(EventHandler objCallback)", "SetSuccessEvent(EventHandler<MediaEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetErrorEvent(EventHandler objCallback)", "SetErrorEvent(EventHandler<EmptyDeviceEventArgs> objCallback)");
                typeCode = typeCode.Replace("SetStateChangeEvent(EventHandler objCallback)", "SetStateChangeEvent(EventHandler<MediaStateEventArgs> objCallback)");
            }

            if (className == "MediaFile")
            {
                typeCode = typeCode.Replace("GetFormatData(EventHandler objCallback)", "GetFormatData(EventHandler<MediaFileDataEventArgs> objCallback)");
            }

            if (className == "DockingWindowName")
            {
                typeCode = typeCode.Replace("private class DockedWindowNameComparer : IEqualityComparer", "private class DockedWindowNameComparer : IEqualityComparer<DockingWindowName>");
                typeCode = typeCode.Replace("internal static IEqualityComparer DockedWindowNameEqulityComparer", "internal static IEqualityComparer<DockingWindowName> DockedWindowNameEqulityComparer");
            }

            if (className == "NumericUpDownAccelerationCollection")
            {
                // Fix for missing ICollection members
                typeCode = typeCode.Replace("public int Count => 0;", @"public int Count => 0;
        public void CopyTo(Array array, int index) { }");
            }

            if (className == "LocalStorage")
            {
                typeCode = typeCode.Replace("Clear(EventHandler objMethod)", "Clear(EventHandler<LocalStorageEventArgs> objMethod)");
                typeCode = typeCode.Replace("Key(EventHandler objMethod", "Key(EventHandler<LocalStorageEventArgs> objMethod");
                typeCode = typeCode.Replace("GetItem(EventHandler objMethod", "GetItem(EventHandler<LocalStorageEventArgs> objMethod");
                typeCode = typeCode.Replace("SetItem(EventHandler objMethod", "SetItem(EventHandler<LocalStorageEventArgs> objMethod");
                typeCode = typeCode.Replace("RemoveItem(EventHandler objMethod", "RemoveItem(EventHandler<LocalStorageEventArgs> objMethod");
            }

            if (className == "ZoneDescriptor")
            {
                typeCode = typeCode.Replace("internal override T CloneWithoutReferences()", "internal override T CloneWithoutReferences<T>()");
            }

            string file = Path.Combine(dir, className + ".cs");
            typeCode = typeCode.Trim();
            if (!string.IsNullOrEmpty(nsName))
            {
                File.WriteAllText(file, usings + "\n\nnamespace " + nsName + "\n{\n" + typeCode + "\n}\n");
            }
            else
            {
                File.WriteAllText(file, usings + "\n\n" + typeCode + "\n");
            }
            count++;
        }

        var allDelegates = root.DescendantNodes().OfType<DelegateDeclarationSyntax>()
            .Where(t => t.Parent is NamespaceDeclarationSyntax || t.Parent is CompilationUnitSyntax);

        foreach (var del in allDelegates)
        {
            string className = del.Identifier.Text;
            if (del.TypeParameterList != null && del.TypeParameterList.Parameters.Count > 0)
            {
                className += "`" + del.TypeParameterList.Parameters.Count;
            }

            string nsName = GetNamespace(del);
            string dir = outDir;
            if (!string.IsNullOrEmpty(nsName))
            {
                dir = Path.Combine(outDir, nsName.Replace(".", "\\"));
            }
            else
            {
                dir = Path.Combine(outDir, "Global");
            }
            Directory.CreateDirectory(dir);

            string file = Path.Combine(dir, className + ".cs");
            if (!string.IsNullOrEmpty(nsName))
            {
                File.WriteAllText(file, usings + "\n\nnamespace " + nsName + "\n{\n" + del.ToFullString() + "}\n");
            }
            else
            {
                File.WriteAllText(file, usings + "\n\n" + del.ToFullString() + "\n");
            }
            count++;
        }

        Console.WriteLine($"Successfully extracted {count} types to {outDir}");
    }

    static string GetNamespace(SyntaxNode node)
    {
        var namespaceDeclaration = node.Ancestors().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
        return namespaceDeclaration?.Name.ToString() ?? "";
    }
}
