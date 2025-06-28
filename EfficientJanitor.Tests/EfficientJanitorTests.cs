namespace EfficientJanitor.Tests;

public class Tests
{
    private EfficientJanitor _efficientJanitor;

    [SetUp]
    public void Setup()
    {
        _efficientJanitor = new EfficientJanitor();
    }

    [Test]
    public void Test0()
    {
        // Arrange
        List<float> weights = [1.01f, 1.01f, 1.01f, 1.4f, 2.4f];

        // Act
        int actualMinimumTrips = _efficientJanitor.FindMinimumTrips(weights);

        // Assert
        const int expectedMinimumTrips = 3;

        Assert.That(actualMinimumTrips, Is.EqualTo(expectedMinimumTrips));
    }

    [Test]
    public void Test1()
    {
        // Arrange
        List<float> weights = [1.01f, 1.991f, 1.32f, 1.4f];

        // Act
        int actualMinimumTrips = _efficientJanitor.FindMinimumTrips(weights);

        // Assert
        const int expectedMinimumTrips = 3;

        Assert.That(actualMinimumTrips, Is.EqualTo(expectedMinimumTrips));
    }

    [Test]
    public void Test2()
    {
        // Arrange
        List<float> weights = [2.02f, 2.95f, 1.14f, 2.13f, 1.86f, 1.45f, 1.5f, 2.77f, 1.55f, 1.49f, 1.2f, 2.89f, 2f, 1.75f, 2.56f, 2.05f, 2.19f, 1.11f, 1.81f, 2.45f, 1.37f, 2.67f, 1.63f, 1.89f, 1.76f, 2.05f, 2.98f, 2.53f, 2.15f, 1.21f, 2.43f, 2.21f, 2.15f, 2.85f, 1.28f, 2.17f, 1.52f, 1.33f, 2.14f, 2.93f, 1.39f, 2.83f, 1.19f, 1.21f, 1.09f, 1.77f, 2.93f, 2.53f, 1.4f, 2.49f, 2.81f, 2.05f, 2.48f, 2.47f, 1.95f, 1.41f, 2.12f, 2.45f, 1.68f, 1.57f, 1.66f, 1.69f, 1.68f, 2.93f, 1.27f, 1.77f, 2.97f, 1.89f, 2.15f, 1.37f, 1.35f, 2.05f, 1.12f, 1.37f, 2.89f, 2.05f, 1.11f, 2.23f, 2.6f, 1.33f, 1.42f, 1.31f, 1.89f, 2.33f, 1.94f, 1.47f, 2.29f, 2.61f, 2.92f, 2.45f, 1.89f, 1.49f, 2.34f, 2.63f, 1.82f, 2.53f, 1.59f, 2.03f, 1.92f, 1.65f, 2.17f, 2.67f, 1.43f, 1.17f, 1.61f, 2.51f, 2.48f, 2.25f, 1.56f, 2.39f, 2.12f, 2.61f, 2.76f, 1.93f, 1.71f, 2.57f, 2.77f, 2.47f, 2.36f, 2.05f, 1.5f, 1.25f, 1.98f, 1.41f, 1.46f, 1.63f, 2.67f, 1.57f, 2.25f, 1.31f, 1.41f, 2.45f, 1.47f, 2.93f, 1.46f, 1.73f, 1.82f, 2.07f, 1.86f, 1.05f, 2.29f, 1.35f, 1.98f, 1.97f, 2.4f, 1.53f, 2.65f, 2.29f, 1.12f, 1.35f, 1.45f, 2.77f, 2.61f, 2.63f, 1.96f, 2.25f, 2.14f, 1.87f, 1.94f, 2.93f, 2.88f, 2.19f, 2.02f, 2.53f, 1.38f, 1.27f, 2.11f, 1.49f, 2.2f, 1.83f, 1.32f, 2.25f, 1.65f, 2.37f, 2.57f, 2.29f, 2.29f, 1.09f, 2.99f, 1.01f, 1.73f, 1.89f, 2.47f, 1.09f, 2.69f, 2.71f, 2.73f, 1.69f, 1.31f, 1.23f, 2.36f, 2.29f, 1.1f, 1.99f, 1.44f, 2.89f, 1.32f, 1.93f, 1.72f, 1.17f];

        // Act
        int actualMinimumTrips = _efficientJanitor.FindMinimumTrips(weights);

        // Assert
        const int expectedMinimumTrips = 153;

        Assert.That(actualMinimumTrips, Is.EqualTo(expectedMinimumTrips));
    }
}
