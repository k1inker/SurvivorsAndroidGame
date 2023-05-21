using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class AbstractGenerator : MonoBehaviour
{
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
    [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;
    [SerializeField] protected Vector3Int sizeMap;
    [SerializeField] protected int countIslandsPerChunk;
    [SerializeField] protected int sizeChunk;
    public void GenerateMap()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }
    protected abstract void RunProceduralGeneration();
}
