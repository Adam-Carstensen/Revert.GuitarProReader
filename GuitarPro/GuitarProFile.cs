namespace Revert.GuitarProReader.GuitarPro
{
    public class GuitarProFile
    {
        public Header Header { get; set; }
        public Body Body { get; set; }

        internal GuitarProFile() { }

        /* public static GuitarProFile Create(Stream stream)
         {
             //TODO: detect version
             return Gp5InputStream.Create(stream);
         }*/

    }
}
