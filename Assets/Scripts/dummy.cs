using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour, InteractionAction, Damageable
{
    // Start is called before the first frame update
    public Animator animator;

    public void Interact(Transform interactor){
        animator.SetTrigger("hit");
        transform.rotation = interactor.rotation;
    }

    public void Damage(float damage, Transform attacker = null){
        animator.SetTrigger("hit");
        if (attacker){
            transform.rotation = attacker.rotation;
        }
    }
}
