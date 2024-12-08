namespace CrossoutLogadon;

using System;
using System.IO;

public class LogWriter
{
    string folderPath;
    const string fileName = "combat.log";
    string path;

    public LogWriter(string folderPath)
    {
        this.folderPath = folderPath;
        path = Path.Combine(folderPath, fileName);

        // Удаляем файл, если он существует
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        // Создаем файл
        File.Create(path).Dispose();
    }

    public void Write(string logPart)
    {
        // Добавляем строку в файл
        File.AppendAllText(path, logPart + Environment.NewLine);
    }
}
