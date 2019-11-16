using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{

    public GameObject patlama;

    public GameObject playerPatlama;

    GameObject OyunKontrol;
    OyunKontrol kontrol;

    private void Start()
    {
        //oyun kontrol objesini taga göre aldık (içindeki fonksiyonlara ulaşmak için)
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "sinir")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);

            //burada oyun kontrol içerisinde olan score arttır fonksiyonunu çağırdık
            kontrol.scoreArttir(1);
        }


        if (other.tag == "Player")
        {

            Instantiate(playerPatlama, other.transform.position, other.transform.rotation);
            kontrol.oyunBitti();
        }
    }
}
