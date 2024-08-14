using moxpass.Secret;
using moxpass.Utilities;
using moxpass.Version;
using System;


namespace moxpass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize();

            Logger.Log("[moxpass] Application started.");


            int argLen = args.Length;
            bool hideCout = true;
            if (argLen == 1)
            {
                string[] helpArg = new string[]
                {
                    "/?", "-?", "-h", "/?",
                    "--help"
                };
                if (helpArg.Contains(args[0]))
                {
                    Console.WriteLine("Help to be displayed here:");
                    //TODO: Complete help logic
                    return;
                }
                string[] versionArgs = new string[]
                {
                    "version", "--version", "-v"
                };
                if (versionArgs.Contains(args[0]))
                {
                    var vhandler = new VersionHandler(0, 1, 1, 3);
                    Console.WriteLine(vhandler.GetVersionString());
                }

            }
            if (argLen == 2)
            {
                if (args[0] == "config" && args[1] == "list")
                {
                    //TODO: Implement moxpass config list
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
                        SecretGenerator g = new SecretGenerator();
                        Console.WriteLine(g.Spew(passLen));
                    }

                }
            }

            if (argLen == 4)
            {
                if (args[0] == "secret" && args[1] == "generate")
                {
                    if (
                        Enum.TryParse(args[2], true, out Complexity cpx)
                        && int.TryParse(args[3], out int passLen)
                        )
                    {
                        Logger.Log("Generating password...");
                        SecretGenerator g = new SecretGenerator(cpx);
                        Console.WriteLine(g.Spew(passLen));
                    }

                }
            }

            Logger.Log("Application ended, exiting...");
            Logger.StopLogging(hideCout);
        }
    }
}