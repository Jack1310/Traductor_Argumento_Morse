using System;
using System.Collections.Generic;

namespace Morse
{
    class Program
    {
        public static double ms = 0;

        public static Dictionary<string, string> morse = new Dictionary<string, string>
            {
                {"a",".-"}, {"b","..."}, {"c","-.-."}, {"d","-.."}, {"e","."}, {"f","..-."},{"g",".-"},
                {"h","...."},{"i",".."},{"j",".---"},{"k","-.-"},{"l",".-.."},{"m","--"},{"n","-."},
                {"o","---"},{"p",".--."},{"q","--.-"},{"r",".-."},{"s","..."},{"t","-"},{"u","..-"},
                {"v","...-"},{"w",".--"},{"x","-..-"},{"y","-.--"},{"z","--.."},{"0", "-----"},
                {"1", ".----"}, {"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."},
                {"6", "-...."},{"7", "--..."}, {"8", "---.."}, {"9", "----."}, {" ", " "}
            };

        static void Main(string[] args)
        {
            foreach(var palabra in args)
            {
                Contar(palabra.ToLower());
                ms += 1000;
            }
            
            ms = ms / 1000;   
            Console.WriteLine("El mensaje tendrá una duración de {0} segundos" , ms);      

            foreach(var palabra in args)
            {
                Morse(palabra.ToLower());
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static void Morse(string palabra)
        {
            foreach (char letra in palabra.ToCharArray())
            {
                Console.WriteLine(letra);
                try
                {
                    string morseTraducido = morse[letra.ToString()];
                    Console.WriteLine(morseTraducido);
                    
                    foreach (char caracter in morseTraducido.ToCharArray())
                    {
                        if (caracter == '.')
                        {
                            Console.Beep(600, 250);
                        }
                    
                        if (caracter == '-')
                        {
                            Console.Beep(600, 750);    
                        }
                        
                        else
                        {
                            System.Threading.Thread.Sleep(250);
                        }

                    }
                
                }
                
                catch
                {
                    
                }

                System.Threading.Thread.Sleep(750);            
            }
        }

        public static void Contar(string palabra)
        {
            foreach (char letra in palabra.ToCharArray())
            {
                try
                {
                    string morseTraducido = morse[letra.ToString()];
                    
                    foreach (char caracter in morseTraducido.ToCharArray())
                    {
                        if (caracter == '.')
                        {
                            ms += 250;
                        }
                    
                        if (caracter == '-')
                        {
                            ms += 750;    
                        }
                        
                        else
                        {
                            ms += 250;
                        }

                    }
                
                }
                
                catch
                {
                    
                }

                ms += 750;
            }
        }

    }
}
