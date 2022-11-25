/*using PROVODNIK;
using System.Diagnostics;

namespace Prakticheskaya7
{
    public class Functions
    {
        bool NegrPashet = true;
        public int CursPos = 1;
        ProvodnikClass class = new ProvodnikClass();
        void Cursor(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow & CursPos != 0)
            {
                CursPos--;
                ProvodnikClass.coun = 1;
            }
            else if (key.Key == ConsoleKey.DownArrow & CursPos < (ProvodnikClass.columns - 1))
            {
                CursPos++;
                ProvodnikClass.coun = 1;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (Path.GetExtension(ProvodnikClass.list[CursPos]) == "")
                {
                    ProvodnikClass.put = ProvodnikClass.list[CursPos];
                    CursPos = 0;
                    ProvodnikClass.coun = 0;
                    ProvodnikClass.columns = 0;

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
                ProvodnikClass.coun = 1;
                ProvodnikClass.put = "";
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
                ProvodnikClass.coun = 0;
                Console.SetCursorPosition(2, ProvodnikClass.columns);
                Console.WriteLine("Введите название директории");
                Console.SetCursorPosition(2, ProvodnikClass.columns + 1);
                string dirn = Console.ReadLine();
                ProvodnikClass.list.Clear();
                Directory.CreateDirectory(ProvodnikClass.put + "\\" + dirn);
                ProvodnikClass.columns = 0;

            }
            else if (key.Key == ConsoleKey.F6)
            {
                ProvodnikClass.coun = 0;
                Console.SetCursorPosition(2, ProvodnikClass.columns);
                Console.WriteLine("Введите название файла");
                Console.SetCursorPosition(2, ProvodnikClass.columns + 1);
                string FileName = Console.ReadLine();
                Console.SetCursorPosition(2, ProvodnikClass.columns + 2);
                Console.WriteLine("Введите расширение файла");
                Console.SetCursorPosition(2, ProvodnikClass.columns + 3);
                string Rasshirenie = Console.ReadLine();
                ProvodnikClass.list.Clear();
                File.Create(ProvodnikClass.put + "\\" + FileName + "." + Rasshirenie).Close();
                ProvodnikClass.columns = 0;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                NegrPashet = false;
            }
            Console.Clear();
        }

        public void star()
        {
            ProvodnikClass.Start();
            bool NegrPashet = true;
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

*/