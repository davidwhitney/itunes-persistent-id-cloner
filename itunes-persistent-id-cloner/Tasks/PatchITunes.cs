using System;
using System.Linq;
using itunes_persistent_id_cloner.Core;

namespace itunes_persistent_id_cloner.Tasks
{
    public class PatchITunes : ITask
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Please make sure iTunes is not running.");
            Console.Write("Please enter your previously extracted Id: ");

            var persistentId = args.Length == 2 ? args[1] : Console.ReadLine().Trim();

            Console.WriteLine("About to patch iTunes to persistent Id: "  + persistentId);

            if (!args.ToList().Contains("-quiet"))
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

            var adapter = new TunesLibraryAdapter();
            adapter.PatchLibraryToPersistentId(persistentId);
        }
    }
}