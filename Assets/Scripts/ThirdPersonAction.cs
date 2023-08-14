using System.Collections;
using System.Collections.Generic;
using System.Net;
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

    private int activeWeaponR;
    private int activeWeaponL;

    private int MAX_WEAPON_COUNT;

    // private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;



    void Awake(){
        playerInputActions = new();
        playerInputActions.Player.Enable();

        activeWeaponR = 0;
        activeWeaponL = 0;
        MAX_WEAPON_COUNT = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l/weapon_l").childCount;

        //playerInputActions.Player.Movement.performed += MovementPerformed;
        playerInputActions.Player.Fire.performed += FirePerformed;
        playerInputActions.Player.AltFire.performed += AltFirePerformed;
        playerInputActions.Player.AltFire.canceled += AltFireCanceled;
        playerInputActions.Player.Interact.performed += InteractPerformed;
        playerInputActions.Player.WeaponSwapUp.performed += WeaponSwapUpPerformed;
        playerInputActions.Player.WeaponSwapDown.performed += WeaponSwapDownPerformed;

        
    }

    private void FirePerformed(InputAction.CallbackContext context){

        animator.SetTrigger("attack");

        Transform weapon_r = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r").GetChild(activeWeaponR);

        weapon_r.GetComponent<Weapon>().onFire(transform);
        
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

    private void WeaponSwapUpPerformed(InputAction.CallbackContext context){
        
        SwitchWeaponR(activeWeaponR+1 >= MAX_WEAPON_COUNT ? 0 : activeWeaponR+1);
    }


    private void WeaponSwapDownPerformed(InputAction.CallbackContext context){
        
        SwitchWeaponR(activeWeaponR <= 0 ? MAX_WEAPON_COUNT-1 : activeWeaponR-1);
    }


    private void SwitchWeaponL(int weapon){
        Transform weapon_l = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l/weapon_l");
        weapon_l.GetChild(activeWeaponL).gameObject.SetActive(false);
        weapon_l.GetChild(weapon).gameObject.SetActive(true);

        activeWeaponL = weapon;
    }

    private void SwitchWeaponR(int weapon){
        Transform weapon_r = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r");
        weapon_r.GetChild(activeWeaponR).gameObject.SetActive(false);
        weapon_r.GetChild(weapon).gameObject.SetActive(true);
    
        activeWeaponR = weapon;
    }



    // Update is called once per frame
    void Update()
    {
        ;
    }
}
