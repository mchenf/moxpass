using moxpass.Utilities;


namespace moxpass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.Initialize();

            Logger.Log("Application started.");







            Logger.Log("Application ended, exiting...");
            Logger.StopLogging(logfileDir);
        }
    }
}