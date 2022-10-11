using System;
using System.Collections.Generic;
using System.Text;

namespace Revert.GuitarProReader
{
    public class TabMetaData
    {
        public string Author { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Author} : {Title}";
        }
    }
}
