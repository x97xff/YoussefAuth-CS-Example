using System;

namespace YoussefAuthExample
{
    class Program
    {
        public static YoussefAuth.api Auth = new YoussefAuth.api(
            name: "YourAppName",
            ownerid: "YourOwnerId",
            secret: "YourAppSecret",
            version: "1.0"
        );

        static void Main(string[] args)
        {
            Console.Title = "Youssef Auth â€¢ C# Example";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("          YOUSSEF AUTH â€¢ C# (.NET) CLIENT          ");
            Console.WriteLine("==================================================");
            Console.ResetColor();

            Console.WriteLine("\n[+] Initializing connection...");
            if (!Auth.init())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[-] Failed to initialize session. Check credentials.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Connected to Youssef Auth Cloud!\n");
            Console.ResetColor();

            Console.WriteLine("1. Login with Username & Password");
            Console.WriteLine("2. Activate with License Key");
            Console.Write("\nChoice: ");
            string ch = Console.ReadLine();

            if (ch == "1")
            {
                Console.Write("Username: ");
                string u = Console.ReadLine();
                Console.Write("Password: ");
                string p = Console.ReadLine();

                if (Auth.login(u, p))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n[+] Login successful! Welcome " + u);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[-] Login failed!");
                }
            }
            else if (ch == "2")
            {
                Console.Write("License Key: ");
                string k = Console.ReadLine();
                if (Auth.license(k))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n[+] License Validated Successfully!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[-] Invalid or expired license.");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}