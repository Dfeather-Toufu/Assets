using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EleDisturb : CoreWeponBase
{
    public float EffectDistance;
    public float Damage;
    [HideInInspector] public int level;
    [HideInInspector] public Animator animator;
    public override void Awake_Func()
    {
        base.Awake_Func();
        animator = GetComponent<Animator>();
    }

}
