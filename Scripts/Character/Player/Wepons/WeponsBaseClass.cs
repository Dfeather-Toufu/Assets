using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeponsBase 
{
    void FixedUpdate();
    void OnDisable();
    void OnEnable();
}
public class HookBase_SC : IWeponsBase
{
    WeponsRotate temp;
    HookBase_SC(WeponsRotate par)
    {
        temp = par;
    }

    public void FixedUpdate()
    {
       
    }

    public void OnDisable()
    {
        
    }

    public void OnEnable()
    {
        
    }
}