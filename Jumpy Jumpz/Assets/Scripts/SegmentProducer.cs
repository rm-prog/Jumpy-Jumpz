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
    private Vector3[] movingWallPossiblePositions = new Vector3[]
    {
        new Vector3(10.9f, 2.46f, 0f), new Vector3(10.9f, 4.76f, 0f)
    };
    private float xOffset = 0f;

    private int[] permutationOfPositions = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private int[] miniPermutation = { 0, 1, 2 };

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
            // Shuffle the positions of the wall obstacles
            // Put the wall obstacles in positions, from  the possiblePositions in order defined by the permutation
            // till numberOfObstacles Index

            // If true, add one moving wall obstacle alongside 1-3 wall obstacles
            if (Random.Range(1, 100) < movingWallProbability)
            {

                int movingWallPosition = Random.Range(0, 2);
                Instantiate(movingWallObstacle,
                            new Vector3(movingWallPossiblePositions[movingWallPosition].x + xOffset,
                                        movingWallPossiblePositions[movingWallPosition].y,
                                        movingWallPossiblePositions[movingWallPosition].z),
                            Quaternion.identity
                            );

                int numberOfWallObstacles = maxObstacles >= 3 ? Random.Range(0, maxObstacles - 1) : Random.Range(0, 3);

                Shuffle(rng, miniPermutation);
                for (int j = 0; j < numberOfWallObstacles; j++)
                {
                    if (movingWallPosition == 0)
                    {
                        Instantiate(wallObstacle,
                                    new Vector3(possiblePositions[miniPermutation[j]].x + xOffset,
                                                possiblePositions[miniPermutation[j]].y,
                                                possiblePositions[miniPermutation[j]].z),
                                    Quaternion.identity
                                    );
                    }
                    else
                    {
                        Instantiate(wallObstacle,
                                    new Vector3(possiblePositions[miniPermutation[j] + 6].x + xOffset,
                                                possiblePositions[miniPermutation[j] + 6].y,
                                                possiblePositions[miniPermutation[j] + 6].z),
                                    Quaternion.identity
                                    );
                    }
                }

            }
            else
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
            }

            xOffset += distanceObstacles;
        }

        segmentXPosition += 173f;
        maxObstacles++;
        movingWallProbability += movingWallProbability == 40 ? 0 : 5;
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
