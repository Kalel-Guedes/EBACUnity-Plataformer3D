using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using EBAC.StateMachine;



public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
    public Animator animator;
    public float jumpSpeed = 15f;
    public KeyCode keyJump = KeyCode.Space;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;
    

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(keyJump))
            {
                vSpeed = jumpSpeed;
            }
        }

        var isWalking = inputAxisVertical != 0;        
        if(isWalking)
        {
            if (Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }        
        }
        
        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        if (inputAxisVertical != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

   
        

    }
  

#region States

    public enum PlayerStates
        {
            WALK,
            IDLE
        }

    public StateMachine<PlayerStates> stateMachine;

    public void Init()
    {
        stateMachine = new StateMachine<PlayerStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(PlayerStates.WALK, new PlayerStatesIdle());
        stateMachine.RegisterStates(PlayerStates.IDLE, new PlayerStatesWalk());

        stateMachine.Switchstate(PlayerStates.IDLE);
    }
#endregion

    
}
