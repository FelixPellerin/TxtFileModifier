using System;
using System.IO;

namespace TxtFileModifier
{
    class Program
    {
        // "y" CAN BE A CHAR OR A STRING
        // x must be a int
//-----------------------------------------------------
        // -F file location
        // -O output file
        // -L cut when lenght bigger then x
        // -C cut when line contains "y"
        // -S cut when line starts with "y"
        // -E cut when line ends with "y"
        // -H and help display help

        
        static void Main(string[] args)
        {
            if (args[0] == "help" || args[0] == "-H")
            {
                Help();
            }
            else
            {
                new Handler(args);
            }
            
            
        }

        static void Help()
        {

        }

        

    }
}
