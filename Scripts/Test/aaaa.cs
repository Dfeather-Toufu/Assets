using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface aaad
{
    void OnEnable();
    void Undate();
    void OnDisable();
}

public class ormalState : aaad
{
    aaaa hook_;

    public ormalState(aaaa hook)
    {
        this.hook_ = hook;
    }
    public void OnEnable()
    {
        hook_.isFire = true;
    }

     public void Undate()
    {
        hook_.StateTransfrom(aaaa.States.On);
    }


    public void OnDisable() {
        Debug.Log("1111");
    }
}

public class OnState:aaad
{
    aaaa hook;

    public OnState(aaaa hook)
    {
        this.hook = hook;
    }

    public void OnEnable()
    {

    }

    public void Undate()
    {
        Debug.Log("55555");
    }


    public void OnDisable()
    {
        
    }
}

public class aaaa: MonoBehaviour
{
    [SerializeField] private float sss;
    [HideInInspector] public float ss;
    public aaad nowState;
    [HideInInspector] public bool isFire = false;

    public enum States
    {
        On, ormal
    }

    private Dictionary<States, aaad> ssss = new Dictionary<States, aaad>();

    protected void Awake()
    {
        ssss.Add(States.On, new OnState(this));
        ssss.Add(States.ormal, new ormalState(this));
        nowState = new ormalState(this);
    }
    private void Update()
    {
        nowState.Undate();
    }
 

    public void StateTransfrom(States aim)
    {
        nowState.OnDisable();
        nowState = ssss[aim];
        nowState.OnEnable();
    }



}