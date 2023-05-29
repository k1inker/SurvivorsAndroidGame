using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
    [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;

    [Header("Setup Generation Map")]
    [SerializeField] protected Vector3Int sizeMap;
    [SerializeField] protected int countIslandsPerChunk;
    [SerializeField] protected int sizeChunk;

    [Header("Resource Generation")]
    [SerializeField] private SimpleRandomWalkSO randomWalkParametrs;
    [SerializeField] private GameObject[] propsObject;
    [SerializeField] private Transform containerProps;
    private void Awake()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }
    protected void RunProceduralGeneration()
    {
        tilemapVisualizer.PaintFillGround(sizeMap);
        for (int i = -sizeMap.x; i < sizeMap.x; i += sizeChunk)
        {
            for (int j = -sizeMap.y; j < sizeMap.y; j += sizeChunk)
            {
                int minX = i;
                int maxX = i + sizeChunk;
                int minY = j;
                int maxY = j + sizeChunk;
                GenerationOneChunk(minX, maxX, minY, maxY);
            }
        }
    }
    private void GenerationOneChunk(int minX, int maxX, int minY, int maxY)
    {
        int x = Random.Range(minX, maxX);
        int y = Random.Range(minY, maxY);

        for (int i = 0; i < countIslandsPerChunk; i++)
        {
            x = Random.Range(minX, maxX);
            y = Random.Range(minY, maxY);
            GenerationOneSandIsland(new Vector2Int(x, y));
        }

        GenerationRandomProp(new Vector2(x, y));
    }
    private void GenerationRandomProp(Vector2 spawnPoint)
    {
        int randomID = Random.Range(0, propsObject.Length - 1);
        Instantiate(propsObject[randomID], spawnPoint, Quaternion.identity, containerProps);
    }
    private void GenerationOneSandIsland(Vector2Int startPosition)
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(startPosition);

        tilemapVisualizer.PaintGroundTiles(floorPositions);

        tilemapVisualizer.PaintGroundTiles(FindTransitionInDirection(floorPositions, Direction2D.cardinalDirectionList));
        tilemapVisualizer.PaintGroundTiles(FindTransitionInDirection(floorPositions, Direction2D.diagonalDirectionList));
    }
    private HashSet<Vector2Int> RunRandomWalk(Vector2Int startPosition)
    {
        Vector2Int currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParametrs.iterations; i++)
        {
            HashSet<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParametrs.walkLength);
            floorPositions.UnionWith(path);
            if (randomWalkParametrs.startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
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
