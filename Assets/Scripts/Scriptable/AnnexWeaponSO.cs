using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Annex/New Weapon")]
public class AnnexWeaponSO : ScriptableObject
{

    //This doesn't mean shit
    public enum WeaponTier{
        COMMON = 1,
        UNCOMMON = 2,
        RARE = 3,
        VERY_RARE = 4,
        LEGENDARY = 5
    }

    //This also doesn't mean shit for now
    public enum WeaponDamageType{
        PHYSICAL = 1,       //normal reliable damage, variable properties
        ELEMENTAL = 2,      //good picky damage, thematic properties
        CHAOTIC = 3,        //great damage, crazy properties
        RADIANT = 4         //ok damage, amazing properties
    }
    
    public WeaponTier tier;
    public WeaponDamageType damageType;
    
    //IMPLEMENT SUGGESTIONS OR RANGES
    //public float weaponLevel {get; private set;}   //scaling to be implemented
    public float attackDamage;

    public float attackSpeedMultiplier = 1.00f;//for animation, should probably be on entity
    public float attackCooldown = 1f; //in seconds
    
    [Range(0,1)]
    public float armorPenetration; //LOOK AT THIS AGAIN
    
    public Vector3 hitboxScale = new Vector3(1,1,1);
    [Tooltip("Positioned (<left>,<up>,<forward>) relative to player's center")]
    public Vector3 hitboxPosition = new Vector3(0,1,1);
    public float hitboxSpeed; //Set 0 for melee
    public float hitboxLifetime = 0.2f; //In seconds


    private void OnEnable(){
        ;//do stuff when awake
    }
}
