using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPosition_SC : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D thisCollder;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        thisCollder = GetComponent<Collider2D>();
        rb.gravityScale = 0;
        this.tag=rb.gameObject.tag;
    }
    /// <summary>
    /// ����סʱ�����ĺ���������צת�Ƶ����Ĵ���ͬʱ������ײ��ͣ�õļ�ʱ��
    /// </summary>
    /// <param name="Hookrb"></param>
    public void Catch_Func(Rigidbody2D Hookrb)
    {
        Hookrb.position = rb.position;
        StartCoroutine(Disable_Timer());
    }
    //��ʱ����
     private IEnumerator Disable_Timer()
    {
        thisCollder.enabled = false;
        yield return new WaitForSeconds(0.5f);
        thisCollder.enabled = true;
    }
}
