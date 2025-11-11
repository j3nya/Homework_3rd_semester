namespace MD5.Tests;

public class CheckSumTests
{
    [Test]
    public void CheckIfConcurrentAndSequentialRealisationReturnsSameValue()
    {
        string filePath = "../../../FolderForTests";
        var bytesSequential = CheckSumSequentially.GetCheckSum(filePath);
        var bytesConcurrent = CheckSumConcurrently.GetCheckSum(filePath);

        Assert.That(bytesSequential, Is.EqualTo(bytesConcurrent));
    }
}
