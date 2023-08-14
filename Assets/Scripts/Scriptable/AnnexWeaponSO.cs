using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Annex/New Weapon")]
public class AnnexWeaponSO : ScriptableObject
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
    //public float weaponLevel {get; private set;}   //scaling to be implemented
    public float attackDamage;

    //to be redone
    public float attackSpeed;   //atk/sec
    
    [Range(0,1)]
    public float armorPenetration;

    
    public Vector3 hitboxScale = new Vector3(1,1,1);
    public Vector3 hitboxPosition = new Vector3(0,0,0);
    public float hitboxSpeed; //Set 0 for melee
    public float hitboxLifetime = 0.2f; //In seconds


    private void OnEnable(){
        ;//do stuff when awake
    }
}
