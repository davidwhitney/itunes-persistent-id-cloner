namespace itunes_persistent_id_cloner.Core
{
    public class LibrarySummary
    {
        public string XmlFile { get; set; }

        public string ItlFile
        {
            get { return XmlFile.Replace("iTunes Music Library.xml", "iTunes Library.itl"); }
        }

        public string LibraryPersistentId { get; set; }
    }
}