namespace CrossoutLogadon;

using System;
using System.IO;

public class LogSession : IComparable<LogSession>
{
    public string folderName;
    public DateTime startTime;
    string location;

    public LogSession(string name, string location)
    {
        this.folderName = name;
        this.location = location;
        startTime = DateTime.ParseExact(name, "yyyy.MM.dd HH.mm.ss", null);
    }

    public string ReadContent()
    {
        string filePath = Path.Combine(location, folderName, "combat.log");
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                throw new FileNotFoundException("Файл не найден", filePath);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions such as file not found, access denied, etc.
            throw new IOException("Ошибка при чтении файла", ex);
        }
    }

    public int CompareTo(LogSession? other)
    {
        if (other == null)
        {
            return 1;
        }

        return startTime.CompareTo(other.startTime);
    }
}
