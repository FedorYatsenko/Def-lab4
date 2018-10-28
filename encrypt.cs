using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Read from:\nC:\\Users\\Admin\\Documents\\");
            string filename1 = @"C:\Users\Admin\Documents\" + Console.ReadLine();
            Console.Write("Write to:\nC:\\Users\\Admin\\Documents\\");
            string filename2 = @"C:\Users\Admin\Documents\" + Console.ReadLine();

            if (filename1 == filename2 || !File.Exists(filename1))
            {
                Console.WriteLine("Fail");
                Console.ReadKey();
            }
            else
            {
                string chars = "";

                chars += (char)1028;
                chars += (char)1030;
                chars += (char)1031;

                for (int c = 1040; c < 1104; c++)
                    if (c != 1066 && c != 1067 && c != 1069
                        && c != 1098 && c != 1099 & c != 1101)
                            chars += (char)c;

                chars += (char)1108;
                chars += (char)1110;
                chars += (char)1111;

                Random rnd = new Random();
                int a = rnd.Next(1, 64);
                int b = rnd.Next(1, 64);

                Console.WriteLine(chars);
                for (int i = 0; i < chars.Length; i++)
                    Console.Write(chars[(a * i + b) % chars.Length]);
                Console.WriteLine();
                Console.WriteLine("a = " + a);
                Console.WriteLine("b = " + b);

                using (StreamReader sr = new StreamReader(filename1, System.Text.Encoding.UTF8))
                {
                    using (StreamWriter sw = new StreamWriter(filename2, false, System.Text.Encoding.UTF8))
                    {
                        string line;
                        string line2 = "";
                        int chrindex;

                        while ((line = sr.ReadLine()) != null)
                        {
                            foreach (char c in line)
                            { 
                                chrindex = chars.IndexOf(c);
                                chrindex = (a * chrindex + b) % chars.Length;
                                line2 += chars[chrindex];
                            }

                            sw.WriteLine(line2);
                            line2 = "";
                        }
                    }
                }
               
                Console.ReadKey();
            }
        }
    }
}
