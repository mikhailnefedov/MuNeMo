using System.Text;
using System.Text.RegularExpressions;

namespace MuNeMo.Scripting;

public class ShellScriptCall : IScript
{
    public string Name { get; set; }

    public string Path { get; set; }

    
    public Dictionary<string, ParameterData> Parameters { get; set; } = new();

    public static ShellScriptCall CreateFromScript(string filePath, string[] scriptContentLines)
    {
        ShellScriptCall scriptCall = new ShellScriptCall
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
                scriptCall.Parameters[key] = new ParameterData
                {
                    Description = description,
                    Value = ""
                };
            }
        }
        return scriptCall;
    }
    
    public string ToExecutableScript()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(Path);
        foreach (var parameter in Parameters)
        {
            stringBuilder.Append($" {parameter.Value.Value}");
        }

        return stringBuilder.ToString();
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