using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] Tilemap currentTilemap;
    TileBase currentTile
    {
        get
        {
            return LevelManager.instance.tiles[_selectedTileIndex];
        }
    }

    [SerializeField] Camera cam;
    
    int _selectedTileIndex;

    private void Update()
    {
        Vector3Int pos = currentTilemap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));
        if(Input.GetMouseButton(0)) PlaceTile(pos);
        if (Input.GetMouseButton(1)) DeleteTile(pos);

        if (Input.GetKeyDown(KeyCode.KeypadPlus)) 
        {
            _selectedTileIndex++;
            if (_selectedTileIndex >= LevelManager.instance.tiles.Count) _selectedTileIndex = 0;
            Debug.Log(LevelManager.instance.tiles[_selectedTileIndex].name); 
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) 
        {
            _selectedTileIndex--;
            if (_selectedTileIndex < 0) _selectedTileIndex = LevelManager.instance.tiles.Count - 1;
            Debug.Log(LevelManager.instance.tiles[_selectedTileIndex].name); 
        }

    }

    void PlaceTile(Vector3Int pos)
    {
        currentTilemap.SetTile(pos, currentTile);
    }

    void DeleteTile(Vector3Int pos)
    {
        currentTilemap.SetTile(pos, null);
    }
}
