using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab;

    public int rows = 6;
    public int columns = 11;

    public float spacingX = 2.2f;
    public float spacingY = 1.2f;
    public float startY = 4f;

    public float minX = -10f;
    public float maxX = 10f;
    public float moveSpeed = 1.2f;

    private List<GameObject> allBricks = new List<GameObject>();
    private float direction = 1f;

    private static Queue<int> recentPatterns = new Queue<int>();

    Color[] colors =
    {
        new Color32(255,0,255,255),
        new Color32(157,0,255,255),
        new Color32(0,102,255,255),
        new Color32(0,255,255,255),
        new Color32(102,255,255,255),
        new Color32(255,80,180,255),
        new Color32(120,0,255,255)
    };

    void Start()
    {
        Random.InitState(
            System.DateTime.Now.Millisecond +
            System.DateTime.Now.Second +
            System.DateTime.Now.Minute
        );

        GeneratePattern();
    }

    void Update()
    {
        MoveBricksHorizontally();
    }

    void GeneratePattern()
    {
        float totalWidth = (columns - 1) * spacingX;
        float startX = -totalWidth / 2f;

        int patternType = GetUniquePattern();

        Debug.Log("Generated Pattern: " + patternType);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                bool shouldSpawn = false;

                switch (patternType)
                {
                    case 0: shouldSpawn = Mathf.Abs(col - 5) <= row; break;
                    case 1: shouldSpawn = Mathf.Abs(col - 5) == row || Mathf.Abs(col - 5) == (rows - row - 1); break;
                    case 2: shouldSpawn = row == col || col == columns - row - 1; break;
                    case 3: shouldSpawn = row == col || col == columns - row - 1 || row == 0 || row == rows - 1; break;
                    case 4: shouldSpawn = row == rows / 2 || col == columns / 2 || row == col || col == columns - row - 1; break;

                    case 5:
                        shouldSpawn =
                            (row == 0 && (col == 2 || col == 3 || col == 7 || col == 8)) ||
                            (row == 1 && col > 1 && col < 9) ||
                            (row >= 2 && Mathf.Abs(col - 5) <= rows - row);
                        break;

                    case 6:
                        shouldSpawn =
                            row == 0 ||
                            (row == 1 && (col == 1 || col == 5 || col == 9)) ||
                            (row == 2 && col > 1 && col < 9);
                        break;

                    case 7:
                        shouldSpawn =
                            Mathf.Abs(col - 2) <= row / 2 ||
                            Mathf.Abs(col - 8) <= row / 2;
                        break;

                    case 8:
                        shouldSpawn =
                            row == rows - 1 ||
                            col == 0 ||
                            col == columns - 1 ||
                            (row == 2 && col > 2 && col < 8);
                        break;

                    case 9:
                        shouldSpawn =
                            row == 0 || row == rows - 1 ||
                            col == 0 || col == columns - 1;
                        break;

                    case 10:
                        shouldSpawn =
                            Mathf.Abs(col - 5) <= 3 - row / 2;
                        break;

                    case 11:
                        shouldSpawn =
                            row == 0 ||
                            row == rows - 1 ||
                            (col == 2 && row > 0 && row < rows - 1) ||
                            (col == 8 && row > 0 && row < rows - 1);
                        break;

                    case 12:
                        shouldSpawn =
                            ((col - 5) * (col - 5)) / 9f +
                            ((row - 2.5f) * (row - 2.5f)) / 4f <= 1;
                        break;

                    case 13:
                        float val =
                            ((col - 5) * (col - 5)) / 9f +
                            ((row - 2.5f) * (row - 2.5f)) / 4f;
                        shouldSpawn = val >= 0.7f && val <= 1.1f;
                        break;

                    case 14:
                        shouldSpawn =
                            col >= 2 && col <= 8 &&
                            row >= 1 && row <= 4;
                        break;

                    case 15:
                        shouldSpawn =
                            (row == 1 || row == 4) && (col >= 2 && col <= 8) ||
                            (col == 2 || col == 8) && (row >= 1 && row <= 4);
                        break;

                    case 16:
                        shouldSpawn =
                            col >= row &&
                            col < columns - row;
                        break;

                    case 17:
                        shouldSpawn =
                            Mathf.Abs(col - 5) <= row &&
                            row != 2;
                        break;

                    case 18:
                        shouldSpawn =
                            row == rows / 2 ||
                            col == columns / 2;
                        break;

                    case 19:
                        shouldSpawn =
                            col == 2 || col == 5 || col == 8;
                        break;

                    case 20:
                        shouldSpawn =
                            row == col ||
                            col == columns - row - 1 ||
                            col == 5;
                        break;

                    case 21:
                        shouldSpawn =
                            row == 0 || row == rows - 1 ||
                            col == 0 || col == columns - 1;
                        break;

                    case 22:
                        shouldSpawn =
                            Mathf.Abs(col - 3) <= row / 2 ||
                            Mathf.Abs(col - 7) <= row / 2;
                        break;

                    case 23:
                        shouldSpawn =
                            Random.value > 0.18f &&
                            Mathf.Abs(col - 5) <= 4;
                        break;

                    case 24:
                        shouldSpawn =
                            Mathf.Abs(col - 3) <= 1 ||
                            Mathf.Abs(col - 7) <= 1;
                        break;

                    case 25:
                        shouldSpawn =
                            row == 0 ||
                            col == 5 ||
                            (row == 2 && col > 2 && col < 8);
                        break;

                    case 26:
                        shouldSpawn =
                            col == 5 ||
                            row == 0 ||
                            row == 1;
                        break;

                    case 27:
                        shouldSpawn =
                            col == 0 || col == 10 ||
                            (row == 5 && col > 2 && col < 8) ||
                            col == 5;
                        break;

                    case 28:
                        shouldSpawn =
                            Mathf.Abs(col - 2) <= row / 2 ||
                            Mathf.Abs(col - 5) <= row / 2 ||
                            Mathf.Abs(col - 8) <= row / 2;
                        break;

                    case 29:
                        shouldSpawn =
                            col == row + 2 ||
                            col == columns - row - 3 ||
                            row == rows - 1;
                        break;

                    case 30:
                        shouldSpawn =
                            row == 2 ||
                            (row == 1 && col > 2 && col < 8) ||
                            (row == 3 && col > 3 && col < 7);
                        break;

                    case 31:
                        shouldSpawn =
                            row == 0 ||
                            row == rows - 1 ||
                            col == 5;
                        break;

                    case 32:
                        shouldSpawn =
                            row == 2 || row == 4 ||
                            col == 3 || col == 7;
                        break;

                    case 33:
                        shouldSpawn =
                            row == col ||
                            col == columns - row - 1 ||
                            row == 0;
                        break;

                    case 34:
                        shouldSpawn =
                            (row == 0 || row == rows - 1 || col == 0 || col == columns - 1) &&
                            !(row == 0 && col == 5);
                        break;

                    case 35:
                        shouldSpawn =
                            (row % 2 == 0 && col < columns - 2) ||
                            (row % 2 != 0 && col > 1);
                        break;

                    case 36:
                        shouldSpawn =
                            (row == 1 && col > 1 && col < 9) ||
                            (row == 4 && col > 1 && col < 9) ||
                            col == 2 || col == 8;
                        break;

                    case 37:
                        shouldSpawn =
                            row == 0 ||
                            row == rows - 1 ||
                            (row % 2 == 0 && col > 2 && col < 8);
                        break;

                    case 38:
                        shouldSpawn =
                            row < 2 || row > 3 || col == 5;
                        break;

                    case 39:
                        shouldSpawn =
                            Random.value > 0.15f &&
                            Mathf.Abs(col - 5) <= 5;
                        break;

                    case 40:
                        shouldSpawn =
                            row == col ||
                            col == columns - row - 1;
                        break;

                    case 41:
                        shouldSpawn =
                            row == rows / 2 ||
                            col == columns / 2 ||
                            row == 1;
                        break;

                    case 42:
                        shouldSpawn =
                            Mathf.Abs(col - 5) <= 2 &&
                            row >= 1 && row <= 4;
                        break;

                    case 43:
                        shouldSpawn =
                            row == 0 ||
                            row == 5 ||
                            col == 5;
                        break;

                    case 44:
                        shouldSpawn =
                            Random.value > 0.2f;
                        break;
                }

                if (shouldSpawn)
                {
                    float xPos = startX + col * spacingX;
                    float yPos = startY - row * spacingY;

                    GameObject brick = Instantiate(
                        brickPrefab,
                        new Vector3(xPos, yPos, 0),
                        Quaternion.identity
                    );

                    SpriteRenderer sr = brick.GetComponent<SpriteRenderer>();

                    if (sr != null)
                    {
                        Color baseColor =
                            colors[Random.Range(0, colors.Length)];

                        float brightness =
                            Random.Range(0.9f, 1.3f);

                        sr.color = new Color(
                            Mathf.Clamp01(baseColor.r * brightness),
                            Mathf.Clamp01(baseColor.g * brightness),
                            Mathf.Clamp01(baseColor.b * brightness)
                        );
                    }

                    allBricks.Add(brick);
                }
            }
        }
    }

    // Better anti-repeat random system
    int GetUniquePattern()
    {
        List<int> availablePatterns = new List<int>();

        for (int i = 0; i < 45; i++)
        {
            if (!recentPatterns.Contains(i))
            {
                availablePatterns.Add(i);
            }
        }

        if (availablePatterns.Count == 0)
        {
            recentPatterns.Clear();

            for (int i = 0; i < 45; i++)
            {
                availablePatterns.Add(i);
            }
        }

        int randomIndex = Random.Range(0, availablePatterns.Count);
        int selectedPattern = availablePatterns[randomIndex];

        recentPatterns.Enqueue(selectedPattern);

        // pattern won't repeat before 10 levels
        if (recentPatterns.Count > 10)
        {
            recentPatterns.Dequeue();
        }

        return selectedPattern;
    }

    void MoveBricksHorizontally()
    {
        foreach (GameObject brick in allBricks)
        {
            if (brick == null) continue;

            brick.transform.position +=
                Vector3.right *
                moveSpeed *
                direction *
                Time.deltaTime;
        }

        float leftMost = Mathf.Infinity;
        float rightMost = -Mathf.Infinity;

        foreach (GameObject brick in allBricks)
        {
            if (brick == null) continue;

            float x = brick.transform.position.x;

            if (x < leftMost)
                leftMost = x;

            if (x > rightMost)
                rightMost = x;
        }

        if (rightMost >= maxX || leftMost <= minX)
        {
            direction *= -1;
        }
    }
}