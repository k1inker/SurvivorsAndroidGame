using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField] private Tilemap _groundTilemap;
    [SerializeField] private TileBase _floorTile;
    [Header("BasicDirection")]
    [SerializeField] private TileBase _transitionFull;
    [SerializeField] private TileBase _transitionTop, _transitionBottom;
    [SerializeField] private TileBase _transitionRight, _transitionLeft;
    [Header("DiagonalDirection")]
    [SerializeField] private TileBase _transitionCornerUpLeft;
    [SerializeField] private TileBase _transitionCornerUpRight;
    [SerializeField] private TileBase _transitionCornerDownLeft, _transitionCornerDownRight;
    [SerializeField] private TileBase _transitionInnerCornerDownLeft, _transitionInnerCornerDownRight;
    [SerializeField] private TileBase _transitionInnerCornerUpLeft, _transitionInnerCornerUpRight;

    public void PaintGroundTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, _groundTilemap, _floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
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
    public void Clear()
    {
        _groundTilemap.ClearAllTiles();
    }
    public void PaintSingleBasicTransition(Vector2Int position, string binaryType)
    {
        int byteId = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (TransitionHelperType.transitionTop.Contains(byteId))
        {
            tile = _transitionTop;
        }
        else if (TransitionHelperType.transitionBottom.Contains(byteId))
        {
            tile = _transitionBottom;
        }
        else if (TransitionHelperType.transitionSideRight.Contains(byteId))
        {
            tile = _transitionRight;
        }
        else if (TransitionHelperType.transitionSideLeft.Contains(byteId))
        {
            tile = _transitionLeft;
        }
        else if (TransitionHelperType.transitionFull.Contains(byteId))
        {
            tile = _transitionFull;
        }

        if(tile != null)
            PaintSingleTile(_groundTilemap, tile, position);
    }
    public void PaintSingleCornerTransition(Vector2Int position, string binaryType)
    {
        int byteId = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if (TransitionHelperType.transitionInnerCornerDownRight.Contains(byteId))
        {
            tile = _transitionInnerCornerDownRight;
        }
        else if (TransitionHelperType.transtionInnerCornerDownLeft.Contains(byteId))
        {
            tile = _transitionInnerCornerDownLeft;
        }
        else if (TransitionHelperType.transitionDiagonalCornerDownLeft.Contains(byteId))
        {
            tile = _transitionCornerDownLeft;
        }
        else if (TransitionHelperType.transitionDiagonalCornerDownRight.Contains(byteId))
        {
            tile = _transitionCornerDownRight;
        }
        else if (TransitionHelperType.transitionDiagonalCornerUpLeft.Contains(byteId))
        {
            tile = _transitionCornerUpLeft;
        }
        else if (TransitionHelperType.transitionDiagonalCornerUpRight.Contains(byteId))
        {
            tile = _transitionCornerUpRight;
        }
        else if (TransitionHelperType.transtionInnerCornerUpRight.Contains(byteId))
        {
            tile = _transitionInnerCornerUpRight;
        }
        else if (TransitionHelperType.transtionInnerCornerUpLeft.Contains(byteId))
        {
            tile = _transitionInnerCornerUpLeft;
        }
        else if (TransitionHelperType.transitionFullEightDirections.Contains(byteId))
        {
            tile = _transitionFull;
        }
        else if (TransitionHelperType.transitionBottomEightDirections.Contains(byteId))
        {
            tile = _transitionBottom;
        }
        if (tile != null)
            PaintSingleTile(_groundTilemap, tile, position);
    }
}
