using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public delegate void DirectionKeyPressedEventHandler(object source, EventArgs e);

        public event DirectionKeyPressedEventHandler DirectionKeyPressed;

        protected virtual void OnDirectionKeyPressed()
        {
            if (DirectionKeyPressed != null)
                DirectionKeyPressed(this, EventArgs.Empty);
        }

        static void Main(string[] args)
        {
            int windowHeight = 42;
            int windowWidth = 160;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetWindowSize(1,1);
            Console.SetBufferSize(windowWidth, windowHeight);
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.Title = "lol";
            Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.

            Console.OutputEncoding = System.Text.Encoding.UTF8; //9472

            StringBuilder playfieldString = new StringBuilder();
            Random rnd = new Random();
            int minTerrain = 9601;
            int maxTerrain = 9616;
            int clusterVariable = 1;           


            //EventHandler userInput(object source, EventArgs e);
            //Console.Write(Encoding.Unicode.GetChars(BitConverter.GetBytes(9605))[0]);
            //Console.Write(Encoding.Unicode.GetChars(BitConverter.GetBytes(9605))[0]);
            
            while (true)
            {

                playfieldString = playfieldString.Clear();
                for (var i = 0; i < 83; i++)
                {
                    if(i % rnd.Next(1,3) == 0)
                        clusterVariable = rnd.Next(minTerrain, maxTerrain);
                    for (var j = 0; j < 160; j++)
                    {
                        playfieldString.Append(Encoding.Unicode.GetChars(BitConverter.GetBytes((rnd.Next(minTerrain,maxTerrain)+clusterVariable)/2))[0]);
                    }
                }

                Console.Clear();
                Console.Write(playfieldString.ToString() + "Press any key to continue");


                Console.CursorSize = 1;                
                Console.CursorVisible = true;
                int cursorOrigHorizontal = Console.WindowWidth/2;
                int cursorOrigVertical = Console.WindowHeight/2;
                Console.SetCursorPosition(cursorOrigHorizontal, cursorOrigVertical);
                Console.Write("@");
                Console.SetCursorPosition(cursorOrigHorizontal, cursorOrigVertical);


                ConsoleKeyInfo keyPressed = Console.ReadKey();

                List<ConsoleKey> directionKeys = new List<ConsoleKey>
                {
                    ConsoleKey.LeftArrow,
                    ConsoleKey.UpArrow,
                    ConsoleKey.RightArrow,
                    ConsoleKey.DownArrow
                };

                int speed = 4;

                Console.ForegroundColor = ConsoleColor.DarkRed;


                while(directionKeys.Contains(keyPressed.Key))
                {
                    
                    if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {                        
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft -= 3, Console.CursorTop);
                        Console.Write("@");
                        Console.SetCursorPosition(Console.CursorLeft -= 1, Console.CursorTop);
                        Console.Beep(432, 100);

                    }

                    if (keyPressed.Key == ConsoleKey.UpArrow)
                    { 
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft -= 2, Console.CursorTop -= 1);
                        Console.Write("@");
                        Console.SetCursorPosition(Console.CursorLeft -= 1, Console.CursorTop);
                       // Console.Beep(432, 100);
                    }

                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        Console.Write(" ");
                        Console.Write("@");
                        Console.SetCursorPosition(Console.CursorLeft -= 1, Console.CursorTop);
                       // Console.Beep(432, 100);
                    }


                    if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft -= 2, Console.CursorTop += 1);
                        Console.Write("@");
                        Console.SetCursorPosition(Console.CursorLeft -= 1, Console.CursorTop);
                       // Console.Beep(432, 100);
                    }


                    //Console.CursorLeft = cursorPosHorizontal;
                    //Console.CursorTop = cursorPosVertical;
                    keyPressed = Console.ReadKey();
                }


                Console.Beep(324, 1000);
                Console.Beep(385, 1000);

                if(Console.CapsLock)
                    Console.Beep(432, 1000);
            }
            Console.Read();
        }        
    }
}
