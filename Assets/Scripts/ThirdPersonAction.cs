using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;

public interface InteractionAction{
    public void Interact(Transform interactor);
}

public class ThirdPersonAction : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public Animator animator;
    public Transform cam;

    public LayerMask interactMask;

    public float interactDistance = 6f;

    bool targetFound = false;

    // private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;



    void Awake(){
        playerInputActions = new();
        playerInputActions.Player.Enable();

        //playerInputActions.Player.Movement.performed += MovementPerformed;
        playerInputActions.Player.Fire.performed += FirePerformed;
        playerInputActions.Player.AltFire.performed += AltFirePerformed;
        playerInputActions.Player.AltFire.canceled += AltFireCanceled;
        playerInputActions.Player.Interact.performed += InteractPerformed;
        
    }

    private void FirePerformed(InputAction.CallbackContext context){
        if (!context.performed){
            return;
        }
        animator.SetTrigger("attack");
    }
    
    private void AltFirePerformed(InputAction.CallbackContext context){
        animator.SetBool("isShielding",true);
    }

    private void AltFireCanceled(InputAction.CallbackContext context){
        animator.SetBool("isShielding",false);
    }

    private void InteractPerformed(InputAction.CallbackContext context){
        RaycastHit hit;
        
        targetFound = Physics.Raycast(transform.GetChild(1).position, transform.TransformDirection(Vector3.forward), out hit, interactDistance, interactMask);
        
        if (targetFound){
            if (((1 << hit.collider.gameObject.layer) & interactMask) != 0){
                print("toggled!");
                if(hit.collider.gameObject.TryGetComponent(out InteractionAction interactAction)){
                    interactAction.Interact(controller.transform);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
