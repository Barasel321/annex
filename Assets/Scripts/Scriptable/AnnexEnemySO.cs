using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnexEnemySO : ScriptableObject
{

    public enum RaceType{
        NONE = 0,       //used for dummy, or non-enemies
        MACHINE = 1,    //High armor, slower, varied attacks
        BEASTIAL = 2,   //Low armor, hates elemental, aggresive
        DEMON = 3,      //Rare, deadly, varied attacks
        UNDEAD = 4     //Fodder, everywhere, whatever
    }

    public RaceType raceType;

    public float totalHealth;
    public float currentHealth;

    [Range(0,1)]
    public float armor;

    //more stuff, not bothered rn

}
