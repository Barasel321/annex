using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnexArmorSo : ScriptableObject
{ 

    public String armorName;//Default Armor, Woods Armor
    public String armorID;//default, woods

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

    //other shit


}
