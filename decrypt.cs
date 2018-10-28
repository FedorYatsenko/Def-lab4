using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace decrypt
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

                do
                {
                    Console.WriteLine("Pear 1:");
                    string ch1 = Console.ReadLine();

                    Console.WriteLine("Pear 2:");
                    string ch2 = Console.ReadLine();


                    Dictionary<int, int> ab = new Dictionary<int, int>();
 
                    for (int a = 1; a < 64; a++)
                        for (int b = 1; b < 64; b++)
                        {
                            if (ch1[0] == chars[(a * chars.IndexOf(ch1[1]) + b) % chars.Length] &&
                                ch2[0] == chars[(a * chars.IndexOf(ch2[1]) + b) % chars.Length] )
                            {
                                Console.WriteLine("a = " + a);
                                Console.WriteLine("b = " + b);
                                ab.Add(a, b);
                            }
                        }

                    int A = 0,
                        B = 0;

                    Console.WriteLine("_______________________________");
                    Console.Write("Use a = ");

                    A = int.Parse(Console.ReadLine());

                    if (ab.ContainsKey(A))
                        B = ab[A];


                    if (B == 0)
                        Console.WriteLine("Nothink");
                    else
                    {
                        Console.WriteLine("_______________________________");
                        Console.WriteLine("a = " + A);
                        Console.WriteLine("b = " + B);

                        string chars2 = "";

                        for (int i = 0; i < chars.Length; i++)
                            chars2 += chars[(A * i + B) % chars.Length];

                        Console.WriteLine(chars);
                        Console.WriteLine(chars2);
                        
                        using (StreamReader sr = new StreamReader(filename1, System.Text.Encoding.UTF8))
                        {
                            using (StreamWriter sw = new StreamWriter(filename2, false, System.Text.Encoding.UTF8))
                            {
                                string line;
                                string line2 = "";

                                while ((line = sr.ReadLine()) != null)
                                {
                                    foreach (char c in line)
                                    {
                                        line2 += chars[chars2.IndexOf(c)];
                                    }

                                    sw.WriteLine(line2);
                                    line2 = "";
                                }
                            }
                        }
                    }
                } while (true);
            }
        }
    }
}
