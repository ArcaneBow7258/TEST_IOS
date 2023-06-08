using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    public List<Inventory_Slot> main;
    public List<Inventory_Slot> equip;
    public List<Inventory_Slot> hotbar;
    public Inventory_Slot selected;
    public Transform select;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    public void set_select(Inventory_Slot slot){
        select.SetParent(slot.transform);
        select.SetAsLastSibling();
        select.localPosition = Vector3.zero;
        selected = slot;
    }
}
