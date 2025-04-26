using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrent : MonoBehaviour
{
    private Camera Thiscamera;
    private void Awake()
    {
        Thiscamera =GetComponent<Camera>();
    }
    void Start()
    {
        Camera.SetupCurrent(Thiscamera); 
    }
}
