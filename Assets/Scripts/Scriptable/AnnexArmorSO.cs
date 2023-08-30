using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArmor", menuName = "Annex/New Armor Piece")]
public class AnnexArmorSo : AnnexItem
{ 


    public enum ArmorTier{
        COMMON = 1,
        UNCOMMON = 2,
        RARE = 3,
        VERY_RARE = 4,
        LEGENDARY = 5
    }

    public enum ArmorSlot{
        HEAD = 1,
        TORSO = 2,
        LEGS = 3
    }


    public ArmorTier armorTier;
    public ArmorSlot armorSlot;

    public AnnexWeaponSO.WeaponDamageType resistanceType; //can currently only take one at a time

    public float bonusHealth;//add health
    public float bonusSpeedMultiplier;//speed mods should scale additively

    void Awake(){
        if (armorSlot == ArmorSlot.HEAD)
            this.type = ItemType.ArmorHead;
        else if (armorSlot == ArmorSlot.TORSO)
            this.type = ItemType.ArmorChest;
        else if (armorSlot == ArmorSlot.LEGS)
            this.type = ItemType.ArmorLegs;
    }

    //other shit


}
