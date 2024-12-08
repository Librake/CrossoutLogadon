using System.Diagnostics;

namespace CrossoutLogadon;
public class LogStorage
{
    private string LogsFolderPath;
    private string CrossoutLogs = "\\My Games\\Crossout\\logs";
    public List<LogSession> logs = new List<LogSession>();

    public LogStorage()
    {
        LogsFolderPath = GetDocumentsPath() + CrossoutLogs;


        foreach (string folder in GetSubDirectoriesList())
            logs.Add(new LogSession(folder, LogsFolderPath));

        logs.Sort();

        foreach (LogSession log in logs)
            Debug.WriteLine(log.folderName);

    }

    static string GetDocumentsPath()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    public List<string> GetSubDirectoriesList()
    {
        List<string> directories = new List<string>();

        try
        {
            string[] subDirectories = Directory.GetDirectories(LogsFolderPath);
            foreach (string dir in subDirectories)
            {
                directories.Add(Path.GetFileName(dir));
            }
        }
        catch (Exception ex)
        {
            // Логгируем или обрабатываем исключения
            Debug.WriteLine($"Error: {ex.Message}");
        }

        return directories;
    }
}
