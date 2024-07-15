using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem PS;
    [SerializeField] private Transform _posi;
    [SerializeField] private GameObject player;
    public bool doubles;
    private PlayerController _player;

    private void Awake()
    {
        _player = this.player.GetComponent<PlayerController>();
    }

    public void PlayParticle()
    {
        Vector2 updatePosi = new Vector2(_posi.position.x, _posi.position.y);
        transform.position = updatePosi;
        PS.Play();
    }
    
}
