namespace Routers.Tests
{
    class PrimAlgorithmTests
    {
        private string PrimtestFilePath = "FileForPrimTests.txt";

        [TearDown]
        public void Clean()
        {
            if (File.Exists(PrimtestFilePath))
            {
                File.Delete(PrimtestFilePath);
            }
        }

        [Test]
        public void FindMST_CorrectGraph_ShouldReturnCorrectMST()
        {
            var graph = new Graph();
            graph.AddEdges(new Edge(1, 2, 10));
            graph.AddEdges(new Edge(1, 3, 5));
            graph.AddEdges(new Edge(2, 3, 1));

            var mst = PrimAlgorithm.FindMaximumSpanningTree(graph);

            Assert.That(mst.Any(e => e.Start == 1 && e.End == 2 && e.Weight == 10), Is.True);
            Assert.That(mst.Any(e => e.Start == 1 && e.End == 3 && e.Weight == 5), Is.True);
        }

        [Test]
        public void FindMST_DisconnectedGraph_ShouldThrowException()
        {
            var graph = new Graph();
            graph.AddEdges(new Edge(1, 2, 10));
            graph.AddEdges(new Edge(1, 3, 5));
            graph.AddEdges(new Edge(6, 7, 1));

            Assert.Throws<InvalidOperationException>(() => PrimAlgorithm.FindMaximumSpanningTree(graph));
        }

        [Test]
        public void FindMST_ConnectedGraph_ShouldChooseAHigherWeight()
        {
            var graph = new Graph();
            graph.AddEdges(new Edge(1, 2, 10));
            graph.AddEdges(new Edge(1, 3, 5));
            graph.AddEdges(new Edge(1, 3, 20));
            graph.AddEdges(new Edge(2, 3, 1));

            var mst = PrimAlgorithm.FindMaximumSpanningTree(graph);

            Assert.That(mst.Count, Is.EqualTo(2));
            Assert.That(mst.Any(e => e.Start == 1 && e.End == 2 && e.Weight == 10), Is.True);
            Assert.That(mst.Any(e => e.Start == 1 && e.End == 3 && e.Weight == 20), Is.True);
        }
    }
}
