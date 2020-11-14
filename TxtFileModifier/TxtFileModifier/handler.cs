using System;
using System.IO;

namespace TxtFileModifier
{
    public class Handler
    {
        private StreamReader reader;
        private StreamWriter writer;
        private string FILELOCATION = "";
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
                int c = 0;
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
                        try
                        {
                            argsSorted[c, 0] = args[a];
                            argsSorted[c, 1] = args[a + 1];
                            c++;
                            a++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                                               
                    }
                }

                int i = 0;                
                while (argsSorted[i, 0] != null)
                {
                    if (FILELOCATION == "")
                    {
                        Console.WriteLine("File to be edited required: use the -F argument followed by the path of the file");
                    }
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
                try
                {
                    reader = new StreamReader(FILELOCATION);
                } catch (Exception e)
                {
                    Console.WriteLine("File not found, please verify if the file exists");
                    Environment.Exit(0);
                }
                
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length <= i)
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Close();
                Console.WriteLine("Data written to : " + FILEOUTPUT);
            }
        }

        private void cArg(string arg)
        {
            if (FILELOCATION != null)
            {
                try
                {
                    reader = new StreamReader(FILELOCATION);
                }
                catch (Exception e)
                {
                    Console.WriteLine("File not found, please verify if the file exists");
                    Environment.Exit(0);
                }
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains(arg))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Close();
            }
        }

        private void sArg(string arg)
        {
            if (FILELOCATION != null)
            {
                try
                {
                    reader = new StreamReader(FILELOCATION);
                }
                catch (Exception e)
                {
                    Console.WriteLine("File not found, please verify if the file exists");
                    Environment.Exit(0);
                }
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.StartsWith(arg))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Close();
            }
        }

        private void eArg(string arg)
        {
            if (FILELOCATION != null)
            {
                try
                {
                    reader = new StreamReader(FILELOCATION);
                }
                catch (Exception e)
                {
                    Console.WriteLine("File not found, please verify if the file exists");
                    Environment.Exit(0);
                }
                writer = new StreamWriter(FILEOUTPUT);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.EndsWith(arg))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Close();
            }
        }

        private void showHelp()
        {

            Environment.Exit(0);
        }

    }
}