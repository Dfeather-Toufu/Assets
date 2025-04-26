using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreWeponBase : MonoBehaviour
{
    [SerializeField] protected GameObject owner;
    public float floatDistans;
    [SerializeField]protected Vector2 FixedFloatPosition;
    private Rigidbody2D rb;
    private float timer;
    [SerializeField]protected Rigidbody2D ownerRb;
    public virtual void Awake_Func()
    {
        timer = 0;
        rb=GetComponent<Rigidbody2D>();
        ownerRb=owner.GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        Awake_Func();
    }
    public virtual void Follow_Func()
    {
        timer += Time.deltaTime;
        rb.position = ownerRb.position + FixedFloatPosition + (Vector2.up * Mathf.Sin(timer)*floatDistans);
    }
    private void FixedUpdate()
    {
        Follow_Func();
    }
}
