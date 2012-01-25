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

            var persistentId = GetIdToPatchTo(args);
            PromptForConfirmation(args, persistentId);
            ThrowIfUserIsCripplinglyStupid(persistentId);
            Patch(persistentId);
        }

        private static void Patch(string persistentId)
        {
            var adapter = new TunesLibraryAdapter();
            adapter.PatchLibraryToPersistentId(persistentId);
        }

        private static void ThrowIfUserIsCripplinglyStupid(string persistentId)
        {
            if (string.IsNullOrWhiteSpace(persistentId))
            {
                throw new InvalidOperationException("That's not a valid persistent Id. Type better.");
            }
        }

        private static void PromptForConfirmation(string[] args, string persistentId)
        {
            Console.WriteLine();
            Console.WriteLine("About to patch iTunes to persistent Id: " + persistentId);

            if (args.ToList().Contains("-quiet"))
            {
                return;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static string GetIdToPatchTo(string[] args)
        {
            var persistentId = string.Empty;
            if (args.Length > 1)
            {
                persistentId = args[1].Trim();
            }
            else
            {
                Console.Write("Please enter your previously extracted Id: ");
                Console.ReadLine().Trim();
            }
            return persistentId;
        }
    }
}