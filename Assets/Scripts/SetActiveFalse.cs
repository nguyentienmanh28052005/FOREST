using System;
using TMPro.EditorUtilities;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;


public class SetActiveFalse : MonoBehaviour
{
    public float _waitSecond;
    void Update()
    {
        StartCoroutine((OutSkill(_waitSecond, this.GameObject())));
    }
    
    IEnumerator OutSkill(float seconds, GameObject Skill)
    {
        yield return new WaitForSeconds(seconds);
        Skill.SetActive(false);
    }
}
