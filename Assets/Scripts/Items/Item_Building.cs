using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/Building", fileName = "build")]
public class Item_Building: Item{
    public GameObject prefab;
    public Sprite[] altSprites;
    public Vector2Int size;
}
