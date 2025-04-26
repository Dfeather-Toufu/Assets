using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fpser : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        text.text = "FPS:" +(float)(1/Time.fixedDeltaTime);
    }
}
