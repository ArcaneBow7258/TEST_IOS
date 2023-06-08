using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public class TileType{
    public string name;
    public TileBase tile;
}
public class Tile_Grid : MonoBehaviour
{
    [Header("Refernces")]
    public static Tile_Grid Instance;
    public GridLayout gridLayout;
    public Tilemap Main;
    public Tilemap Temp;
    public Camera camera;
    [Header("Options")]
    public List<TileType> tile_pool;

    private Vector3Int cell_point_last;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Debug.Log("You have two tile_grid managers");
        }
        
    }

    private void Start(){

    }
    private void Update(){
        if(Game_Manager.Instance.game_state != GameState.building){Temp.ClearAllTiles(); return;}
        Vector3Int cell_point = gridLayout.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition));
        if(cell_point_last != cell_point && cell_point_last != null) Temp.DeleteCells(cell_point_last, Vector3Int.one);
        Temp.SetTile(cell_point, tile_pool.Find(x => x.name == "Red").tile);

        cell_point_last = cell_point;


    }
}
