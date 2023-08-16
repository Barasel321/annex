using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        PHYSICAL = 1,       //normal reliable damage, variable properties
        ELEMENTAL = 2,      //
        CHAOTIC = 3,        //
        RADIANT = 4         //
    }
    
    public WeaponTier tier;
    public WeaponDamageType damageType;
    
    //IMPLEMENT SUGGESTIONS OR RANGES
    //public float weaponLevel {get; private set;}   //scaling to be implemented
    public float attackDamage;


    public float attackSpeedMultiplier = 1.00f;//for animation,
    public float attackCooldown = 1; //in seconds
    
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
