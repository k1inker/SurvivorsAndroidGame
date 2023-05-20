using System;
using System.Collections.Generic;
using UnityEngine;

public static class GeneratorSandTransition
{
    public static void CreateTranstions(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        HashSet<Vector2Int> basicTranstionPositions = FindTransitionInDirection(floorPositions, Direction2D.cardinalDirectionList);
        HashSet<Vector2Int> cornerTranstionPositions = FindTransitionInDirection(floorPositions, Direction2D.diagonalDirectionList);

        CreateBasicTransition(tilemapVisualizer, basicTranstionPositions, floorPositions);
        CreateCornerTransition(tilemapVisualizer, cornerTranstionPositions, floorPositions);
    }

    private static void CreateCornerTransition(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerTranstionPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (Vector2Int position in cornerTranstionPositions)
        {
            string neighboursBinaryType = "";
            foreach (Vector2Int direction in Direction2D.eightDirectionList)
            {
                Vector2Int neughbourPosition = position + direction;
                if (floorPositions.Contains(neughbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleCornerTransition(position, neighboursBinaryType);
        }
    }

    private static void CreateBasicTransition(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicTranstionPositions, HashSet<Vector2Int> floorPositions)
    {
        foreach (Vector2Int position in basicTranstionPositions)
        {
            string neighboursBinaryType = "";
            foreach(Vector2Int direction in Direction2D.cardinalDirectionList)
            {
                Vector2Int neughbourPosition = position + direction;
                if(floorPositions.Contains(neughbourPosition))
                {
                    neighboursBinaryType += "1";
                }
                else
                {
                    neighboursBinaryType += "0";
                }
            }
            tilemapVisualizer.PaintSingleBasicTransition(position, neighboursBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindTransitionInDirection(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> tilePositions = new HashSet<Vector2Int>();
        foreach(Vector2Int position in floorPositions)
        {
            foreach(Vector2Int direction in directionList)
            {
                Vector2Int neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition) == false)
                    tilePositions.Add(neighbourPosition);
            }
        }
        return tilePositions;
    }
}
