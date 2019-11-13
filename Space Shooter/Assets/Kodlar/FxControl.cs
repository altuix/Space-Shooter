using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControl : MonoBehaviour
{
    Rigidbody Fizik;
    public float hiz = 5f;
    void Start()
    {
        Fizik = GetComponent<Rigidbody>();

        //kurşun sabit hızla ileri gidecek
        Fizik.velocity = transform.forward * hiz;
        
    }

  
}
