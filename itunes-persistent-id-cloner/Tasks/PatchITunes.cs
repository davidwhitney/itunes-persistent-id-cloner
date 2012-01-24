using System;
using itunes_persistent_id_cloner.Core;

namespace itunes_persistent_id_cloner.Tasks
{
    public class PatchITunes : ITask
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Please make sure iTunes is not running.");
            Console.Write("Please enter your previously extracted Id: ");
            
            var persistentId = Console.ReadLine().Trim();
            
            var adapter = new TunesLibraryAdapter();
            adapter.PatchLibraryToPersistentId(persistentId);
        }
    }
}