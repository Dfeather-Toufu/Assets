using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoBase : MonoBehaviour
{
    public AmmoPool pool;
    [SerializeField] protected float speed;
    [SerializeField] protected float existTime;
    [SerializeField] protected float size;
    [SerializeField] protected Color color;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    protected virtual void FixedUpdate_Func()
    {

    }
    private void FixedUpdate()
    {
        FixedUpdate_Func();
    }
    public void SetOrigion_Func(float speed, Quaternion toQua, Vector3 beginPosition, float existTime, float size,Color color)
    {
        this.speed = speed;this.existTime = existTime;this.size = size;
        rb.position = beginPosition;this.transform.rotation = toQua;this.color = color;
    }
    public void SetOrigion_Func(float speed, Quaternion toQua, Vector3 beginPosition, float existTime, float size)
    {
        this.speed = speed; this.existTime = existTime; this.size = size;
        rb.position = beginPosition; this.transform.rotation = toQua;
    }
    public IEnumerator DestoryEnu()
    {
        yield return new WaitForSeconds(existTime);
        pool.GetInToPool_Fun(gameObject);
    }
}
