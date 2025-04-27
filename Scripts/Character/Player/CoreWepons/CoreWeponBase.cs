using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoreWeponBase : MonoBehaviour
{
    public float floatDistans;
    [SerializeField] protected GameObject owner;
    [SerializeField]protected Vector2 FixedFloatPosition;
    protected Rigidbody2D ownerRb;
    protected ICoreWpeonsStateMacine nowState;
    protected Rigidbody2D rb;
    private float timer;//悬浮记时变量
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
    /// <summary>
    /// 跟随悬浮函数
    /// </summary>
    public virtual void Follow_Func()
    {
        timer += Time.deltaTime;
        rb.position = ownerRb.position + FixedFloatPosition + (Vector2.up * Mathf.Sin(timer)*floatDistans);
    }
    public virtual void AttackFollow_Func()
    {
        rb.position = ownerRb.position + FixedFloatPosition;
    }
}
