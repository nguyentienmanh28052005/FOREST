using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashTime = 0.25f;

    private SpriteRenderer _spriteRenderers;
    private Material _materials;

    private Coroutine _damageFlashCoroutine;
    private void Awake()
    {
        _spriteRenderers = GetComponent<SpriteRenderer>();
        Init();
    }

    private void Init()
    {
        _materials = _spriteRenderers.material;
    }

    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }
    
    private IEnumerator DamageFlasher()
    {
        SetFlashColor();
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < _flashTime)
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1f, 0f, (elapsedTime / _flashTime));
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }
    }

    private void SetFlashColor()
    {
        _materials.SetColor("_FlashColor", _flashColor);
    }

    private void SetFlashAmount(float amount)
    {
        _materials.SetFloat("_FlashAmount", amount);
    }
}
