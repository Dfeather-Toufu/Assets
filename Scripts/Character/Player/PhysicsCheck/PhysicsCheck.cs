using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
   public bool isGround;

    public LayerMask groundLayer;

    public float checkRaduis;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        isGround = Physics2D.OverlapCircle(transform.position, checkRaduis, groundLayer);
    }
}

