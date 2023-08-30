using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Mathematics;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public interface InteractionAction{
    public void Interact(Transform interactor);
}

public class ThirdPersonAction : MonoBehaviour, Damageable
{
    // Start is called before the first frame update

    private PlayerInputHandler inputHandler;
    public PlayerCanvasHandler canvasHandler;

    private CharacterController controller;
    public Animator animator;
    public Transform cam;

    public float maxHealth = 10f;
    private float currentHealth;
    private bool isDead;

    public const float MOVEMENT_SPEED = 3.5f;
    private float currentSpeed;

    private float rotationSpeedMultiplier;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;
    
    Vector3 velocity;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool onGround;

    public LayerMask interactMask;

    public float interactDistance = 6f;

    bool targetFound = false;


    Weapon activeWeaponR;
    Weapon activeWeaponL;
    private int activeWeaponRI;
    private int activeWeaponLI;

    private int[] activeArmorI;
    
    private bool attacking = false;

    private int MAX_WEAPON_COUNT;

    // private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;



    void Awake(){

        inputHandler = gameObject.GetComponent<PlayerInputHandler>();
        controller = gameObject.GetComponent<CharacterController>();

        playerInputActions = new();
        playerInputActions.Player.Enable();
        
        activeWeaponRI = 0;
        activeWeaponLI = 0;
        isDead = false;

        currentHealth = maxHealth;
        currentSpeed = MOVEMENT_SPEED;

        rotationSpeedMultiplier = 1f;

        activeArmorI = new int[] {0,0,0};//HTL

        SwitchArmor(0,AnnexArmorSo.ArmorSlot.HEAD);
        SwitchArmor(0,AnnexArmorSo.ArmorSlot.TORSO);
        SwitchArmor(0,AnnexArmorSo.ArmorSlot.LEGS);

        SwitchWeaponR(0);
        //SwitchWeaponL(0);
    
        MAX_WEAPON_COUNT = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r").childCount;

    }

    public void Damage(float damage, Transform attacker = null){
        
        if (damage <= 0){
            return;
        }
        currentHealth = Mathf.Max(0, currentHealth - damage);
        canvasHandler.ChangeHealthBar(currentHealth);
        if (currentHealth == 0 && !isDead){
            isDead = true;
            animator.SetTrigger("isDead");
            currentSpeed = 0;
            rotationSpeedMultiplier = 0;
        }

    }

    public void Heal(float heal){

        if (heal <= 0){
            return;
        }
        currentHealth = Mathf.Min(maxHealth, currentHealth + heal);
        canvasHandler.ChangeHealthBar(currentHealth);
    }

    public void Jump(){

        if (onGround){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Sprint(){
        
        animator.SetBool("isRunning",!animator.GetBool("isRunning"));
        //if (animator.GetBool("isRunning")) animator.speed = 2; else animator.speed = 1;
        ResetSpeed();
    }

    private void ResetSpeed(){
        currentSpeed = animator.GetBool("isRunning") ? MOVEMENT_SPEED * 2 : MOVEMENT_SPEED;
    }


    public void Fire(){

        if(!attacking){
            rotationSpeedMultiplier = 0;
            attacking = true;
            animator.speed = activeWeaponR.annexWeaponSO.attackSpeedMultiplier;
            animator.SetTrigger("attack");
            currentSpeed *= activeWeaponR.annexWeaponSO.activeMovementSpeedMultiplier;
        }
        
    }

    public void FireHitbox(){
        activeWeaponR.onFire(transform, true);
    }
    
    public void AltFire(bool value){
        animator.SetBool("isShielding",value);
    }


    public void Interact(){
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
    
    public void Inventory(){
        canvasHandler.ToggleInventory();
    }

    //REDO!!!
    public void WeaponSwapUp(){
        
        SwitchWeaponR(activeWeaponRI+1 >= MAX_WEAPON_COUNT ? 0 : activeWeaponRI+1);
    }


    public void WeaponSwapDown(){
        
        SwitchWeaponR(activeWeaponRI <= 0 ? MAX_WEAPON_COUNT-1 : activeWeaponRI-1);
    }


    private void SwitchWeaponL(int weapon){
        
        if (activeWeaponL != null){
            activeWeaponL.gameObject.SetActive(false);
        }
        activeWeaponL = transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l/weapon_l").GetChild(weapon).GetComponent<Weapon>();
        activeWeaponL.gameObject.SetActive(true);

        activeWeaponLI = weapon;
    }

    private void SwitchWeaponR(int weapon){
        if (activeWeaponR != null){
            activeWeaponR.gameObject.SetActive(false);
        }
        activeWeaponR = transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r/weapon_r").GetChild(weapon).GetComponent<Weapon>();
        activeWeaponR.gameObject.SetActive(true);
    
        activeWeaponRI = weapon;
    }

    public void DoneAttacking(){
        attacking = false;
        animator.speed = 1;
    }

    public void StartAttackCooldown(){
        attacking = true;
        ResetSpeed();
        rotationSpeedMultiplier = 1f;
        Invoke("DoneAttacking",activeWeaponR.annexWeaponSO.attackCooldown/activeWeaponR.annexWeaponSO.attackSpeedMultiplier);
    }

    public void ArmorSwapUp(){
        //
    }

    public void ArmorSwapDown(){
        
    }

    public void SwitchArmor(int armorID, AnnexArmorSo.ArmorSlot slot){
        
        //fuck this
        switch (slot){
            case AnnexArmorSo.ArmorSlot.HEAD:{
                transform.Find("player_robot_scaled/rot/body/upper_body/head").GetChild(activeArmorI[0]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body/head").GetChild(armorID).gameObject.SetActive(true);

                transform.Find("player_robot_scaled/rot/body/upper_body/head/eyes").GetChild(activeArmorI[0]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body/head/eyes").GetChild(armorID).gameObject.SetActive(true);
                
                activeArmorI[0] = armorID;
                break;
            }
            
            case AnnexArmorSo.ArmorSlot.TORSO:{
                transform.Find("player_robot_scaled/rot/body").GetChild(activeArmorI[1]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body").GetChild(armorID).gameObject.SetActive(true);
                
                transform.Find("player_robot_scaled/rot/body/upper_body").GetChild(activeArmorI[1]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body").GetChild(armorID).gameObject.SetActive(true);
                
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_l").GetChild(activeArmorI[1]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_l").GetChild(armorID).gameObject.SetActive(true);
                
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l").GetChild(activeArmorI[1]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_l/elbow_l").GetChild(armorID).gameObject.SetActive(true);
                
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_r").GetChild(activeArmorI[1]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_r").GetChild(armorID).gameObject.SetActive(true);
                
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r").GetChild(activeArmorI[1]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/body/upper_body/arm_r/elbow_r").GetChild(armorID).gameObject.SetActive(true);
                
                activeArmorI[1] = armorID;
                break;
            }

            case AnnexArmorSo.ArmorSlot.LEGS:{
                
                transform.Find("player_robot_scaled/rot/leg_l").GetChild(activeArmorI[2]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/leg_l").GetChild(armorID).gameObject.SetActive(true);

                transform.Find("player_robot_scaled/rot/leg_l/knee_l").GetChild(activeArmorI[2]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/leg_l/knee_l").GetChild(armorID).gameObject.SetActive(true);
                
                transform.Find("player_robot_scaled/rot/leg_r").GetChild(activeArmorI[2]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/leg_r").GetChild(armorID).gameObject.SetActive(true);

                transform.Find("player_robot_scaled/rot/leg_r/knee_r").GetChild(activeArmorI[2]).gameObject.SetActive(false);
                transform.Find("player_robot_scaled/rot/leg_r/knee_r").GetChild(armorID).gameObject.SetActive(true);
                
                activeArmorI[2] = armorID;
                break;
            }
            

            default:{
                print("Armor Slot not found");
                break;
            }
            
        }
    }


    // Update is called once per frame
    void Update()
    {

        Vector2 hDirection = inputHandler.movementInput;

        //Horizontal Translation
        if (Mathf.Abs(hDirection.x) + Mathf.Abs(hDirection.y) >= 0.01f)
        {   
            animator.SetBool("isWalking",true);
            float targetAngle = Mathf.Atan2(hDirection.x, hDirection.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            transform.rotation = Quaternion.Euler(0f, smoothAngle * rotationSpeedMultiplier + transform.eulerAngles.y * (1-rotationSpeedMultiplier), 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(Time.deltaTime * currentSpeed * moveDirection.normalized);
        }
        else
        {
            animator.SetBool("isWalking",false);
        }

        //Vertical Translation aka gravity

        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (onGround && velocity.y < 0){
            velocity.y = Mathf.Min(-2,velocity.y/2);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
