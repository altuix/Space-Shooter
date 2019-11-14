using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Astroid;
    public Vector3 randomPos;
    public float roundAraligi;
    public float olsuturmaBekleme;
    public float donguBekleme;

    void Start()
    {
        StartCoroutine(olustur());
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(olsuturmaBekleme);

        while (true)
        {
            //10 item gelecek
            for (int i = 0; i < 10; i++)
            {
                Debug.Log(-randomPos.x);
                Debug.Log(randomPos.x);
                //belli x aralığında
                float rangeResultX = Random.Range(-randomPos.x, randomPos.x);
                Debug.Log(rangeResultX);
                Vector3 vec = new Vector3(
                   rangeResultX,
                    0,
                    randomPos.z
                    );

                //obje,oluşacağı yer, gidiş
                Instantiate(Astroid, vec, Quaternion.identity);

                //1 saniye aralıklarla
                yield return new WaitForSeconds(donguBekleme);
            }
            //3 saniye aralıklarla

            yield return new WaitForSeconds(roundAraligi);

        }


    }
}
