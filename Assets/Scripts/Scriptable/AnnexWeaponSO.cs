using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum DamageType{
    GENERIC = 0,        //NOT INTENDED FOR NORMAL DAMAGE SOURCES
    PHYSICAL = 1,       //normal reliable damage, variable properties
    ELEMENTAL = 2,      //good picky damage, thematic properties
    CHAOTIC = 3,        //great damage, crazy properties
    RADIANT = 4         //ok damage, amazing properties
}

public class AnnexWeaponSO : AnnexItem
{
    public DamageType damageType;
    
    //IMPLEMENT SUGGESTIONS OR RANGES
    //public float weaponLevel {get; private set;}   //scaling to be implemented
    public float attackDamage;

    public float attackSpeedMultiplier = 1.00f;//for animation, should probably be on entity
    public float attackCooldown = 1f; //in seconds


    [Tooltip("MSM during attack animations")]
    public float activeMovementSpeedMultiplier = 0f;
    
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
