using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private RuleTile _ultiateTilemap;
    
    [SerializeField] private Tilemap _groundTilemap;
    public void PaintGroundTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, _groundTilemap, _ultiateTilemap);
    }
    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(Vector2Int position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }
    public void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
    public void Clear()
    {
        _groundTilemap.ClearAllTiles();
    }
}
