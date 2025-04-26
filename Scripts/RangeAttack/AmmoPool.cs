using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    [SerializeField] private GameObject AmmoGo;
    private List<GameObject> ammoList=new List<GameObject>();
    private void Awake()
    {
        for(int i=0;i<10;++i)
        {
            GameObject temp = Instantiate(AmmoGo);
            temp.transform.parent = transform;
            ammoList.Add(temp);
        }
    }
    /// <summary>
    /// 将子弹存入池
    /// </summary>
    /// <param name="getin"></param>
    public void GetInToPool_Fun(GameObject getin)
    {
        if(ammoList.Count>=200)
        {
            Destroy(getin);
        }
        else
        {
            ammoList.Add(getin);
            getin.SetActive(false);
        }
    }
    /// <summary>
    /// 获取子弹
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="toQua"></param>
    /// <param name="beginPosition"></param>
    /// <param name="existTime"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public GameObject GetOutPool(float speed, Quaternion toQua, Vector3 beginPosition, float existTime, float size)
    {
        GameObject temp;
        if(ammoList.Count>0)
        {
            temp = ammoList[0];ammoList.Remove(temp);
        }
        else
        {
            temp=GameObject.Instantiate(AmmoGo);
        }
        temp.GetComponent<AmmoBase>().SetOrigion_Func(speed, toQua, beginPosition, existTime, size);
        temp.SetActive(true);
        return temp;
    }
}

