using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    ArmorHead,
    ArmorChest,
    ArmorLegs,
    WeaponMain,
    WeaponOff    
}
public class AnnexItem : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public string displayName;
    [TextArea(15,20)]
    public string description;

}
