using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ÎäÆ÷½Ó¿Ú
public interface ICoreWpeonsStateMacine 
{
    public void OnEnable();
    public void Update();
    public void FixedUpdate();
    public void OnDisable();
}
//µç´ÅµÄ¹¥»÷/Æô¶¯×´Ì¬
public class EleEnable:ICoreWpeonsStateMacine
{
    EleDisturb Ele;
    public EleEnable(EleDisturb eleDisturb)
    {
        Ele = eleDisturb;
    }
    public void OnEnable()
    {
        Ele.CheckCycle.enabled = true;
    }
    public void Update()
    {
        if(Input.GetMouseButtonUp(ControllerPerfence.A1mousenumber)||Input.GetKeyUp(ControllerPerfence.A1))
        {
            Ele.StatesTrans_Func(EleDisturb.States.Normal);
        }
    }
    public void FixedUpdate()
    {

    }
    public void OnDisable()
    {
        Ele.CheckCycle.enabled =false;
    }
}
//µç´ÅµÄÏÐÖÃ×´Ì¬
public class EleNormal : ICoreWpeonsStateMacine
{
    EleDisturb Ele;
    public EleNormal(EleDisturb eleDisturb)
    {
        Ele=eleDisturb;
    }
    public void FixedUpdate()
    {
        Ele.Follow_Func();
    }

    public void OnDisable()
    {
        
    }

    public void OnEnable()
    {
        
    }

    public void Update()
    {
        if(Input.GetKey(ControllerPerfence.A1)||Input.GetMouseButton(ControllerPerfence.A1mousenumber))
        {
            Ele.StatesTrans_Func(EleDisturb.States.Fire);
        }
    }
}