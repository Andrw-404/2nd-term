namespace Routers.Tests
{
    public class ReadFromFileTests
    {
        private string testFilePath = "FileForReadTest.txt";

        [TearDown]
        public void Clean()
        {
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void ReadFromFile_ValidInput_ShouldReturnCorrectGraph()
        {
            string inputForFile = "1: 2 (10), 3 (5)\n2: 3 (1)";
            File.WriteAllText(testFilePath, inputForFile);

            var graph = ReadFile.ReadFromFile(testFilePath);
            var edges = graph.GetAllEdges.ToList();

            Assert.That(graph.GetAllEdges.Count, Is.EqualTo(3));
            Assert.That(graph.GetAllVertexes.Count, Is.EqualTo(3));

            Assert.That(edges.Any(e => e.Start == 1 && e.End == 2 && e.Weight == 10), Is.True);
            Assert.That(edges.Any(e => e.Start == 1 && e.End == 3 && e.Weight == 5), Is.True);
            Assert.That(edges.Any(e => e.Start == 2 && e.End == 3 && e.Weight == 1), Is.True);
        }

        [Test]
        public void ReadFromFile_InvalidInput_ShouldIgnoreErrors()
        {
            string inputForFile = "dasda\n2: av (c_), 3 (1)";
            File.WriteAllText(testFilePath, inputForFile);

            var graph = ReadFile.ReadFromFile(testFilePath);
            var edges = graph.GetAllEdges.ToList();

            Assert.That(graph.GetAllEdges.Count, Is.EqualTo(1));
            Assert.That(graph.GetAllVertexes.Count, Is.EqualTo(2));

            Assert.That(edges.Any(e => e.Start == 2 && e.End == 3 && e.Weight == 1), Is.True);
        }

        [Test]
        public void ReadFromFile_EmptyInput_ShouldReturnEmptyGraph()
        {
            string inputForFile = " ";
            File.WriteAllText(testFilePath, inputForFile);

            var graph = ReadFile.ReadFromFile(testFilePath);
            var edges = graph.GetAllEdges.ToList();

            Assert.That(graph.GetAllEdges.Count, Is.EqualTo(0));
            Assert.That(graph.GetAllVertexes.Count, Is.EqualTo(0));
        }
    }
}
