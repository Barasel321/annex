using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArmor", menuName = "Annex/New Armor Piece")]
public class AnnexArmorSo : AnnexItem
{ 

    //deprecated
    public enum ArmorSlot{
        HEAD = 1,
        CHEST = 2,
        LEGS = 3
    }

    public ArmorSlot armorSlot;

    public DamageType resistanceType; //can currently only take one at a time

    public float bonusHealth;//add health
    public float bonusSpeedMultiplier;//speed mods should scale additively

    void Awake(){

        //deprecated
        if (armorSlot == ArmorSlot.HEAD)
            this.type = ItemType.ArmorHead;
        else if (armorSlot == ArmorSlot.CHEST)
            this.type = ItemType.ArmorChest;
        else if (armorSlot == ArmorSlot.LEGS)
            this.type = ItemType.ArmorLegs;
    }

    //other shit


}
