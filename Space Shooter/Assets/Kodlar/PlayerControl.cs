using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody Fizik;
    float Horizontal = 0;
    float Vertical = 0;

    Vector3 vec3;
    public float hiz = 1, egim = 1.55f;

    public float maxX, minX, maxZ, minZ;

    float atisZamani = 0;
    public float atisAraligi;

    public GameObject kursun;
    public Transform kursunPozisyonu;

    void Start()
    {
        Fizik = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        vec3 = new Vector3(Horizontal, 0, Vertical);

        //hareket için
        Fizik.velocity = vec3 * hiz;

        //ekrandan taşmasın diye sınırları belirledik
        Fizik.position = new Vector3(
            Mathf.Clamp(Fizik.position.x, minX, maxX),
            0,
            Mathf.Clamp(Fizik.position.z, minZ, maxZ)
            );

        //kanatları eğmesi için
        Fizik.rotation = Quaternion.Euler(0, 0, Fizik.velocity.x * -egim);
    }


    //her frame de çalışacak
    void Update()
    {
        // mouse click && atış aralığı uygunsa  
        if (Input.GetButton("Fire1") && Time.time > atisZamani)
        {
            //atış zamanı güncelledik
            atisZamani = Time.time + atisAraligi;

            //kurşunun oluşması,çıkış yeri,ve gideciği yön için ayarlamalar
            Instantiate(kursun, kursunPozisyonu.position, Quaternion.identity);
            Debug.Log("tiklandi");
        }
    }
}
