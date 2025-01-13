using InterfaceGenerator;

namespace MuNeMo.Scripting;

[GenerateAutoInterface]
public class ShellScriptRepository : IShellScriptRepository
{
    private const string SCRIPT_DIRECTORY = "./ShellScripts";

    public List<ShellScript> GetShellScripts()
    {
        var shellscripts = Directory.GetFiles(SCRIPT_DIRECTORY);
        
        return shellscripts.Select(scriptFilePath =>
        {
            var scriptContent = File.ReadAllLines(scriptFilePath);
            return ShellScript.CreateFromScript(scriptFilePath, scriptContent);
        }).ToList();
    }
    
}