using InterfaceGenerator;

namespace MuNeMo.Scripting;

[GenerateAutoInterface]
public class ShellScriptRepository : IShellScriptRepository
{
    private const string SCRIPT_DIRECTORY = "./ShellScripts";

    public List<ShellScriptCall> GetShellScripts()
    {
        var shellscripts = Directory.GetFiles(SCRIPT_DIRECTORY);
        
        return shellscripts.Select(scriptFilePath =>
        {
            var scriptContent = File.ReadAllLines(scriptFilePath);
            return ShellScriptCall.CreateFromScript(scriptFilePath, scriptContent);
        }).ToList();
    }
    
}