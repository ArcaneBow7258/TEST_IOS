using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    playing,
    building,

}
public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;
    public GameState game_state = GameState.playing;
    public List<Plant_Growth> plants= new List<Plant_Growth>();
    // Start is called before the first frame update
    void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Debug.Log("You have two game managers");
        }

    }

    // Update is called once per frame
    void Update()
    {
        plants.ForEach( plant => {if(plant.growth_progress < plant.growth_time) plant.growth_progress += Time.deltaTime;});
    }
}
