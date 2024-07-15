using System;
using TMPro.EditorUtilities;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;



public class SkillWater1 : MonoBehaviour
{
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _layer1;
    [SerializeField] private GameObject _layer2;
    [SerializeField] private GameObject _layer3;
    [SerializeField] private GameObject _layer4;
    [SerializeField] private GameObject _layer5;
    [SerializeField] private GameObject _player;
    
    [SerializeField] private GameObject _directionPlayer;
    
    private Vector2 _direction;
    private bool _isfacingRight;
    public float _speed;

    

    void Start()
    {
        // _isfacingRight = this._directionPlayer.GetComponent<Boss>().GetDirection();
        // if (_isfacingRight)
        // {
        //     _direction = Vector2.right;
        // }
        // else
        // {
        //     Flip();
        //     _direction = Vector2.left;
        // }
        //_direction.Normalize();
        
        StartCoroutine(UpdateSkill(_speed, _layer1,_layer2, _layer3, _layer4, _layer5));
    } 

    private void FixedUpdate()
    {
        // StartCoroutine(UpdateSkill(_speed, _layer1,_layer2, _layer3, _layer4, _layer5));
    }

    void Skill()
    {
        _layer1.SetActive(true);
        Invoke("Layer2",_speed);
        Invoke("Layer3",_speed+0.5f);
        Invoke("Layer4",_speed+1f);
        Invoke("Layer5",_speed+1.5f);
    }
    
    private void Layer1()
    {
        _layer1.SetActive(true);
    }
    
    private void Layer2()
    {
        _layer1.SetActive(false);
        _layer2.SetActive(true);
    }
    
    private void Layer3()
    {
        _layer2.SetActive(false);
        _layer3.SetActive(true);
    }
    
    private void Layer4()
    {
        _layer3.SetActive(false);
        _layer4.SetActive(true);
    }
    
    private void Layer5()
    {
        _layer4.SetActive(false);
        _layer5.SetActive(true);
    }

    IEnumerator UpdateSkill(float seconds, GameObject l1, GameObject l2, GameObject l3,GameObject l4,GameObject l5)
    {
        l1.SetActive(true);
        yield return new WaitForSeconds(seconds);
        l1.SetActive(false);
        l2.SetActive(true);
        yield return new WaitForSeconds(seconds);
        l2.SetActive(false);
        l3.SetActive(true);
        yield return new WaitForSeconds(seconds);
        l3.SetActive(false);
        l4.SetActive(true);
        yield return new WaitForSeconds(seconds);
        l4.SetActive(false);
        l5.SetActive(true);
        //yield return new WaitForSeconds(seconds);
        
        
    }
    
    private void Flip()
    {
        Vector3 kich_thuoc = _main.transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        _main.transform.localScale = kich_thuoc;
    }
}
