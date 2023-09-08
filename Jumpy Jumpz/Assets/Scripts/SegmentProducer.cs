using UnityEngine;

public class SegmentProducer : MonoBehaviour
{

    public GameObject wallObstacle;
    public GameObject movingWallObstacle;
    public GameObject segment;

    private float segmentXPosition = 0f;

    private Vector3[] possiblePositions = new Vector3[]
    {
        new Vector3(10.9f, 5.98f, 2.43f), new Vector3(10.9f, 5.98f, 0f), new Vector3(10.9f, 5.98f, -2.43f),
        new Vector3(10.9f, 3.78f, -2.43f), new Vector3(10.9f, 3.78f, 0f), new Vector3(10.9f, 3.78f, 2.43f),
        new Vector3(10.9f, 1.51f, -2.43f), new Vector3(10.9f, 1.51f, 0f), new Vector3(10.9f, 1.51f, 2.43f)
    };
    private float xOffset = 0f;

    private int[] permutationOfPositions = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    private int minObstacles = 2;
    private int maxObstacles = 2;

    private int numberOfObstacleBlocks = 12;

    private float distanceObstacles = 14.0f;

    private int movingWallProbability = 20;

    // Start is called before the first frame update
    void Start()
    {

        ProduceSegment();
        ProduceSegment();
    }

    public void ProduceSegment()       
    {
        var rng = new System.Random();

        Instantiate(segment, new Vector3(segmentXPosition, 0f, 0f), Quaternion.identity);

        for (int i = 0;  i < numberOfObstacleBlocks; i++)
        {
            int numberOfObstacles = Random.Range(minObstacles, maxObstacles + 1);
            Shuffle(rng, permutationOfPositions);

            for (int j = 0; j < numberOfObstacles; j++)
            {
                Instantiate(wallObstacle, 
                            new Vector3(possiblePositions[permutationOfPositions[j]].x + xOffset, 
                                        possiblePositions[permutationOfPositions[j]].y,
                                        possiblePositions[permutationOfPositions[j]].z), 
                            Quaternion.identity);
            }
            xOffset += distanceObstacles;
        }

        segmentXPosition += 173f;
        maxObstacles++;

        if (maxObstacles == 4) minObstacles = 3;
        else if (maxObstacles - minObstacles == 3) minObstacles++;
    }

    void Shuffle<T>(System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
