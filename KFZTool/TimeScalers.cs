using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScalers : MonoBehaviour
{
    /// <summary>
    /// 调整时间流失速度
    /// </summary>
    [SerializeField] float Timer;
    private void Update()
    {
        Time.timeScale = Timer;
    }
}
