using moxpass.Utilities;
using System;


namespace moxpass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize();

            Logger.Log("Application started.");


            int argLen = args.Length;
            bool hideCout = false;
            /*
             *           1         2         3
             * 0123456789012345678901234567890123456789
             * moxpass /?
             * moxpass -?
             * moxpass--help
             * moxpass - v
             * moxpass--version
             */
            if (argLen == 1)
            {
                string[] helpArg = new string[]
                {
                    "/?", "-?", "-h", "/?",
                    "--help"
                };
                if (helpArg.Contains(args[0]))
                {

                }
            }



            /*           1         2         3
             * 0123456789012345678901234567890123456789
             * moxpass complete <position> <AST_string>
             */

            if (argLen == 3)
            {
                int position = -1;
                if (args[0] == "complete" &&
                    int.TryParse(args[1], out position))
                {
                    hideCout = true;
                    string[] result = AstHandler.Complete(position, args[2]);

                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.WriteLine(result[i]);
                    }
                }
            }

            Logger.Log("Application ended, exiting...");
            Logger.StopLogging(hideCout);
        }
    }
}