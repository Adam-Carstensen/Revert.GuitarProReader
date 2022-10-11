using Revert.Core.GuitarProReader.GuitarPro;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Revert.GuitarProReader.GuitarPro
{
    public class GpInputStream
    {
        protected Stream stream;
        protected Version Version { get; set; }

        public GpInputStream(Stream fileStream)
        {
            stream = fileStream;
        }

        internal Version GetVersionFromString()
        {
            var version = ReadString(31);
            const string versionHeader = "FICHIER GUITAR PRO v";
            var versionIndex = version.IndexOf(versionHeader, StringComparison.Ordinal);
            if (versionIndex == -1) throw new HeaderFileStructureException(SR.UnsupportedFileVersion);
            return new Version() { Major = version.Substring(versionIndex + versionHeader.Length, 1), Minor = version.Substring(versionIndex + versionHeader.Length + 2, 2) };
        }

        protected byte[] ReadBuffer(int size)
        {
            return ReadBuffer(0, size);
        }

        protected byte[] ReadBuffer(int position, int size)
        {
            byte[] buffer = new byte[size];
            stream.Read(buffer, position, size);
            return buffer;
        }

        /// <summary>
        /// Reads size bytes and interprets it as string
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        protected string ReadString(int size)
        {
            return Encoding.UTF8.GetString(ReadBuffer(size), 0, size);
        }

        /// <summary>
        /// Piece information is presented in the form of a block of data containing:
	    /// an integer representing the size of the stored information + 1;
	    /// the string of characters representing the data
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        protected string ReadHeaderEntry()
        {
            string headerEntry = ReadStringInteger();
            return string.IsNullOrEmpty(headerEntry) ? "" : headerEntry.Substring(1);
        }

        protected string ReadStringInteger()
        {
            int titleSize = BitConverter.ToInt32(ReadBuffer(sizeof(int)), 0);
            return titleSize > 0 ? Encoding.UTF8.GetString(ReadBuffer(titleSize), 0, titleSize) : "";
        }

        protected int ReadInt()
        {
            return BitConverter.ToInt32(ReadBuffer(sizeof(int)), 0);
        }

        protected byte ReadByte()
        {
            return (byte)stream.ReadByte();
        }

        protected string[] ReadStringArrayWithLength()
        {
            var size = ReadInt();
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
                array[i] = ReadHeaderEntry();

            return array;
        }

        protected void Skip(int bytes)
        {
            stream.Seek(bytes, SeekOrigin.Current);
        }

        protected Key ReadKey()
        {
            return (Key)(sbyte)ReadByte();
        }


        protected Duration ReadDuration()
        {
            return (Duration)(sbyte)ReadByte();
        }

        protected T ReadEnum<T>()
        {
            return (T)Enum.ToObject(typeof(T), (sbyte)ReadByte());
        }

        protected Color ReadColor()
        {
            byte red = (byte)stream.ReadByte();
            byte green = (byte)stream.ReadByte();
            byte blue = (byte)stream.ReadByte();
            byte alpha = (byte)stream.ReadByte();
            return Color.FromArgb(alpha, red, green, blue);
        }


    }
}