using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;


public class Taget : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] Transform _taget;
   public float Speed = 2f;
   
   void Update()
   {
    Vector3 newPos = new Vector3 (_taget.position.x, -0f, -3f);
    transform.position = Vector3.Slerp(transform.position, newPos, Speed*Time.deltaTime);
   }
}
