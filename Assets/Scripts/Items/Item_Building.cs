using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/Building", fileName = "build")]
public class Item_Building: ScriptableObject{
    public GameObject prefab;
    public Vector2Int size;
}
