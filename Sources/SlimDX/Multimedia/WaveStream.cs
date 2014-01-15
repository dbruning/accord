using System.IO;

namespace SlimDX.Multimedia
{
    public class WaveStream : Stream
    {
        #region CONSTRUCTORS

        public WaveStream(Stream stream)
        {
        }

        public WaveStream(string path)
        {
        }

        #endregion

        #region PROPERTIES

        public WaveFormat Format { get; private set; }

        public override bool CanRead
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool CanSeek
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool CanWrite
        {
            get { throw new System.NotImplementedException(); }
        }

        public override long Length
        {
            get { throw new System.NotImplementedException(); }
        }

        public override long Position { get; set; }

        #endregion

        #region METHODS

        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}