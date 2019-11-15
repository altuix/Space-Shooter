using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Astroid;
    public Vector3 randomPos;
    public float roundAraligi;
    public float olsuturmaBekleme;
    public float donguBekleme;

    public Text ScoreText;
    int score = 0;
    void Start()
    {
        ScoreText.text = "Score: " + 0;
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
             
                //belli x aralığında
                float rangeResultX = Random.Range(-randomPos.x, randomPos.x);
            
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

    public void scoreArttir(int gelenScore)
    {
        score += gelenScore;
        ScoreText.text = "Score: " + score;
        Debug.Log(score);
    }
}
