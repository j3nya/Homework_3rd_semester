using Parallel_Matrix_Multiplication;

public class MultiplicationTests
{
    [Test]
    public void CheckIfSequentialOnlyNaturalNumbersWorksRightly()
    {
        Assert.That(MultiplicationTest("6x5", "5x7", "6x5 * 5x7"));
    }

    [Test]
    public void CheckIfSequentialWithNegativeNumbersWorksRight()
    {
        Assert.That(MultiplicationTest("6x5", "5x12", "6x5 * 5x12"));
    }

    [Test]
    public void CheckIfConcurrentWorksRight()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MultiplicationTest("6x5", "5x7"));
            Assert.That(MultiplicationTest("6x5", "5x12"));
            Assert.That(MultiplicationTest("100x50", "50x50"));
            Assert.That(MultiplicationTest("1000x1000", "1000x2500"));
            Assert.That(MultiplicationTest("1000x2500", "2500x1490"));
        });
    }

    private bool MultiplicationTest(string firstOperandSize, string secondOperandSize, string correctResultForComparing)
    {
        var firstOperand = MatrixConverter.StringArrayToMatrix(File.ReadAllLines($"../../../TestMatrices/{firstOperandSize}.txt"));
        var secondOperand = MatrixConverter.StringArrayToMatrix(File.ReadAllLines($"../../../TestMatrices/{secondOperandSize}.txt"));
        var reference = MatrixConverter.StringArrayToMatrix(File.ReadAllLines($"../../../MultiplicationResultsForTests/{correctResultForComparing}.txt"));
        var product = ConcurrentMultiplicator.Multiplicate(firstOperand, secondOperand);
        return CompareMatrices(product, reference);
    }

    private bool MultiplicationTest(string firstOperandSize, string secondOperandSize)
    {
        var firstOperand = MatrixConverter.StringArrayToMatrix(File.ReadAllLines($"../../../TestMatrices/{firstOperandSize}.txt"));
        var secondOperand = MatrixConverter.StringArrayToMatrix(File.ReadAllLines($"../../../TestMatrices/{secondOperandSize}.txt"));
        var reference = SequentialMultiplicator.Multiplicate(firstOperand, secondOperand);
        var product = ConcurrentMultiplicator.Multiplicate(firstOperand, secondOperand);
        return CompareMatrices(product, reference);
    }

    private bool CompareMatrices(int[,] first, int[,] second)
    {
        if ((first.GetLength(0) != second.GetLength(0)) || (first.GetLength(1) != second.GetLength(1)))
        {
            return false;
        }

        for (int i = 0; i < first.GetLength(0); i++)
        {
            for (int j = 0; j < first.GetLength(1); j++)
            {
                if (first[i, j] != second[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
