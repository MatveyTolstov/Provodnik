using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.IO;

namespace проводник
{
    internal class Program
    {

        static void Main()
        {
            Console.BufferHeight = 150;
            #region выбор диска
            Console.WriteLine("Выберите диск");
            List<string> disk = new List<string>() { "C:\\", "D:\\", "E:\\" };
            foreach (var dis in disk)
            {
                DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(dis));

                Console.WriteLine($"  {dis}Свободное место на диске: {driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");

            }
            int pos = Str.Show(1, 3, 1);
            switch (pos)
            {
                case 1:
                    ShowPapka("C:\\");

                    break;
                case 2:
                    ShowPapka("D:\\");
                    break;
                case 3:
                    ShowPapka("E:\\");
                    break;
            }
        }
        #endregion
        static void ShowPapka(string s)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"                                                               {s}                                   ");
                Console.WriteLine("________________________________________________________________________________________________________________________");
                string[] paths = Directory.GetDirectories(s);
                for (int i = paths.Length - 1; i >= 0; i--)
                {
                    string path = paths[i];
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    Console.SetCursorPosition(0, 2 + i);
                    Console.Write("  " + path);
                    Console.SetCursorPosition(50, 2 + i);
                    Console.Write(directoryInfo.CreationTime);
                    Console.SetCursorPosition(80, 2 + i);
                    Console.WriteLine(directoryInfo.Extension);
                }
                string[] files = Directory.GetFiles(s);
                for (int i = 0; i < files.Length; i++)
                {
                    string file = files[i];
                    FileInfo fileInfo = new FileInfo(file);
                    Console.Write("   " + file);

                }
                int pos = Str.Show(2, paths.Length + files.Length+1, 2);
                if (pos != -1)
                {
                    if (pos-2 < paths.Length)
                    {
                        ShowPapka(paths[pos-2]);
                    }
                    else
                    {
                        Process.Start(new ProcessStartInfo { FileName = files[paths.Length], UseShellExecute = true });
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}