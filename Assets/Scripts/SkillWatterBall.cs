using System;
using TMPro.EditorUtilities;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;



public class SkillWatterBall : MonoBehaviour
{
    [SerializeField] private GameObject _bulletWatter;
    [SerializeField] private GameObject _player;
    
    [SerializeField] private GameObject _directionPlayer;
    
    private Vector2 _direction;
    private bool _isfacingRight;
    private int _skill;

    public float speed;
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
        UpDatePosi(speed);
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
