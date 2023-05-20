using System;
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
        GeneratorSandTransition.CreateTranstions(floorPositions, tilemapVisualizer);
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
}
