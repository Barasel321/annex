using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Go ahead, make a weapon with type ArmorHead, I dare you

//for display purposes, will probably replace with int
public enum ItemTier{
    COMMON = 1,
    UNCOMMON = 2,
    RARE = 3,
    VERY_RARE = 4,
    LEGENDARY = 5
}

public class AnnexItem : ScriptableObject
{
    public GameObject model;
    public Image icon;
    public ItemTier tier;
    public string displayName;//Annex Item
    [TextArea(15,15)]
    public string description;//This is the Annex Item\nAwesome

}
