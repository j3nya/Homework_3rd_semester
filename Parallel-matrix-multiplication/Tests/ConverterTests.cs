using Parallel_Matrix_Multiplication;

public class ConverterTests()
{
    [Test]
    public void CheckIfMethodCheckIfStringsIsInACorrectFormatReturnsFalse()
    {
        var matrix1 = File.ReadAllLines($"../../../TestMatrices/IncorrectFormat1.txt");
        var matrix2 = File.ReadAllLines($"../../../TestMatrices/IncorrectFormat2.txt");
        Assert.Multiple(() =>
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MatrixConverter.CheckIfStringsAreInACorrectFormat(matrix1));
            Assert.Throws<ArgumentException>(() => MatrixConverter.CheckIfStringsAreInACorrectFormat(matrix2));
        });
    }

    [Test]
    public void CheckIfMethodStringArrayToAndFromMatrixWorksCorrectly()
    {
        string[] matrixStringArrayRepresentation = ["1 2 3", "4 5 6", "7 8 9"];
        int[,] matrix =
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };
        Assert.Multiple(() =>
        {
            Assert.That(MatrixConverter.StringArrayToMatrix(matrixStringArrayRepresentation), Is.EqualTo(matrix));
            Assert.That(MatrixConverter.MatrixToStringArray(matrix), Is.EqualTo(matrixStringArrayRepresentation));
        });
    }
}