
using System.Diagnostics;
namespace Prakticheskaya7
{
    internal class ProvodnikClass
    {
        public static string CottonField = "";
        public static int Otstup = 0;
        public static List<string> list = new List<string>();
        public static int Skoka = 0;
        public static void Start()
        {
            Console.WriteLine("                                                      Проводильник по нулям и единицам");
            Console.WriteLine("  -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            List<string> NapolnenieList = new List<string>();
            string[] Drives = new string[] { };
            string[] Files = new string[] { };

            if (ProvodnikClass.CottonField != "")
            {
                Drives = Directory.GetDirectories(ProvodnikClass.CottonField);
                Files = Directory.GetFiles(ProvodnikClass.CottonField);
                foreach (string n in Drives)
                {
                    NapolnenieList.Add(n);
                }
                foreach (string j in Files)
                {
                    NapolnenieList.Add(j);
                }
                foreach (string file in NapolnenieList)
                {
                    Console.WriteLine("  " + file + "............. Создан: " + File.GetCreationTime(file));
                    list.Add(file);
                    if (ProvodnikClass.Skoka == 0)
                    {
                        ProvodnikClass.Otstup = ProvodnikClass.Otstup + 1;
                    }
                }
            }

            else if (ProvodnikClass.CottonField == "")
            {
                Drives = Environment.GetLogicalDrives();
                foreach (string n in Drives)
                {
                    list.Add(n);
                }
                foreach (var file in DriveInfo.GetDrives())
                {
                    try
                    {
                        Console.WriteLine("  " + file.Name + "..................... " + "Свободно " + (file.AvailableFreeSpace / 1073741824) + " ГБ из " + (file.TotalSize / 1073741824) + " ГБ");
                    }
                    finally { }

                    if (ProvodnikClass.Skoka != 0)
                    {
                        ProvodnikClass.Otstup++;
                    }
                }
            }
        }
    }

    public class Functions
    {
        bool NegrPashet = true;
        public int CursPos = 1;
        ProvodnikClass bbvsem = new ProvodnikClass();
        void Cursor(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow & CursPos != 0)
            {
                CursPos--;
                ProvodnikClass.Skoka = 1;
            }
            else if (key.Key == ConsoleKey.DownArrow & CursPos < (ProvodnikClass.Otstup + 4))
            {
                CursPos++;
                ProvodnikClass.Skoka = 1;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (Path.GetExtension(ProvodnikClass.list[CursPos]) == "")
                {
                    ProvodnikClass.CottonField = ProvodnikClass.list[CursPos];
                    CursPos = 2;
                    ProvodnikClass.Skoka = 0;
                    ProvodnikClass.Otstup = 0;

                }
                else if (Path.GetExtension(ProvodnikClass.list[CursPos]) != "")
                {
                    Process.Start(new ProcessStartInfo { FileName = ProvodnikClass.list[CursPos], UseShellExecute = true });

                }
                ProvodnikClass.list.Clear();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                CursPos = 0;
                ProvodnikClass.Skoka = 1;
                ProvodnikClass.CottonField = "";
                ProvodnikClass.list.Clear();
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                try
                {
                    File.Delete(ProvodnikClass.list[CursPos]);
                }
                catch { }
                Directory.Delete(ProvodnikClass.list[CursPos], true);

            }
            else if (key.Key == ConsoleKey.F5)
            {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                ProvodnikClass.Skoka = 0;
                Console.SetCursorPosition(2, ProvodnikClass.Otstup);
                Console.WriteLine("Введите название папки: ");
                Console.SetCursorPosition(24, ProvodnikClass.Otstup);
                string Papka = Console.ReadLine();
                ProvodnikClass.list.Clear();
                Directory.CreateDirectory(ProvodnikClass.CottonField + "\\" + Papka);
                ProvodnikClass.Otstup = 0;

            }
            else if (key.Key == ConsoleKey.F6)
            {
                ProvodnikClass.Skoka = 0;
                Console.SetCursorPosition(2, ProvodnikClass.Otstup);
                Console.WriteLine("Введите название файла");
                Console.SetCursorPosition(2, ProvodnikClass.Otstup + 1);
                string FileName = Console.ReadLine();
                Console.SetCursorPosition(2, ProvodnikClass.Otstup + 2);
                Console.WriteLine("Введите расширение файла");
                Console.SetCursorPosition(2, ProvodnikClass.Otstup + 3);
                string Rasshirenie = Console.ReadLine();
                ProvodnikClass.list.Clear();
                File.Create(ProvodnikClass.CottonField + "\\" + FileName + "." + Rasshirenie).Close();
                ProvodnikClass.Otstup = 0;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                NegrPashet = false;
            }
            Console.Clear();
        }

        public void SolnceEsheNeSelo()
        {
            ProvodnikClass.Start();
            while (NegrPashet == true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Cursor(key);
                ProvodnikClass.Start();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
                Console.SetCursorPosition(0, CursPos);
                Console.WriteLine("->");
            }
        }
    }
}