using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScalers : MonoBehaviour
{
    /// <summary>
    /// ����ʱ����ʧ�ٶ�
    /// </summary>
    [SerializeField] float Timer;
    private void Update()
    {
        Time.timeScale = Timer;
    }
}
