using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/Plant", fileName = "plant")]
public class Item_Plant: Item_Building{
    public Sprite[] stages;
    [Tooltip("In Seconds")]
    public int growth_time;
}