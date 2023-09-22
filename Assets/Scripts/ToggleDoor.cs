using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : MonoBehaviour, InteractionAction
{
    // Start is called before the first frame update
    public Animator animator;
    
    public void Interact(Transform interactor){
        animator.SetTrigger("toggleDoor");
        // print("success?");
    }
}
