using System.Text.RegularExpressions;

namespace MuNeMo.Scripting;

public class ShellScript : IScript
{
    public string Name { get; set; }

    public Dictionary<string, string> ParameterDescriptions { get; set; } = [];

    public static ShellScript CreateFromScript(string fileName, string[] scriptContentLines)
    {
        ShellScript script = new ShellScript()
        {
            Name = fileName
        };
        var regex = new Regex(@"##\s*(\w+)\s*:\s*(.+)");

        foreach (var line in scriptContentLines)
        {
            var match = regex.Match(line);
            if (match.Success)
            {
                string key = match.Groups[1].Value;
                string description = match.Groups[2].Value;
                script.ParameterDescriptions[key] = description;
            }
        }
        return script;
    }
    
    public string ToExecutableScript()
    {
        throw new NotImplementedException();
    }
}