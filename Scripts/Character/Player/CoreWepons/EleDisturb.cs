using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EleDisturb : CoreWeponBase
{
    public float EffectDistance;
    public float Damage;
    [HideInInspector]public CapsuleCollider2D CheckCycle;
    [HideInInspector] public int level;
    [HideInInspector] public Animator animator;
    public enum States{
        Normal,Fire
    }
    private Dictionary<States, ICoreWpeonsStateMacine> StateDic = new Dictionary<States, ICoreWpeonsStateMacine>();
    public override void Awake_Func()
    {
        base.Awake_Func();
        CheckCycle =GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        DistanceExchange(1);
        StateDic.Add(States.Normal,new EleNormal(this));
        StateDic.Add(States.Fire, new EleEnable(this));
        nowState=StateDic[States.Normal];
    }
    private void FixedUpdate()
    {
        nowState.FixedUpdate();
    }
    private void Update()
    {
        nowState.Update();
    }
    //×´Ì¬×ª»»º¯Êý
    public void StatesTrans_Func(States aim)
    {
        nowState.OnDisable();
        nowState = StateDic[aim];
        nowState.OnEnable();
    }
    //¹¥»÷¾àÀëÐÞ¸Ä
    public void DistanceExchange(float Xtime)
    {
        CheckCycle.size = EffectDistance * Xtime * Vector2.one;
    }
}
