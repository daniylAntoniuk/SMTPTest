using System;
using System.IO;

namespace ConsoleSenderEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            int action=0;
            do
            {
                Console.WriteLine("1. Send Email simple");
                Console.Write("->_");
                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            string subfolder = "1";
                            Console.Write("Enter subsolder: ");
                            subfolder = Console.ReadLine();
                            string folder = "email";
                            string fileName = "index.html";
                            string pathFile = Path.Combine(folder, subfolder, fileName);

                            //string html = "Hello";
                            string html = File.ReadAllText(pathFile);

                            using (SMTPSender sender = new SMTPSender())
                            {
                                Console.WriteLine("Enter your email: ");
                                string email = Console.ReadLine();
                                //string email = "novakvova@gmail.com";
                                sender.SendMessage(email, html);
                            }
                            break;
                        }
                    default:
                        break;
                }
                
            } while (action != 0); ;
            
            Console.WriteLine("Hello World!");
        }
    }
}
