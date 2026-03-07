using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

class Program
{
    static void Main(string[] args)
    {
        // From bin/Release/net8.0/ go up to Client project root (4 levels)
        string baseDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".."));
        string filePath = Path.Combine(baseDir, "Gizmox.WebGUI.Client.decompiled.cs");
        string outDir = Path.Combine(baseDir, "Generated");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        Console.WriteLine("Reading " + filePath);
        string code = File.ReadAllText(filePath);

        // Strip assembly attributes (SDK auto-generates; they cause CS0579)
        code = System.Text.RegularExpressions.Regex.Replace(code, @"\[assembly:[^\]]+\]\s*", "");

        // ILSpy artifact cleanup
        Console.WriteLine("Cleaning artifacts...");
        code = code.Replace("Gen_<", "<").Replace("Gen_(", "(");
        code = System.Text.RegularExpressions.Regex.Replace(code, @"\bReadOnlyCollectionGen_\b", "ReadOnlyCollection<object>");
        code = System.Text.RegularExpressions.Regex.Replace(code, @"\bListGen_\b", "List<object>");
        code = System.Text.RegularExpressions.Regex.Replace(code, @"\bICollectionGen_\b", "ICollection<object>");
        code = System.Text.RegularExpressions.Regex.Replace(code, @"\bQueueGen_\b", "Queue<IEvent>");
        code = System.Text.RegularExpressions.Regex.Replace(code, @"CreateFormGen_", "CreateForm");

        Console.WriteLine("Parsing syntax tree...");
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        var errors = root.SyntaxTree.GetDiagnostics().Where(d => d.Severity == DiagnosticSeverity.Error).ToList();
        if (errors.Count > 0)
        {
            Console.WriteLine($"Parse errors: {errors.Count}");
            foreach (var e in errors.Take(10))
                Console.WriteLine("  " + e);
            return;
        }

        string usings = string.Join("\n", root.Usings.Select(u => u.ToFullString().TrimEnd()));

        if (Directory.Exists(outDir)) Directory.Delete(outDir, true);
        Directory.CreateDirectory(Path.Combine(outDir, "Global"));

        int count = 0;

        foreach (var member in root.Members)
        {
            if (member is NamespaceDeclarationSyntax ns)
            {
                string nsName = ns.Name.ToString();
                string dir = Path.Combine(outDir, nsName.Replace(".", Path.DirectorySeparatorChar.ToString()));
                Directory.CreateDirectory(dir);

                foreach (var type in ns.Members.OfType<BaseTypeDeclarationSyntax>())
                {
                    string className = type.Identifier.Text;
                    var typeDecl = type as TypeDeclarationSyntax;
                    if (typeDecl?.TypeParameterList != null && typeDecl.TypeParameterList.Parameters.Count > 0)
                        className += "`" + typeDecl.TypeParameterList.Parameters.Count;

                    string file = Path.Combine(dir, className + ".cs");
                    File.WriteAllText(file, usings + "\n\nnamespace " + nsName + "\n{\n" + type.ToFullString() + "}\n");
                    count++;
                }

                foreach (var del in ns.Members.OfType<DelegateDeclarationSyntax>())
                {
                    string className = del.Identifier.Text;
                    if (del.TypeParameterList != null && del.TypeParameterList.Parameters.Count > 0)
                        className += "`" + del.TypeParameterList.Parameters.Count;

                    string file = Path.Combine(dir, className + ".cs");
                    File.WriteAllText(file, usings + "\n\nnamespace " + nsName + "\n{\n" + del.ToFullString() + "}\n");
                    count++;
                }
            }
            else if (member is BaseTypeDeclarationSyntax type)
            {
                string className = type.Identifier.Text;
                var typeDecl = type as TypeDeclarationSyntax;
                if (typeDecl?.TypeParameterList != null && typeDecl.TypeParameterList.Parameters.Count > 0)
                    className += "`" + typeDecl.TypeParameterList.Parameters.Count;

                string file = Path.Combine(outDir, "Global", className + ".cs");
                File.WriteAllText(file, usings + "\n\n" + type.ToFullString());
                count++;
            }
            else if (member is DelegateDeclarationSyntax del)
            {
                string className = del.Identifier.Text;
                if (del.TypeParameterList != null && del.TypeParameterList.Parameters.Count > 0)
                    className += "`" + del.TypeParameterList.Parameters.Count;

                string file = Path.Combine(outDir, "Global", className + ".cs");
                File.WriteAllText(file, usings + "\n\n" + del.ToFullString());
                count++;
            }
        }

        Console.WriteLine($"Extracted {count} types to {outDir}");
    }
}
