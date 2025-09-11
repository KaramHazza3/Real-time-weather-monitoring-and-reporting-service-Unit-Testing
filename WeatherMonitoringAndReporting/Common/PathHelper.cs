namespace WeatherMonitoringAndReporting.Common;

public static class PathHelper
{
    private static string FindProjectPath()
    {
        var current = Directory.GetCurrentDirectory();
        while (current != null && !File.Exists(Path.Combine(current, "Program.cs")))
        {
            current = Directory.GetParent(current)?.FullName;
        }
        return current!;
    }

    public static string GetFullPath(string fileName)
    {
        return Path.Combine(FindProjectPath(), fileName);
    }
}