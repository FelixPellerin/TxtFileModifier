using System;
using System.IO;

namespace TxtFileModifier
{
    public class Handler
    {
        private StreamReader reader;
        private StreamWriter writer;
        private string FILELOCATION;
        private string FILEOUTPUT = "output.txt";
        //This does not contain input or output files paths, they are set to the variables when the variables are sorted
        private string[,] argsSorted;

        public Handler(string[] args)
        {
            
            if (args.Length == 0)
            {
                Console.WriteLine("Arguments Required");
            }
            else
            {                
                argsSorted = new string[args.Length / 2, 2];                
                for (int a = 0; a < args.Length; a++)
                {
                    if (args[a] == "-F")
                    {                        
                        FILELOCATION = args[a + 1];
                        Console.WriteLine(" File to be read : " + FILELOCATION);
                        a++;
                    }
                    else if (args[a] == "-O")
                    {                        
                        FILEOUTPUT = args[a + 1];
                        Console.WriteLine(" Data will be written to : " + FILEOUTPUT);
                        a++;
                    }
                    else
                    {
                        argsSorted[a, 0] = args[a];
                        argsSorted[a, 1] = args[a + 1];
                        a++;                        
                    }
                }

                int i = 0;
                while (argsSorted[i, 0] != null)
                {
                    switch (argsSorted[i, 0])
                    {                       
                        case "-L":
                            lArg(argsSorted[i, 1]);                            
                            break;

                        case "-C":
                            cArg(argsSorted[i, 1]);                            
                            break;

                        case "-S":
                            sArg(argsSorted[i, 1]);
                            break;

                        case "-E":
                            eArg(argsSorted[i, 1]);
                            break;

                        default:
                            Console.WriteLine(" Argument unknown");
                            break;
                    };
                    i++;
                }

                
                

            }
        }

        private void lArg(string arg)
        {
            int i;
            if (FILELOCATION != null && int.TryParse(arg, out i))
            {
                reader = new StreamReader(FILELOCATION);
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()).Length < i)
                {
                    writer.WriteLine(line);
                }
                Console.WriteLine("Data writttent to : " + FILEOUTPUT);
            }
        }

        private void cArg(string arg)
        {
            if (FILELOCATION != null)
            {
                reader = new StreamReader(FILELOCATION);
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains(arg))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private void sArg(string arg)
        {
            if (FILELOCATION != null)
            {
                reader = new StreamReader(FILELOCATION);
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.StartsWith(arg))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private void eArg(string arg)
        {
            if (FILELOCATION != null)
            {
                reader = new StreamReader(FILELOCATION);
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.EndsWith(arg))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }


    }
}