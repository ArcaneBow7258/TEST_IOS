using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Growth : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite[] stages;
    public int stage;
    [Tooltip("In Seconds")]
    public int growth_time = 0;
    public float growth_progress = 0;
    public System.DateTime growth_start;

    // Start is called before the first frame update
    void Start()
    {
        if(stages == null || stages.Length <= 1 || growth_time == 0) {this.enabled = false; return;}
        //this.Planted();
        
        
    }
    [ContextMenu("Plant")]
    public void Planted()
    {
        var pg = gameObject.GetComponent<Plant_Growth>();
        if(Game_Manager.Instance.plants.Contains(pg)) Game_Manager.Instance.plants.Remove(pg);
        stage = 0;
        sprite.sprite = stages[0];
        growth_progress = 0;
        growth_start = System.DateTime.UtcNow;
        Game_Manager.Instance.plants.Add(this);
    }
    [ContextMenu("Harvest")]
    void Harvest(){
        if(growth_progress < growth_time) return;
        Game_Manager.Instance.plants.Remove(this);
        Destroy(this);
        //Drop logics
    }
    // Update is called once per frame
    void Update()
    {
        if(stage >= stages.Length-1 || growth_start == null) return;
        int newStage = (int)Mathf.Floor( (stages.Length-1) * Mathf.Clamp((growth_progress / growth_time),0f, 1f));
        if (newStage != stage){
            stage = newStage;
            sprite.sprite = stages[stage];
        }
    }
}
