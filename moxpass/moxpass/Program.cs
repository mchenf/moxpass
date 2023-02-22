using moxpass.Secret;
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

            if (argLen == 3)
            {
                if (args[0] == "complete" &&
                    int.TryParse(args[1], out int position))
                {
                    hideCout = true;
                    string[] result = AstHandler.Complete(position, args[2]);

                    for (int i = 0; i < result.Length; i++)
                    {
                        Console.WriteLine(result[i]);
                    }
                }

                if (args[0] == "secret" && args[1] == "generate")
                {
                    if (int.TryParse(args[2], out int passLen))
                    {
                        Generator g = new Generator();
                        Console.WriteLine(g.Spew(passLen));
                    }

                }
            }

            Logger.Log("Application ended, exiting...");
            Logger.StopLogging(hideCout);
        }
    }
}