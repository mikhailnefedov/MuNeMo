using System.Text.RegularExpressions;

namespace MuNeMo.Scripting;

public class ShellScript : IScript
{
    public string Name { get; set; }

    public string Path { get; set; }

    
    public Dictionary<string, ParameterData> Parameters { get; set; } = new();

    public static ShellScript CreateFromScript(string filePath, string[] scriptContentLines)
    {
        ShellScript script = new ShellScript
        {
            Name = filePath.Split("\\").Last(),
            Path = filePath
        };
        var regex = new Regex(@"##\s*(\w+)\s*:\s*(.+)");

        foreach (var line in scriptContentLines)
        {
            var match = regex.Match(line);
            if (match.Success)
            {
                string key = match.Groups[1].Value;
                string description = match.Groups[2].Value;
                script.Parameters[key] = new ParameterData
                {
                    Description = description,
                    Value = ""
                };
            }
        }
        return script;
    }
    
    public string ToExecutableScript()
    {
        throw new NotImplementedException();
    }
}

public record ParameterData
{
    /// <summary>
    /// Description of argument.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Value of argument.
    /// </summary>
    public string Value { get; set; }
}