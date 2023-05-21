using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private RuleTile _ultiateTile;
    [SerializeField] private TileBase _groundTile;
    
    [SerializeField] private Tilemap _groundTilemap;
    public void PaintGroundTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, _groundTilemap, _ultiateTile);
    }
    public void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach(Vector2Int position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }
    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
    public void PaintFillGround(Vector3Int size)
    {
        _groundTilemap.FloodFill(size, _groundTile);
        _groundTilemap.FloodFill(-size, _groundTile);
        _groundTilemap.FloodFill(new Vector3Int(-size.x,size.y), _groundTile);
        _groundTilemap.FloodFill(new Vector3Int(size.x,-size.y), _groundTile);
    }
    public void Clear()
    {
        _groundTilemap.ClearAllTiles();
    }
}
