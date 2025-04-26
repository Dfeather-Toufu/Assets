using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public  class SiginalBase <T> where T:new()
{
    static private T Value;
    static public T GetInstance()
    {
        if(Value==null)Value = new T();
        return Value;
    }
}
