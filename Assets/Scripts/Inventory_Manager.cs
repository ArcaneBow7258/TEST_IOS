using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    public static Inventory_Manager Instance;
    public List<Inventory_Slot> main;
    public List<Inventory_Slot> equip;
    public List<Inventory_Slot> hotbar;
    public Inventory_Slot selected;
    public Transform select;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }else{
            Debug.Log("You have two inventory managers");
        }
    }
    public void Use(){
        if(selected.item.type != Item_Type.craftable  && selected.item.type != Item_Type.tool && selected.item.type != Item_Type.weapon){
            selected.stack -= 1;
            selected.validate();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)){
            set_select(hotbar[0]);
        }
        if(Input.GetKey(KeyCode.Alpha2)){
            set_select(hotbar[1]);
        }
        if(Input.GetKey(KeyCode.Alpha3)){
            set_select(hotbar[2]);
        }
        if(Input.GetKey(KeyCode.Alpha4)){
            set_select(hotbar[3]);
        }
    }
    public void set_select(Inventory_Slot slot){
        select.SetParent(slot.transform);
        select.SetAsLastSibling();
        select.localPosition = Vector3.zero;
        selected = slot;
    }
}
