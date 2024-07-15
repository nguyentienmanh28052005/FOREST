using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float _currentHealth;
    public float _maxHealth;
    [SerializeField] private GameObject _healthBar;
    private HealthBar _frameBar;
    private DamageFlash _damageFlash;

    private void Start()
    {
        _frameBar = _healthBar.GetComponent<HealthBar>();
        _damageFlash = GetComponent<DamageFlash>();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _currentHealth -= 20;
            _frameBar.UpdateBar(_currentHealth, _maxHealth);
            _damageFlash.CallDamageFlash();
        }
    }
}
