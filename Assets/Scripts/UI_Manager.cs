using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    public GameObject UI_Inventory;
    void Awake(){
        
        if(Instance == null){
            Instance = this;
        }else{
            Debug.Log("You have two UI managers");
        }

        UI_Inventory.SetActive(false);

    }
    #region buttons
    public void button_build(){
        Game_Manager.Instance.game_state = (Game_Manager.Instance.game_state == GameState.building) ? GameState.playing : GameState.building;

    }
    public void button_inventory(){
        UI_Inventory.SetActive(!UI_Inventory.activeSelf);
    }


    #endregion
}
