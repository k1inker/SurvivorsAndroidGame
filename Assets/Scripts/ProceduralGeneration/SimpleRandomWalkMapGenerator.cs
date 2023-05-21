using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkMapGenerator : AbstractGenerator
{
    [SerializeField] private SimpleRandomWalkSO randomWalkParametrs;
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.PaintGroundTiles(floorPositions);

        tilemapVisualizer.PaintGroundTiles(FindTransitionInDirection(floorPositions, Direction2D.cardinalDirectionList));
        tilemapVisualizer.PaintGroundTiles(FindTransitionInDirection(floorPositions, Direction2D.diagonalDirectionList));
    }

    private HashSet<Vector2Int> RunRandomWalk()
    {
        Vector2Int currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for(int i = 0; i < randomWalkParametrs.iterations; i++)
        {
            HashSet<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParametrs.walkLength);
            floorPositions.UnionWith(path);
            if(randomWalkParametrs.startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0,floorPositions.Count)); 
            }
        }
        return floorPositions;
    }
    private static HashSet<Vector2Int> FindTransitionInDirection(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> tilePositions = new HashSet<Vector2Int>();
        foreach (Vector2Int position in floorPositions)
        {
            foreach (Vector2Int direction in directionList)
            {
                Vector2Int neighbourPosition = position + direction;
                if (!floorPositions.Contains(neighbourPosition))
                    tilePositions.Add(neighbourPosition);
            }
        }
        return tilePositions;
    }
}
