using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveBase : MonoBehaviour
{

    private PhysicsCheck physicsCheck;
    public Vector2 InputDirection;
    public newinputsystem inputControl;
    public float MoveSpeed;
    public float JumpForce;
    public int faceDir =1;
    [HideInInspector] public Rigidbody2D rb;


    protected virtual void Awake_Func()
    {
        rb = GetComponent<Rigidbody2D>();
        inputControl = new newinputsystem();
        inputControl.Gameplay.Jump.started += Jump;
        physicsCheck = GetComponent<PhysicsCheck>();


    }
    private void Awake()
    {
        Awake_Func();
    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        InputDirection = inputControl.Gameplay.Movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(InputDirection.x * MoveSpeed * Time.deltaTime, rb.velocity.y);

        if (InputDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (InputDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Jump(InputAction.CallbackContext obj)
    {

        if (physicsCheck.isGround)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }
   

}
