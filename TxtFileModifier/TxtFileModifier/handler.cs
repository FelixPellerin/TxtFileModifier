using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TxtFileModifier
{
    public class Handler
    {
        #region Constants and variables

        private StreamReader reader;
        private StreamWriter writer;
        private List<string> tempFileData;
        private string FILELOCATION = "";
        private string FILEOUTPUT = "output.txt";
        //This does not contain input or output files paths, they are set to the variables when the variables are sorted
        private string[,] argsSorted;

        #endregion

        #region Constructor (On start)
        public Handler(string[] args)
        {
            #region Arguments
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
                    if (args[a].ToUpper() == "-F")
                    {                        
                        FILELOCATION = args[a + 1];
                        Console.WriteLine(" File to be read : " + FILELOCATION);
                        a++;
                    }
                    else if (args[a].ToUpper() == "-O")
                    {                        
                        FILEOUTPUT = args[a + 1];
                        Console.WriteLine(" Data will be written to : " + FILEOUTPUT);
                        a++;
                    }
                    else if (args[a].ToUpper().Contains("HELP"))
                    {
                        showHelp();
                    }
                    else
                    {
                        try
                        {
                            argsSorted[c, 0] = args[a].ToUpper();
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
                #endregion

                readFileData();
                int i = 0;                
                while (argsSorted[i, 0] != null)
                {
                    if (FILELOCATION == "")
                    {
                        Console.WriteLine("File to be edited required: use the -F argument followed by the path of the file");
                        Environment.Exit(0);
                    }
                    switch (argsSorted[i, 0][1])
                    {                       
                        case 'L':
                            lArg(argsSorted[i, 0], argsSorted[i, 1]);                            
                            break;

                        case 'C':
                            cArg(argsSorted[i, 0], argsSorted[i, 1]);                            
                            break;

                        case 'S':
                            sArg(argsSorted[i, 0], argsSorted[i, 1]);
                            break;

                        case 'E':
                            eArg(argsSorted[i, 0], argsSorted[i, 1]);
                            break;                        

                        default:
                            if (argsSorted[i, 0].ToUpper().Contains("HELP") || argsSorted[i, 0].ToUpper().Contains("-H"))
                            {
                                showHelp();
                            }
                            Console.WriteLine(" Argument unknown, Please make shure you are using valid arguments. Use -H or --Help for instruction");
                            Environment.Exit(0);
                            break;
                    };
                    i++;
                }                
                writeTempDataToFile();               
            }
        }
        #endregion

        #region Read/Write
        private void readFileData()
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
                string line;
                tempFileData = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    tempFileData.Add(line);
                }
            }
            else
            {
                //file is null
                Console.WriteLine("Please select a file to be read (-F file.txt)");
                Environment.Exit(0);
            }
        }

        private void writeTempDataToFile()
        {
            writer = new StreamWriter(FILEOUTPUT);
            foreach (string line in tempFileData)
            {
                writer.WriteLine(line);
            }
            writer.Close();
            Console.WriteLine("Data written to " + FILEOUTPUT);
            Environment.Exit(0);
        }

        #endregion

        #region Arguments

        #region -L
        private void lArg(string arg, string argValue)
        {
            bool keep = arg.Contains('K');
            List<string> tempToRemove = new List<string>();
            int i;            
            if (int.TryParse(argValue, out i))
            {
                if (keep)
                {
                    tempToRemove = tempFileData.Where(l => l.Length < i).ToList();                    
                }
                else
                {
                    tempToRemove = tempFileData.Where(l => l.Length > i).ToList();                    
                }
                

                foreach (string line in tempToRemove)
                {
                    tempFileData.Remove(line);
                }
            }
            else
            {
                Console.WriteLine(argValue + " Invalid value for -L argument");
            }
            

        }
        #endregion

        #region -C
        private void cArg(string arg, string argValue)
        {
            bool caseInsensitive = arg.Contains('I');
            bool keep = arg.Contains('K');
            List<string> tempToRemove = new List<string>();
            if (keep && caseInsensitive)
            {                
                tempToRemove = tempFileData.Where(l => !l.ToUpper().Contains(argValue.ToUpper())).ToList();                
            }
            else if (keep && !caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => !line.Contains(argValue)).ToList();                
            }
            else if (caseInsensitive && !keep)
            {
                tempToRemove = tempFileData.Where(line => line.ToUpper().Contains(argValue.ToUpper())).ToList();                
            }
            else if (!keep && !caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => line.Contains(argValue)).ToList();
            }
            

            foreach (string line in tempToRemove)
            {
                tempFileData.Remove(line);
            }
            //Console.WriteLine("Lines that contain " + argValue + " have been removed");
        }
        #endregion

        #region -S
        private void sArg(string arg, string argValue)
        {
            bool caseInsensitive = arg.Contains('I');
            bool keep = arg.Contains('K');
            List<string> tempToRemove = new List<string>();
            if (keep && !caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => !line.StartsWith(argValue)).ToList();
            }
            else if (keep && caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => !line.ToUpper().StartsWith(argValue.ToUpper())).ToList();                
            }
            else if (!keep && !caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => line.StartsWith(argValue)).ToList();                
            }
            else if (!keep && caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => line.ToUpper().StartsWith(argValue.ToUpper())).ToList();
            }

            foreach (string line in tempToRemove)
            {
                tempFileData.Remove(line);
            }
            Console.WriteLine("Lines that start with " + argValue + " have been removed");
        }
        #endregion

        #region -E
        private void eArg(string arg, string argValue)
        {
            bool caseInsensitive = arg.Contains('I');
            bool keep = arg.Contains('K');
            List<string> tempToRemove = new List<string>();
            if (keep && !caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => !line.EndsWith(argValue)).ToList();
            }
            else if (keep && caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => !line.ToUpper().EndsWith(argValue.ToUpper())).ToList();                
            }
            else if (!keep && !caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => line.EndsWith(argValue)).ToList();                
            }
            else if (!keep && caseInsensitive)
            {
                tempToRemove = tempFileData.Where(line => line.ToUpper().EndsWith(argValue.ToUpper())).ToList();                
            }

            foreach (string line in tempToRemove)
            {
                tempFileData.Remove(line);
            }
            Console.WriteLine("Lines that end with " + argValue + " have been removed");
        }
        #endregion

        #region Help
        private void showHelp()
        {
            //Outdated refer to ReadMe.md
            Console.Write(
                " -F  : Set the file to be edited. This parameter is required at all time. \n" +
                " -O  : Set the output file. If not set, default file will be output.txt. \n" +
                " -L  : Cut the lines when they have more than 'X' characters. \n" +
                " -LK : Cut the lines when they have less than 'X' characters. \n" +
                " -C  : Cut the lines when they contain 'X' character or chain of characters. \n" +
                " -CK : Cut the lines when they do not contain 'X' character or chain of characters.\n" +
                " -CI : C argument but not case sensitive. \n" +
                " -S  : Cut the lines when they start by 'X' character or chain of characters. \n" +
                " -SK : Cut the lines when they do not start by 'X' character or chain of characters. \n" +
                " -SI : S argument but not case sensitive. \n" +
                " -E  : Cut the lines when they end by 'X' character or chain of characters. \n" +
                " -EK : Cut the lines when they do not end by 'X' character or chain of characters. \n" +
                " -EI : E argument but not case sensitive."
                );
            
            Environment.Exit(0);
        }
        #endregion

        #endregion
    }
}