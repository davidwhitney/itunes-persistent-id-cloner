using System;
using itunes_persistent_id_cloner.Core;

namespace itunes_persistent_id_cloner.Tasks
{
    public class ExtractPersistentId : ITask
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Extracting iTunes persistent id..." + Environment.NewLine);

            var preferenceFileSource = new PreferencesFileSource();

            if (!preferenceFileSource.Exists())
            {
                Console.WriteLine("iTunes either isn't installed, or hasn't been run for the first time. Do that and come back.");
            }
            else
            {
                var adapter = new TunesLibraryAdapter();
                var summary = adapter.GenerateLibrarySummary();

                Console.WriteLine("Your iTunes Persistent Id is: " + summary.LibraryPersistentId.ToLower());
            }
        }
    }
}
