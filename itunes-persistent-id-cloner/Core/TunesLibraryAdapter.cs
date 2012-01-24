using System;
using System.IO;
using System.Text;

namespace itunes_persistent_id_cloner.Core
{
    public class TunesLibraryAdapter
    {
        private readonly PreferencesFile _preferencesFile;
        private readonly LibraryFile _libraryFile;
        private readonly PreferencesFileSource _preferencesFileSource;

        public TunesLibraryAdapter()
        {
            _preferencesFileSource = new PreferencesFileSource();
            _preferencesFile = new PreferencesFile(_preferencesFileSource);
            _libraryFile = new LibraryFile(_preferencesFile.LibraryLocation);
        }

        public TunesLibraryAdapter(PreferencesFile preferencesFile, LibraryFile libraryFile)
        {
            _preferencesFile = preferencesFile;
            _libraryFile = libraryFile;
        }

        public LibrarySummary GenerateLibrarySummary()
        {
            var persistentId = _libraryFile.PersistentId;
            return new LibrarySummary {XmlFile = _libraryFile.LibraryFileLocation, LibraryPersistentId = persistentId};
        }

        public void PatchLibraryToPersistentId(string persistentId)
        {
            var summary = GenerateLibrarySummary();

            var xmlFile = File.ReadAllText(summary.XmlFile);
            xmlFile = xmlFile.Replace(summary.LibraryPersistentId, persistentId.ToUpper());
            File.WriteAllText(summary.XmlFile, xmlFile);

            var bytes = File.ReadAllBytes(summary.ItlFile);

            var listOBytes = BytesToHex(bytes);
            var patchedLibraryInHex = listOBytes.Replace(summary.LibraryPersistentId.ToLower(), persistentId);
            var newLibraryBytes = StringToByteArray(patchedLibraryInHex);

            File.WriteAllBytes(summary.ItlFile, newLibraryBytes);
        }

        private static string BytesToHex(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);
            foreach (var b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        private static byte[] StringToByteArray(String hex)
        {
            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
