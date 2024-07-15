using System;
using TMPro.EditorUtilities;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool doubleJump;
    public float jumpHeight = 0.23f;
    public bool onJump;
    public float gravityScale;
    public float fallGravityScale;
    
    
    private float _speed = 0;
    private Rigidbody2D _rb;
    private Animator _anim;
    private float _horizontalInput;
    private bool isfacingRight = true;
    private string _animIDSpeed;
    
    private DataSkill _skill;
    
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 50f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 0f;
    [SerializeField] private TrailRenderer tr;
    
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private InputManager _input;

    [SerializeField] private GameObject AudioFootStep;
    private FootStepManage _footStep;

    [SerializeField] private ParticleEffect _particle;

    public bool isGrounds;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _skill = GetComponent<DataSkill>();
        _input = GetComponent<InputManager>();
        _footStep = AudioFootStep.GetComponent<FootStepManage>();
    }

    void Start()
    {
        _animIDSpeed = "Speed";
    }

    

    void Update()
    {
        Jump();
        Fall();
        if(isDashing)
        {
            return;
        }
        UpdateSkill();
        Flip();
        if(Input.GetKeyDown(KeyCode.M) && canDash)
        {
            StartCoroutine(Dash());
        }
        isGrounds = isGrounded();
    }
    
    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        Move();
        
    }

    void UpdateSkill()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _skill.bulletFire1();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _skill.bulletUltiFire();
        }
        // if (Input.GetKeyDown(KeyCode.L))
        // {
        //     _skill.skillWater2();
        // }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _skill.skillWaterBall();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            _skill.BaseSkill();
        }
    }

    public bool GetDirection()
    {
        return isfacingRight;
    }
    
    void Move()
    {
        _speed = 4f;
        _anim.SetFloat(_animIDSpeed, 0f);
        _horizontalInput = _input.Horizontal();
        if (_horizontalInput == 0 || !isGrounded())
        {
            _footStep.OffAudio();
        }
        if (_horizontalInput != 0)
        {
           if(isGrounded())  _footStep.OnAudioWalk();
            _speed = 3.5f;
            _anim.SetFloat(_animIDSpeed, _speed);
        }
        if (Input.GetKey(KeyCode.LeftShift) && _horizontalInput != 0)
        {
            if(isGrounded()) _footStep.OnAudioRun();
            _speed = 9f;
            _anim.SetFloat(_animIDSpeed, _speed);
        }
        _rb.velocity = new Vector2(_horizontalInput, _rb.velocity.y);
        transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }

     void Jump()
    {
        if(isGrounded() && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded() || doubleJump)
            {
                if (isGrounded())
                {
                    StartCoroutine(AnimJump());
                    _rb.gravityScale = gravityScale;
                    float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
                    _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    doubleJump = !doubleJump;
                }
                else
                { 
                    _particle.PlayParticle();
                    StartCoroutine(AnimJump());
                    _rb.gravityScale = gravityScale;
                    float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * _rb.gravityScale) * -2) * _rb.mass;
                    _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    doubleJump = !doubleJump;
                }
            }
        }
        if(_rb.velocity.y > 0)
        {
            _rb.gravityScale = gravityScale;
        }
        else
        {
            _rb.gravityScale = fallGravityScale;
        }
        
    }

    private void Fall()
    {
        if(!isGrounded() && !onJump) _anim.SetBool("Fall", true);
        if(isGrounded()) _anim.SetBool("Fall", false);
    }
 
    private IEnumerator AnimJump()
    {
        onJump = true;
        _anim.SetBool("Jump", true);
        yield return new WaitForSeconds(0.5f);
        onJump = false;
        _anim.SetBool("Jump", false);
    }
     
    

    public bool GetStatusJump()
    {
        return doubleJump;
    }
    
    private void Flip()
    {
        if(isfacingRight && _horizontalInput < 0 || !isfacingRight && _horizontalInput > 0){
            if(_skill.GetStatusSkillBase1() == true) _skill.SetSkillBase1False();
            if(_skill.GetStatusSkillBase2() == true) _skill.SetSkillBase2False();
            isfacingRight = !isfacingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = -1 * kich_thuoc.x;
            transform.localScale = kich_thuoc;
        }
    }
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        _rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

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
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
}
