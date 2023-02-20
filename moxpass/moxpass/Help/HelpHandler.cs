using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moxpass.Help
{
    public static class HelpHandler
    {
        private static void writeUsage(string Ast, string Opts)
        {
            Console.Write("usage: ");
            Console.Write(Ast + " " + Opts);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void writeFuncBlock(string FunctionBlock)
        {
            Console.WriteLine(FunctionBlock);
        }

        private static void writeOptsDescription(string opt, string description)
        {
            Console.Write(new string(' ', 4));
            Console.Write(opt.PadRight(21, ' '));
            Console.WriteLine(description);
        }


    }
}
