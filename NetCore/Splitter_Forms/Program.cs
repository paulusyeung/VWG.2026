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
        code = Regex.Replace(code, @"\bReadOnlyCollectionGen_\b", "ReadOnlyCollection<object>");
        code = Regex.Replace(code, @"\bListGen_\b", "List<object>");
        code = Regex.Replace(code, @"\bICollectionGen_\b", "ICollection<object>");
        code = Regex.Replace(code, @"\bQueueGen_\b", "Queue<object>");

        // Fix class X where Y : Z -> class X<Y> where Y : Z (constraint without type param)
        code = Regex.Replace(code, @"\bclass\s+(\w+)\s+where\s+(\w+)\s*:", "class $1<$2> where $2 :");

        // BidirectionalSkinValue/BidirectionalSkinProperty used without type arg (ILSpy loses generic info)
        code = Regex.Replace(code, @"\bBidirectionalSkinValue(?!\s*<|Converter)", "BidirectionalSkinValue<object>");
        code = Regex.Replace(code, @"\bBidirectionalSkinProperty(?!\s*<|Converter)", "BidirectionalSkinProperty<object>");

        // List used without type arg
        code = Regex.Replace(code, @"\bnew List\(\)", "new List<object>()");
        code = Regex.Replace(code, @"(?<=[^\w])List\s+([a-zA-Z_])", "List<object> $1");

        // Generic method T GetProxyPropertyValue(string, T) -> T GetProxyPropertyValue<T>(string, T)
        code = Regex.Replace(code, @"(\s)T GetProxyPropertyValue\s*\(\s*string\s+strPropertyName\s*,\s*T\s+", "$1T GetProxyPropertyValue<T>(string strPropertyName, T ");

        // FireEvent: base is protected, override must not widen - change public to protected
        code = Regex.Replace(code, @"public override void FireEvent\(IEvent objEvent\)", "protected override void FireEvent(IEvent objEvent)");

        // AdministrationContentSorter: IComparer needs Compare(object?, object?) - use IComparer<AdministrationContent> instead
        code = Regex.Replace(code, @"public class AdministrationContentSorter : IComparer\b", "public class AdministrationContentSorter : IComparer<AdministrationContent>");

        // ObservableCollection, UniqueObservableCollection without type arg
        code = Regex.Replace(code, @"\bObservableCollection(?!\s*<)", "ObservableCollection<object>");
        code = Regex.Replace(code, @"\bUniqueObservableCollection(?!\s*<)", "UniqueObservableCollection<object>");

        // Method with constraint but no generic param: TContextType GetContaxt(...) where TContextType : class
        code = Regex.Replace(code, @"internal TContextType GetContaxt\s*\(\s*string\s+strMethodKey\s*\)\s+where TContextType : class", "internal TContextType GetContaxt<TContextType>(string strMethodKey) where TContextType : class");

        // IArrangedElement: T GetValue/SetValue need generic method (interface and explicit impl)
        code = Regex.Replace(code, @"\bT GetValue\s*\(\s*SerializableProperty\s+", "T GetValue<T>(SerializableProperty ");
        code = Regex.Replace(code, @"void SetValue\s*\(\s*SerializableProperty\s+objSerializableProperty\s*,\s*T\s+objValue\s*\)", "void SetValue<T>(SerializableProperty objSerializableProperty, T objValue)");
        code = Regex.Replace(code, @"T IArrangedElement\.GetValue\s*\(\s*SerializableProperty\s+", "T IArrangedElement.GetValue<T>(SerializableProperty ");
        code = Regex.Replace(code, @"void IArrangedElement\.SetValue\s*\(\s*SerializableProperty\s+objSerializableProperty\s*,\s*T\s+objValue\s*\)", "void IArrangedElement.SetValue<T>(SerializableProperty objSerializableProperty, T objValue)");

        // ListBox.ObjectCollectionComparer: IComparer -> IComparer<ListBox.ListBoxItem>
        code = Regex.Replace(code, @"ObjectCollectionComparer : IComparer\b", "ObjectCollectionComparer : IComparer<ListBox.ListBoxItem>");

        Console.WriteLine("Parsing syntax tree...");
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        string usings = string.Join("\n", root.Usings.Select(u => u.ToFullString().TrimEnd()));

        if (Directory.Exists(outDir)) Directory.Delete(outDir, true);
        Directory.CreateDirectory(Path.Combine(outDir, "Global"));
        
        int count = 0;

        foreach (var member in root.Members)
        {
            if (member is NamespaceDeclarationSyntax ns)
            {
                string nsName = ns.Name.ToString();
                string dir = Path.Combine(outDir, nsName.Replace(".", "\\"));
                Directory.CreateDirectory(dir);

                foreach (var type in ns.Members.OfType<BaseTypeDeclarationSyntax>())
                {
                    string className = type.Identifier.Text;
                    var typeDecl = type as TypeDeclarationSyntax;
                    if (typeDecl != null && typeDecl.TypeParameterList != null && typeDecl.TypeParameterList.Parameters.Count > 0)
                    {
                        className += "`" + typeDecl.TypeParameterList.Parameters.Count;
                    }

                    string file = Path.Combine(dir, className + ".cs");
                    File.WriteAllText(file, usings + "\n\nnamespace " + nsName + "\n{\n" + type.ToFullString() + "}\n");
                    count++;
                }
                
                foreach (var del in ns.Members.OfType<DelegateDeclarationSyntax>())
                {
                    string className = del.Identifier.Text;
                    if (del.TypeParameterList != null && del.TypeParameterList.Parameters.Count > 0)
                    {
                        className += "`" + del.TypeParameterList.Parameters.Count;
                    }

                    string file = Path.Combine(dir, className + ".cs");
                    File.WriteAllText(file, usings + "\n\nnamespace " + nsName + "\n{\n" + del.ToFullString() + "}\n");
                    count++;
                }
            }
            else if (member is BaseTypeDeclarationSyntax type)
            {
                string className = type.Identifier.Text;
                var typeDecl = type as TypeDeclarationSyntax;
                if (typeDecl != null && typeDecl.TypeParameterList != null && typeDecl.TypeParameterList.Parameters.Count > 0)
                {
                    className += "`" + typeDecl.TypeParameterList.Parameters.Count;
                }

                string file = Path.Combine(outDir, "Global", className + ".cs");
                File.WriteAllText(file, usings + "\n\n" + type.ToFullString());
                count++;
            }
            else if (member is DelegateDeclarationSyntax del)
            {
                string className = del.Identifier.Text;
                if (del.TypeParameterList != null && del.TypeParameterList.Parameters.Count > 0)
                {
                    className += "`" + del.TypeParameterList.Parameters.Count;
                }

                string file = Path.Combine(outDir, "Global", className + ".cs");
                File.WriteAllText(file, usings + "\n\n" + del.ToFullString());
                count++;
            }
        }
        
        Console.WriteLine($"Successfully extracted {count} types to {outDir}");
    }
}
