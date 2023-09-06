using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public enum Tile_Type{
    wall,
    floor,
    plant,
}

// its a manager i just didnt name it right.
public class Tile_Grid : MonoBehaviour
{
    private Color trans = new Color(1,1,1,0.6f);
    [Header("Refernces")]
    public static Tile_Grid Instance;
    public GridLayout gridLayout;
    public Tilemap Main;
    public Tilemap Temp;
    public Camera camera;
    [Header("Options")]
    public List<TileBase> tile_pool;
    private List<Tile_Building> building_pool;
    private List<TileBase> plant_pool;
    private Vector3Int cell_point_last;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Debug.Log("You have two tile_grid managers");
        }
        
    }

    public void Build(Vector3Int point){
        
        Main.SetTile(point, tile_pool.Find(x => ((Tile_Building)x).id == Inventory_Manager.Instance.selected.item.id));
        if( Inventory_Manager.Instance.selected.item.type == Item_Type.plant){
            Main.GetInstantiatedObject(point).GetComponent<Plant_Growth>().Planted();
        }
        Inventory_Manager.Instance.Use();
        
    }
    
    private void Update(){
        if(Game_Manager.Instance.game_state != GameState.building){
            Temp.ClearAllTiles(); 
            Main.GetComponent<TilemapRenderer>().enabled = false;
            return;}
    if(Inventory_Manager.Instance.selected.item == null ||(Inventory_Manager.Instance.selected.item.type != Item_Type.building && Inventory_Manager.Instance.selected.item.type != Item_Type.plant )){
     Temp.ClearAllTiles(); 
     return;
     } 
        //GO
        Main.GetComponent<TilemapRenderer>().enabled = true;
        Vector3Int cell_point = gridLayout.WorldToCell(camera.ScreenToWorldPoint(Input.mousePosition));
        if(cell_point_last != cell_point && cell_point_last != null) Temp.DeleteCells(cell_point_last, Vector3Int.one);

        if(Main.GetTile<Tile_Building>(cell_point) != null ){
            Temp.SetTile(cell_point, tile_pool.Find(x => ((Tile_Building)x).id == "Red_1"));
            
        }else{
            Temp.SetTile(cell_point, tile_pool.Find(x => ((Tile_Building)x).id == "Green_1"));
        }
       
        // setting gameobject since we;re using the red/green base
        var temp =   ((Tile_Building)Temp.GetTile(cell_point));
        if(temp.gameObject == null){
            temp.gameObject = Instantiate(((Item_Building)Inventory_Manager.Instance.selected.item).prefab);
        }
        
        //if that go has a collider disable for pass through
        var go =temp.gameObject;
        if(go != null){
            Collider2D collider = go.GetComponent<Collider2D>();
            if(collider != null) collider.enabled = false;
            
        }
        cell_point_last = cell_point;
        if(Input.GetKeyDown(KeyCode.E) && Inventory_Manager.Instance.selected.stack > 0){
            this.Build(cell_point);
        }

    }
}
