using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using EBAC.StateMachine;
using Health;
using Core.Singleton;



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

    [Header("Life")]
    public HealthBase healthBase;
    public List<UIUpdater> UiUpdate;
    public List<Collider> colliders;
    public bool _alive = true;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;
    
    
    void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
    }

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

        UpdateUI();
        

    }
    private void OnPlayerKill()
    {
        if(_alive)
        {
            animator.SetTrigger("Death");
            healthBase.OnKill += OnPlayerKill;
            colliders.ForEach(i => i.enabled = false);
            _alive = false;


            Invoke(nameof(Revive), 3);
        }
    }
    private void Revive()
    {
        healthBase.Init();
        animator.SetTrigger("Idle");
        _alive = true;
        Respawn();
        Invoke(nameof(ResetColliders), 2);
    }

    public void ResetColliders()
    {
        colliders.ForEach(i => i.enabled = true);
    }

    public void UpdateUI()
    {
        UiUpdate.ForEach(i => i.UpdateValue(healthBase.startLife, healthBase._currentLife));
    }

    public void ResetLife()
    {
        healthBase._currentLife = healthBase.startLife;
    }

    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if(CheckpointManger.Instance.HasCheckpoint())
        {
            transform.position = CheckpointManger.Instance.GetPositionRespawn();
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
