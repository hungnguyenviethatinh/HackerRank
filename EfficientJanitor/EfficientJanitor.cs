namespace EfficientJanitor;

public class EfficientJanitor
{
    private const float MAX_WEIGHT_PER_TRIP = 3.0f;

    public int FindMinimumTrips(List<float> weights)
    {
        int minimumTrips = Solution1(weights);

        return minimumTrips;
    }

    private static int Solution1(List<float> weights)
    {
        weights.Sort();

        int minimumTrips = 0;
        int left = 0;
        int right = weights.Count - 1;

        while (left <= right)
        {
            minimumTrips++;

            if (weights[left] + weights[right] <= MAX_WEIGHT_PER_TRIP)
            {
                left++;
            }

            right--;
        }

        return minimumTrips;
    }
}
