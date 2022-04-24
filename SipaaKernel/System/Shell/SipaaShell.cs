using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernel.System.Shell
{
    public class SipaaShell
    {
        public static string CurrentDirectory = @"0:\";
        public static List<Command> cmdList = new List<Command>();
        public static void Initialize()
        {
            var oldFg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine(Information.OSName);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Initializing command library...");
            Kernel.Wait(1232);
            cmdList.Add(new Commands.System.ThrowPSODCommand());
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine(Information.OSName);
            if (!Information.IsCompleted)
            {
                Console.WriteLine("Not finished yet. View github.com/Sipaa-Team/projects/1\nfor the progression of " + Information.OSName);
            }
            Console.WriteLine();
            Console.ForegroundColor = oldFg;
        }

        public static void GetImput()
        {
            var oldFg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("root");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(CurrentDirectory);
            Console.ForegroundColor = oldFg;
            Console.Write(":> ");
            var imput = Console.ReadLine();
            FindAndExecuteCommand(imput);
            GetImput();
        }

        public static void FindAndExecuteCommand(string imput)
        {
            Console.WriteLine();
            string[] split = imput.Split(' ');
            bool finded = false;
            foreach (Command cmd in cmdList)
            {
                if (split[0] == cmd.Name|| split[0] == cmd.UppercaseName)
                {
                    finded = true;
                    cmd.Execute(split);
                }
            }
            if (!finded) { var oldFg = Console.ForegroundColor;  Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid command!"); Console.ForegroundColor = oldFg; }
            Console.WriteLine();
        }
    }
}
