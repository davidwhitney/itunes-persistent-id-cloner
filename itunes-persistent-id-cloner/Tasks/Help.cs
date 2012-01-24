using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace itunes_persistent_id_cloner.Tasks
{
    public class Help : ITask
    {
        public void Execute(string[] args)
        {
            Console.WriteLine("Args:");
            Console.WriteLine(" -extract      : Extracts your persistent Id from host computer");
            Console.WriteLine(" -patch <ID>   : Patches your current computer with persistent Id");
        }
    }
}
