using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelAnimation : MonoBehaviour
{
    public ThirdPersonAction thirdPersonAction;

    public void AttackHitbox(){
        thirdPersonAction.FireHitbox();
    }

    public void AttackSoftEnd(){

        thirdPersonAction.DoneAttacking();
    
    }

    public void AttackHardEnd(){

        thirdPersonAction.StartAttackCooldown();

    }

}
