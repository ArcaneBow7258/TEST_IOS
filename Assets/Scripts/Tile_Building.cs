using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu( menuName ="Tile_Building")]
[System.Serializable]
public class Tile_Building : Tile
{
    public string id;
    public Tile_Type type;


    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }
    /*
    


    */
}
