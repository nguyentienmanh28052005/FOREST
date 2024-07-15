using UnityEngine;
using System;
using System.Collections;

public class DataSkillBoss1 : MonoBehaviour
{
    [SerializeField] private GameObject _skill1;
    [SerializeField] private GameObject _posi;
    [SerializeField] private GameObject _attack1;
    [SerializeField] private GameObject _attack2_1;
    [SerializeField] private GameObject _attack2_2;

    public void OnAttack1()
    {
        _attack1.SetActive(true);
    }

    public void OffAttack1()
    {
        _attack1.SetActive(false);
    }

    public void OnAttack2()
    {
        _attack2_1.SetActive(true);
        _attack2_2.SetActive(true);
    }

    public void OffAttack2()
    {
        _attack2_1.SetActive(false);
        _attack2_2.SetActive(false);
    }
    
    public void skillWater2()
    {
            Vector3 spon = _posi.transform.position;
            spon.y -= 0.4f;
            GameObject bullet =  Instantiate(this._skill1, spon, _posi.transform.rotation);
            bullet.gameObject.SetActive(true);
    }
}
