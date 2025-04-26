using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICoreWeponsStates
{
    void OnEnable();
    void Update();
    void FixedUpdate();
    void OnDisable();
}
public class CoreWeponBase : MonoBehaviour
{
    public float floatDistans;
    [SerializeField] protected GameObject owner;
    [SerializeField]protected Vector2 FixedFloatPosition;
    [SerializeField] protected Rigidbody2D ownerRb;
    private Rigidbody2D rb;
    private float timer;
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
