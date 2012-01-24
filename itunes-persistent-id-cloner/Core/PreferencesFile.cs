using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace itunes_persistent_id_cloner.Core
{
    public class PreferencesFile
    {
        public string LibraryLocation { get; private set; }
       
        public PreferencesFile(PreferencesFileSource preferencesFileSource)
        {
            var encodedLibraryLocation = ExtractLibraryLocation(preferencesFileSource.FileContents);
            LibraryLocation = DecodeLibraryLocation(encodedLibraryLocation);
        }

        private static string DecodeLibraryLocation(string base64EncodedLocation)
        {
            var bytes = Convert.FromBase64String(base64EncodedLocation);
            return Encoding.Unicode.GetString(bytes);
        }

        private static string ExtractLibraryLocation(string itunesPrefs)
        {
            var xdoc = XDocument.Parse(itunesPrefs);

            foreach (var descendant in xdoc.Descendants().Where(descendant => descendant.Value == "iTunes Library XML Location:1"))
            {
                return descendant.NextNode.ToString().Replace("<data>", "").Replace("</data>", "");
            }

            throw new InvalidOperationException("Cannot locate iTunes library.");
        }
    }
}
