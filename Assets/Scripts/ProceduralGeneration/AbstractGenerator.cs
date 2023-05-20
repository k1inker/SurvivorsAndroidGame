using System;
using UnityEngine;

public abstract class AbstractGenerator : MonoBehaviour
{
    [SerializeField] protected Vector2Int startPosition = Vector2Int.zero;
    [SerializeField] protected TilemapVisualizer tilemapVisualizer = null;
    
    public void GenerateMap()
    {
        tilemapVisualizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
