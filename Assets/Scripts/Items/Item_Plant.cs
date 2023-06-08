using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/Plant")]
public class Item_Plant: Item{
    public Sprite[] stages;
    [Tooltip("In Seconds")]
    public int growth_time;
}