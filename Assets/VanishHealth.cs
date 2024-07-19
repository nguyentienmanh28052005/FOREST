using System;
using UnityEngine;

public class VanishHealth : MonoBehaviour
{
    private float _currentHealth;
    public float _maxHealth = 6f;
    private DamageFlash _damageEffect;
    private Animator _anim;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _damageEffect = GetComponent<DamageFlash>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Skill")
        {
            _damageEffect.CallDamageFlash();
            _anim.SetTrigger("Hit");
            _currentHealth -= 2f;
        }
    }
}
