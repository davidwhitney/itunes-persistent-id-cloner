using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using itunes_persistent_id_cloner.Core;

namespace itunes_persistent_id_cloner.Test.Unit.Core
{
    [TestFixture]
    public class LibraryLocatorTests
    {
        [Test]
        public void GenerateLibrarySummary_WhenCalledWithNoParameters_LoadsFromCurrentUserContext()
        {
            var adapter = new TunesLibraryAdapter();

            var location = adapter.GenerateLibrarySummary();

            Assert.That(location, Is.Not.Null);
        }

        [Test]
        public void Patch_WhenCalledWithNoParameters_LoadsFromCurrentUserContext()
        {
            var adapter = new TunesLibraryAdapter();

            adapter.PatchLibraryToPersistentId("0352D98CCD98774B");
        }
    }
}
