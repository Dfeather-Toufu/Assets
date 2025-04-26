using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//基础状态机接口
public interface HookStateMachine
{
    void OnEnable();
    void FixedUpdate();
    /// <summary>
    /// 用于需要精确检测的判定等一类情况
    /// </summary>
    void Update();
    void OnDisable();
}
//发射状态
public class FireState:HookStateMachine
{
    Hook_SC hook;
    Vector2 temp;
    public  FireState(Hook_SC hook)
    {
        this.hook = hook;
    }
    public void OnEnable()
    {
        hook.isFire = true;
        temp =(1000*((Vector2)Camera.current.ScreenToWorldPoint(Input.mousePosition)-hook.rb.position)).normalized;
        hook.SetVe(temp);
    }
    public void FixedUpdate()
    {
        hook.rb.velocity= temp*hook.speed;
    }
    public void Update()
    {
        if (Vector2.Distance(hook.rb.position, hook.playerrb.position) > hook.farestDis)
        {
            hook.StateTransform_Func(Hook_SC.States.Normal);
        }
        if(hook.isCatch)
        {
            hook.StateTransform_Func(Hook_SC.States.Tie);
        }
    }
    public void OnDisable()
    {
        hook.isFire= false;
        hook.rb.velocity = Vector2.zero;
    }
}

//牵引状态
public class TieState:HookStateMachine
{
    Hook_SC hook;
    Vector2 hodeOnP;
    float hodeTime;
    public TieState(Hook_SC hook_)
    {
        hook = hook_;
    }
    public void OnEnable()
    {
        hodeTime = 0;
        hodeOnP =hook.rb.position;
        hook.playerrb.velocity = Vector2.zero;
    }
    public void FixedUpdate()
    {
        hodeTime +=Time.fixedDeltaTime;
        hook.rb.position = hodeOnP;
        hook.playerrb.velocity= Vector2.zero;hook.playerrb.gravityScale = 0;
        hook.playerrb.AddForce((1000*(hook.rb.position-hook.playerrb.position)).normalized*hook.Force);
    }
    public void Update()
    {
        if (Vector2.Distance(hook.rb.position, hook.playerrb.position) <=1 ||hodeTime>0.25)
        {
            hook.StateTransform_Func(Hook_SC.States.Normal);
        }
    }
    public void OnDisable()
    {
        hook.playerrb.gravityScale = 1;
        hook.isCatch=false;
    }
}
//闲置状态
public class NormalState:HookStateMachine
{
    Hook_SC hook;
    public NormalState(Hook_SC hook_)
    {
        hook = hook_;
    }
    public void OnEnable()
    {
        hook.rb.position = hook.Player.GetComponent<Rigidbody2D>().position;
    }
    public void FixedUpdate()
    {
        hook.NormalFixed_Func();
    }
    public void Update()
    {
        if (Input.GetKeyDown(ControllerPerfence.A1) || Input.GetMouseButtonDown(ControllerPerfence.A1mousenumber))
        {
            hook.StateTransform_Func(Hook_SC.States.Fire);
        }
    }
    public void OnDisable()
    {

    }
}

//主类
public class Hook_SC : WeponsRotate
{
    [SerializeField]private float checkDistance;
    [SerializeField]public float speed;
    public float Force;
    public float farestDis;
    [HideInInspector] public bool isCatch;
    public HookStateMachine nowState;
    private Collider2D collider2;
    [HideInInspector]public bool isFire=false;
    public enum States{
        Fire,Normal,Tie
    }
    private Dictionary<States,HookStateMachine>DicSta=new Dictionary<States,HookStateMachine>();    
    protected override void  Awake_Func()
    {
        base.Awake_Func();
        collider2 = GetComponent<Collider2D>();
        DicSta.Add(States.Tie,new TieState(this));
        DicSta.Add(States.Fire,new FireState(this));
        DicSta.Add(States.Normal, new NormalState(this));
        nowState=new NormalState(this);
    }
    //覆写更新函数，提供状态机的位置
    public override void FixedUpdate_Func()
    {
       nowState.FixedUpdate();
    }
    private void Update()
    {
        nowState.Update();
    }

    //设置朝向的函数
    public void SetVe(Vector2 disVe)
    {
        toVe = disVe;
    }

    //状态交换的函数
    public void StateTransform_Func(States aim)
    {
        nowState.OnDisable();
        nowState=DicSta[aim];
        nowState.OnEnable();
    }
    
    //继承父类的方向调转函数
    public  void NormalFixed_Func()
    {
        toVe = (1000 * ((Vector2)Camera.current.ScreenToWorldPoint(Input.mousePosition) - playerrb.position)).normalized;
        ToQua = Quaternion.Euler(0, 0, (Mathf.Atan2(toVe.y, toVe.x) + FixedRotate) * Mathf.Rad2Deg);
        rb.position = (Vector2)playerrb.position + (dis * (toVe * 1000).normalized);
        transform.rotation = ToQua;
    }
    //接触检测函数
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFire)
        {
            collision.GetComponent<HookPosition_SC>().Catch_Func(rb);
            isCatch = true;
        }
    }
}
