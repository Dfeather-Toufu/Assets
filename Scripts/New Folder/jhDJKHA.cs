using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HookStateMachin
{
    void OnEnable();
    void FixedUpate();
    void Undate();
    void Odisable();
}
public class StateMachineTest : HookStateMachin
{
    public void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    public void FixedUpate()
    {
        Debug.Log("FixedUpate");
    }
    public void Undate()
    {
        Debug.Log("Undate");
    }
    public void Odisable()
    {
        Debug.Log("Odisable");
    }   
}