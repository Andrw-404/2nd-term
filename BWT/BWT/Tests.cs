namespace BWT
{
    public class Tests
    {
        public static bool RunTest()
        {
            var testArray = new (string name, Func<bool> test)[]
            {
                ("BWTFrontTest", BWTFrontTest),
                ("BWTInverseTest", BWTInverseTest),
            };

            foreach (var testFunctions in testArray)
            {
                if (!testFunctions.test())
                {
                    Console.WriteLine($"{testFunctions.name} failed the test");
                    return false;
                }
            }

            return true;
        }

        private static bool BWTFrontTest()
        {
            var (testString, testIndex) = BWTAlgorithm.FrontBWT("banana");
            string expectedString = "nnbaaa";
            int expectedIndex = 3;
            return testString == expectedString && testIndex == expectedIndex;
        }

        private static bool BWTInverseTest()
        {
            string testString = "nnbaaa";
            int testIndex = 3;
            string testResult = BWTAlgorithm.InverseBWT(testString, testIndex);
            string expectedString = "banana";
            return testResult == expectedString;
        }

    }
}
