using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace itunes_persistent_id_cloner.Core
{
    public class LibraryFile
    {
        public string LibraryFileLocation { get; set; }
        public string PersistentId { get { return ExtractPersistentId(LibraryFileLocation); } }

        public LibraryFile(string libraryFileLocation)
        {
            LibraryFileLocation = libraryFileLocation;
        }

        private static string ExtractPersistentId(string libraryLocation)
        {
            var library = File.ReadAllText(libraryLocation);

            var xdoc = XDocument.Parse(library);

            foreach (var descendant in xdoc.Descendants().Where(descendant => descendant.Value == "Library Persistent ID"))
            {
                return descendant.NextNode.ToString().Replace("<string>", "").Replace("</string>", "");
            }

            throw new InvalidOperationException("Cannot locate iTunes persistent id.");
        }
    }
}
