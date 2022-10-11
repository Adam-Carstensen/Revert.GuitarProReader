using System;

namespace Revert.GuitarProReader.GuitarPro
{
    public class Header
    {
        internal const ushort VersionSize = 31;

        public Version Version { get; set; }
        public Tablature Tablature { get; set; }
        public Lyrics Lyrics { get; set; }
        public AddInfo AdditionalInfo { get; set; }
    }
}