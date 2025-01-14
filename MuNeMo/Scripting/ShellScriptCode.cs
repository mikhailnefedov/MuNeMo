namespace MuNeMo.Scripting;

public class ShellScriptCode : IScript
{
    public string Content { get; set; }
    
    public string ToExecutableScript()
    {
        return Content;
    }
}