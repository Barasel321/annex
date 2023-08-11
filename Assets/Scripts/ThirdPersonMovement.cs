using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;
    public Transform cam;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 4f;

    public float smoothTime = 0.1f;
    
    Vector3 velocity;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool onGround;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;


    void Awake(){
        playerInputActions = new();
        playerInputActions.Player.Enable();

        //playerInputActions.Player.Movement.performed += MovementPerformed;
        playerInputActions.Player.Jump.performed += JumpPerformed;
        playerInputActions.Player.Fire.performed += FirePerformed;
        playerInputActions.Player.AltFire.performed += AltFirePerformed;
        playerInputActions.Player.AltFire.canceled += AltFireCanceled;
        
    }

/*
    private void MovementPerformed(InputAction.CallbackContext context){
        ;
    }
*/
    private void JumpPerformed(InputAction.CallbackContext context){
        if (!context.performed){
            return;
        }
        if (onGround){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void FirePerformed(InputAction.CallbackContext context){
        if (!context.performed){
            return;
        }
        animator.SetTrigger("attack");
    }
    
    private void AltFirePerformed(InputAction.CallbackContext context){
        animator.SetBool("isShielding",true);
        print("block");
    }

        private void AltFireCanceled(InputAction.CallbackContext context){
        animator.SetBool("isShielding",false);
        print("release");
    }
    


    // Update is called once per frame
    void Update()
    {
        Vector2 hDirection = playerInputActions.Player.Movement.ReadValue<Vector2>();

        //Horizontal Translation
        if (Mathf.Pow(hDirection.x,2) + Mathf.Pow(hDirection.y,2) >= 0.01f)
        {   
            animator.SetBool("isWalking",true);
            float targetAngle = Mathf.Atan2(hDirection.x, hDirection.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(Time.deltaTime * speed * moveDirection.normalized);
        }
        else
        {
            animator.SetBool("isWalking",false);
        }

        //Vertical Translation aka gravity

        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (onGround && velocity.y < 0){
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
}
