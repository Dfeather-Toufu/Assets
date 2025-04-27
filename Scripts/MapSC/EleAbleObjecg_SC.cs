using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleAbleObjecg_SC : MonoBehaviour
{
    public float Size;
    private CapsuleCollider2D Collider;
    private void Awake()
    {
        Collider= gameObject.AddComponent<CapsuleCollider2D>();
        Collider.isTrigger = true;
        Collider.size = new Vector2(Size, Size);
    }
    protected virtual void GetEnable()
    {
        Collider.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GetEnable();
    }
}
