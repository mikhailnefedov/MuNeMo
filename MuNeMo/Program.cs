using System.Diagnostics;

try
{
    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "jq",
        Arguments = "--version",
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    using (Process process = Process.Start(psi))
    {
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        Console.WriteLine($"jq is installed: {output}");
    }
}
catch (Exception)
{
    Console.WriteLine("jq doesn't seem to be installed.");
}

string directoryPath = Directory.GetCurrentDirectory();
var searchText = "Freezing";
var replaceText = "Raining";

foreach (var file in Directory.GetFiles(directoryPath,"*.*", SearchOption.AllDirectories))
{
    string content = File.ReadAllText(file);
    if (content.Contains(searchText))
    {
        content = content.Replace(searchText, replaceText);
        File.WriteAllText(file, content);
        Console.WriteLine($"Updated: {file}");
    }
}
