using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotasyon : MonoBehaviour
{

    Rigidbody Fizik;
    public float hiz;

    void Start()
    {
        Fizik = GetComponent<Rigidbody>();
        Fizik.angularVelocity = Random.insideUnitSphere * hiz;
    }

}
