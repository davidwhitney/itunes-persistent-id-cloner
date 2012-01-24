using System;
using System.IO;

namespace itunes_persistent_id_cloner.Core
{
    public class PreferencesFileSource
    {
        public string Location { get; private set; }

        public PreferencesFileSource()
        {
            var appData = Environment.GetEnvironmentVariable("APPDATA");
            Location = appData + @"\Apple Computer\iTunes\iTunesPrefs.xml";
        }

        public PreferencesFileSource(string location)
        {
            Location = location;
        }

        public string FileContents
        {
            get { return File.ReadAllText(Location); }
        }

        public bool Exists()
        {
            return File.Exists(Location);
        }
    }
}
