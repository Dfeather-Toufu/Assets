using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeponsRotate: MonoBehaviour
{
    public float dis; public GameObject Player;
    [SerializeField] private float FixedPosition;
    [SerializeField] protected float FixedRotate;
    [HideInInspector]public Rigidbody2D rb;
    [HideInInspector] public Quaternion ToQua;
    [SerializeField] public Rigidbody2D playerrb;
    [HideInInspector]public Vector2 toVe;
    protected virtual void Awake_Func()
    {
        playerrb=Player.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        Awake_Func();
    }
    public virtual void FixedUpdate_Func()
    {
        toVe = (1000*((Vector2)Camera.current.ScreenToWorldPoint(Input.mousePosition)-playerrb.position)).normalized;
        ToQua = Quaternion.Euler(0, 0, (Mathf.Atan2(toVe.y, toVe.x) + FixedRotate) * Mathf.Rad2Deg);
        rb.position = (Vector2)playerrb.position+(dis*(toVe*1000).normalized);
        transform.rotation = ToQua;
    }
    private void FixedUpdate()
    {
        FixedUpdate_Func();
    }
}
