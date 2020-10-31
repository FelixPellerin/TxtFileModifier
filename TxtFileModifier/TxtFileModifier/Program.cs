using System;
using System.IO;

namespace TxtFileModifier
{
    class Program
    {
        // -F file location
        // -O output file
        // -L cut when lenght bigger then x
        static string FILELOCATION;
        static string FILEOUTPUT;
        static void Main(string[] args)
        {
            if (args.Length == 0){
                Console.WriteLine("Arguments Required");
            }
            else{
                int argCursor = 0;
                while (argCursor < args.Length){
                    switch (args[argCursor]){
                        case "-F":
                            FILELOCATION = args[argCursor + 1];
                            Console.WriteLine(" File to be read : " + FILELOCATION);
                            break;

                        case "-O":
                            FILEOUTPUT = args[argCursor + 1];
                            Console.WriteLine(" Data will be written to : " + FILEOUTPUT);
                            break;

                        case "-L":
                            break;
                        
                        default:
                            Console.WriteLine(" Argument unknown");
                            break;
                    };
                }

            }
            
        }



    }
}
