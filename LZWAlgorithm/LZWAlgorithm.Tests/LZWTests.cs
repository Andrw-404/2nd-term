namespace LZWAlgorithm.Tests
{
    public class LZWTests
    {
        [Test]
        public void Compress_EmptyArray_ShouldReturnEmptyArray()
        {
            byte[] input = Array.Empty<byte>();
            int[] result = LZW.Compress(input);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Compress_SingleElementArray_ShouldReturnSingleCode()
        {
            byte[] input = { 65 };
            int[] result = LZW.Compress(input);

            Assert.That(result[0], Is.EqualTo(65));
        }

        [Test]
        public void Decompress_ValidCodes_ShouldReturnOriginalData()
        {
            int[] codes = { 65, 66, 256};
            byte[] result = LZW.Decompress(codes);

            Assert.That(result, Is.EqualTo(new byte[] { 65, 66, 65, 66 }));
        }

        [Test]
        public void Both_CompressThenDecompress_ShouldReturnOriginal()
        {
            byte[] input = { 67, 79, 77, 80, 82, 69, 83,83 };

            int[] compressed = LZW.Compress(input);
            byte[] decompressed = LZW.Decompress(compressed);

            Assert.That(decompressed, Is.EqualTo(input));
        }
    }
}
