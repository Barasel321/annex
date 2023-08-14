using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnnexWeapon : ScriptableObject
{
    // Start is called before the first frame update

    public enum WeaponTier{
        COMMON = 1,
        UNCOMMON = 2,
        RARE = 3,
        VERY_RARE = 4,
        LEGENDARY = 5
    }

    public enum WeaponDamageType{
        BLUDGEONING = 0,    //normal, reliable
        PIERCING = 1,       //high damage, low armor pen
        SLASHING = 2,       //ok damage, high armor pen
        ELEMENTAL = 3,      //distinguishes races, custom effects
        CHAOTIC = 4,        //distinguishes races, custom properties reflect chaos
        RADIANT = 5         //ignores armor completely, highly picky with races
    }
    
    public WeaponTier tier;
    public WeaponDamageType damageType;
    
    //IMPLEMENT SUGGESTIONS OR RANGES
    public float weaponLevel;//scaling to be implemented
    public float attackDamage;
    public float attackSpeed;//atk/sec
    
    public float armorPenetration;//0-1


    private void OnEnable(){
        ;//do stuff when awake
    }
}
