namespace SlimDX.Multimedia
{
    public class WaveFormat
    {
        #region PROPERTIES

        public int AverageBytesPerSecond { get; set; }

        public short BitsPerSample { get; set; }

        public short BlockAlignment { get; set; }

        public short Channels { get; set; }

        public WaveFormatTag FormatTag { get; set; }

        public int SamplesPerSecond { get; set; }

        #endregion
    }
}