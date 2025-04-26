using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CoreWpeonsStateMacine 
{
    public void OnEnable();
    public void Update();
    public void FixedUpdate();
    public void OnDisable();
}
public class EleEnable:CoreWpeonsStateMacine
{
    EleDisturb Ele;
    EleEnable(EleDisturb eleDisturb)
    {
        Ele = eleDisturb;
    }
    public void OnEnable()
    {

    }
    public void Update()
    {

    }
    public void FixedUpdate()
    {

    }
    public void OnDisable()
    {

    }
}