using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] float _dashingVelocity = 5f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;
    private TrailRenderer _trailRenderer;
    private Rigidbody2D _rb;
    
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var dashInput = Input.GetKeyDown(KeyCode.M);
        if (dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());
        }

        if (_isDashing)
        {
            _rb.velocity = _dashingDir * 14f;
            return;
        }

        if (isGrounded())
        {
            _canDash = true;
        }
    }
    
    
    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer)){
            return true;
        }
        else 
        {
            return false;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }
}
