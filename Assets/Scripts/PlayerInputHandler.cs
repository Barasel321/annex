using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public ThirdPersonAction thirdPersonAction;

    public Vector2 movementInput {get; private set;}

    void Awake(){
        playerInputActions = new();
        playerInputActions.Player.Enable();

        //playerInputActions.Player.Movement.performed += MovementPerformed;
        // playerInputActions.Player.Jump.performed += JumpPerformed;
        playerInputActions.Player.Sprint.performed += SprintPerformed;
        
        playerInputActions.Player.Fire.performed += FirePerformed;
        playerInputActions.Player.AltFire.performed += AltFirePerformed;
        playerInputActions.Player.AltFire.canceled += AltFireCanceled;
        playerInputActions.Player.Interact.performed += InteractPerformed;
        // playerInputActions.Player.WeaponSwapUp.performed += WeaponSwapUpPerformed;
        // playerInputActions.Player.WeaponSwapDown.performed += WeaponSwapDownPerformed;
        // playerInputActions.Player.ArmorSwapUp.performed += ArmorSwapUpPerformed;
        // playerInputActions.Player.ArmorSwapDown.performed += ArmorSwapDownPerformed;
        playerInputActions.Player.Inventory.performed += InventoryPerformed;
        
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    // private void JumpPerformed(InputAction.CallbackContext context){
    //     thirdPersonAction.Jump();
    // }

    private void SprintPerformed(InputAction.CallbackContext context){
        thirdPersonAction.Sprint();
    }

    private void FirePerformed(InputAction.CallbackContext context){
        thirdPersonAction.Fire();
    }

    private void AltFirePerformed(InputAction.CallbackContext context){
        thirdPersonAction.AltFire(true);
    }

    private void AltFireCanceled(InputAction.CallbackContext context){
        thirdPersonAction.AltFire(false);
    }

    private void InteractPerformed(InputAction.CallbackContext context){
        thirdPersonAction.Interact();
    }

    // private void WeaponSwapUpPerformed(InputAction.CallbackContext context){
    //     thirdPersonAction.WeaponSwapUp();
    // }

    // private void WeaponSwapDownPerformed(InputAction.CallbackContext context){
    //     thirdPersonAction.WeaponSwapDown();
    // }

    // private void ArmorSwapUpPerformed(InputAction.CallbackContext context){
    //     thirdPersonAction.ArmorSwapUp();
    // }

    // private void ArmorSwapDownPerformed(InputAction.CallbackContext context){
    //     thirdPersonAction.ArmorSwapDown();
    // }

    private void InventoryPerformed(InputAction.CallbackContext context){
        thirdPersonAction.Inventory();
    }
}
