using System;
using TMPro.EditorUtilities;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;



public class SkillFireUlti : MonoBehaviour
{
    [SerializeField] private GameObject _bulletUltiFire;
    [SerializeField] private GameObject _player;
    
    [SerializeField] private GameObject _directionPlayer;
    
    private Vector2 _direction;
    private bool _isfacingRight;
    public float _speed;
    void Start()
    {
        _isfacingRight = this._directionPlayer.GetComponent<PlayerController>().GetDirection();
        if (_isfacingRight)
        {
            _direction = Vector2.right;
        }
        else
        {
            Flip();
            _direction = Vector2.left;
        }
        _direction.Normalize();
    } 
    
    void Update()
    {
            UpDatePosi(0f);
            StartCoroutine(UltiStartAfter(0.8f));
    }

    
    
    IEnumerator UltiStartAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        UpDatePosi(_speed);
    }
    
    private void UpDatePosi(float speed)
    {
        transform.Translate(_direction * Time.deltaTime * speed);
    }
    
    
    private void Flip()
    {
        Vector3 kich_thuoc = transform.localScale;
        kich_thuoc.x = -1 * kich_thuoc.x;
        transform.localScale = kich_thuoc;
    }
    public bool GetDirection()
    {
        return _isfacingRight;
    }
}