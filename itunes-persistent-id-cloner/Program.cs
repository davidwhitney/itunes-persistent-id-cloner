using System;
using System.Collections.Generic;
using itunes_persistent_id_cloner.Tasks;

namespace itunes_persistent_id_cloner
{
    class Program
    {
        private static readonly Dictionary<string, ITask> Tasks;

        static Program()
        {
            Tasks = new Dictionary<string, ITask>
                        {{"-extract", new ExtractPersistentId()}, {"-patch", new PatchITunes()}, {"-help", new Help()}};
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ITunes Persistent Id Cloner");

            if(args.Length == 0)
            {
                args = new [] {"-help"};
            }

            switch (args[0])
            {
                case "-extract":
                    Tasks["-extract"].Execute(args);
                    break;
                case "-patch":
                    Tasks["-patch"].Execute(args);
                    break;
                default:
                    Tasks["-help"].Execute(args);
                    break;
            }

            Console.WriteLine("Press ANY key to exit...");
            Console.ReadLine();
        }
    }
}
