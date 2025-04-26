using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public int faceDir =1;
    [HideInInspector] public Rigidbody2D rb;
    protected virtual void Awake_Func()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        Awake_Func();
    }

}
