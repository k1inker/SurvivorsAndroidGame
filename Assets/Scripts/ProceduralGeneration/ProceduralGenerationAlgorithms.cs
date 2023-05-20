using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        Vector2Int previousPosition = startPosition;
        
        for(int i = 0; i < walkLength; i++)
        {
            Vector2Int newPosition = previousPosition + Direction2D.GetRandomDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0, 1), // up
        new Vector2Int(1, 0), // right
        new Vector2Int(0, -1), // down
        new Vector2Int(-1 , 0) // left
    };
    public static List<Vector2Int> diagonalDirectionList = new List<Vector2Int>
    {
        new Vector2Int(1, 1), // up-right
        new Vector2Int(1, -1), // right-down
        new Vector2Int(-1, -1), // down-left
        new Vector2Int(-1 , 1) // left-up
    };
    public static List<Vector2Int> eightDirectionList = new List<Vector2Int>
    {
        new Vector2Int(0, 1), // up
        new Vector2Int(1, 1), // up-right
        new Vector2Int(1, 0), // right
        new Vector2Int(1, -1), // right-down
        new Vector2Int(0, -1), // down
        new Vector2Int(-1, -1), // down-left
        new Vector2Int(-1 , 0), // left
        new Vector2Int(-1 , 1) // left-up
    };

    public static Vector2Int GetRandomDirection()
    {
        return cardinalDirectionList[Random.Range(0,cardinalDirectionList.Count)];
    }
}