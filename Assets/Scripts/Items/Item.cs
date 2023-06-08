using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item_Type{
    plant,
    weapon,
    building,
    craftable,
    tool,
}

public abstract class Item: ScriptableObject{
    public int stack_size;
    public Sprite inventory_image;
    public Item_Type type;
}

