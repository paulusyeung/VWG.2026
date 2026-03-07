using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string logPath = @"c:\Projects\VWG\NetCore\Gizmox.WebGUI.Forms\build.log";
        if (!File.Exists(logPath)) {
            Console.WriteLine("Log not found: " + logPath);
            return;
        }

        string log = File.ReadAllText(logPath);
        var matches = Regex.Matches(log, @"\)\: error (CS\d+)\:");
        var errors = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToList();
        
        Console.WriteLine($"Total Errors: {errors.Count}");
        
        var groups = errors.GroupBy(e => e)
                           .Select(g => new { Error = g.Key, Count = g.Count() })
                           .OrderByDescending(g => g.Count);
                           
        foreach (var g in groups)
        {
            Console.WriteLine($"{g.Count,5} : {g.Error}");
        }
        
        Console.WriteLine("\nTop CS0234 (Missing Namespaces) Examples:");
        var missingNamespaces = Regex.Matches(log, @"error CS0234: The type or namespace name '([^']+)' does not exist in the namespace '([^']+)'")
                                     .Cast<Match>()
                                     .Select(m => m.Groups[1].Value + " in " + m.Groups[2].Value)
                                     .GroupBy(x => x)
                                     .Select(g => new { Name = g.Key, Count = g.Count() })
                                     .OrderByDescending(g => g.Count)
                                     .Take(25);
                                     
        foreach (var g in missingNamespaces)
        {
            Console.WriteLine($"{g.Count,5} : {g.Name}");
        }
        
        Console.WriteLine("\nTop CS0246 (Type Not Found) Examples:");
        var missingTypes = Regex.Matches(log, @"error CS0246: The type or namespace name '([^']+)' could not be found")
                                     .Cast<Match>()
                                     .Select(m => m.Groups[1].Value)
                                     .GroupBy(x => x)
                                     .Select(g => new { Name = g.Key, Count = g.Count() })
                                     .OrderByDescending(g => g.Count)
                                     .Take(25);
                                     
        foreach (var g in missingTypes)
        {
            Console.WriteLine($"{g.Count,5} : {g.Name}");
        }
    }
}
