using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generics;

namespace Logs
{
    class Logger
    {
        private static string filesName = "daylog";
        private static string filesExt = "log";
        private static string globarDir = "files\\logs";
        private static string dateFormat = "dd-MM HH:mm:ss.ff";

        //print flags
        private static bool printToConsole = true;
        private static bool printDateToConsole = false;
        private static bool printToFile = true;

        protected static Filer filer = new Filer(filesName, filesExt);

        public static string FilesName 
        {
            get { return filesName; }
            set { filesName = value; } 
        }

        public static string FilesExt
        {
            get { return filesExt; }
            set { filesExt = value; }
        }

        public static string GlobalDir
        {
            get { return globarDir; }
            set { globarDir = value; }
        }

        public static string DateFormat
        {
            get { return dateFormat; }
            set { dateFormat = value; }
        }
    
        //print flags
        public static bool PrintToConsole 
        {
            get { return printToConsole;  }
            set { printToConsole = value; } 
        }

        public static bool PrintDateToConsole
        {
            get { return printDateToConsole; }
            set { printDateToConsole = value; }
        }

        public static bool PrintToFile 
        {
            get { return printToFile; }
            set { printToFile = value; }
        }

        //prints a message in the console
        protected static void consolePrint(String msg)
        {
            Console.WriteLine(msg);
        }

        //add the time to a message
        protected static String timeSubfix(String msg)
        {
            //get date and time
            DateTime saveNow = DateTime.Now;
            return saveNow.ToString(dateFormat) + "-> " + msg;
        }

        //prints a message in the console
        protected static void consoleDatePrint(String msg)
        {
            //get date and time
            msg = timeSubfix(msg);

            Console.WriteLine(msg);
        }

        //writes a line in a log file
        protected static bool logPrint(String msg)
        {
            try
            {
                //get date and time
                msg = timeSubfix(msg);

                //save message to file 
                filer.appendToCurrentFile(msg, globarDir);
            }
            catch
            {
                return false;
            }
            return true;
        }

        //prints a message in the correct output unit
        public static void output(String msg)
        {
            //print the message

            //console
            if (PrintToConsole)
            {
                //console & date
                if (PrintDateToConsole)
                {
                    consoleDatePrint(msg);
                }
                //console no date
                else
                {
                    consolePrint(msg);
                }
            }

            //file (always with date)
            if (PrintToFile)
            {
                logPrint(msg);
            }
        }

        public static void emptyLine()
        {
            //console
            consolePrint("");

            //file
            //logPrint("");
        }

    }
}
