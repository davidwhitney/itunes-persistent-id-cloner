using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using itunes_persistent_id_cloner.Core;

namespace itunes_persistent_id_cloner.Tasks
{
    public class ExtractPersistentId : ITask
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Extracting iTunes persistent id..." + Environment.NewLine);

            var locator = new TunesLibraryAdapter();
            var summary = locator.GenerateLibrarySummary();

            Console.WriteLine("Your iTunes Persistent Id is: " + summary.LibraryPersistentId.ToLower());
        }
    }
}
