using System;
using System.Collections.Generic;
using System.Text;

namespace Revert.GuitarProReader.Json
{
    public class TabJson
    {
        public string name { get; set; }
        public string artist { get; set; }
        public int tempo { get; set; }
        public Track[] tracks { get; set; }
    }
}

