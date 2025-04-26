using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreWeponBase : MonoBehaviour
{
    [SerializeField] protected GameObject owner;
    public float floatDistans;
    private Rigidbody2D rb;
    protected Rigidbody2D ownerRb;

    public virtual void Awake_Func()
    {
        rb=GetComponent<Rigidbody2D>();
        ownerRb=owner.GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        Awake_Func();
    }
    public virtual void Follow_Func()
    {

    }
}
