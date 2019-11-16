using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Astroid;
    public Vector3 randomPos;
    public float roundAraligi;
    public float olsuturmaBekleme;
    public float donguBekleme;


    public Text oyunBittiText;
    public Text yenidenBaslaText;

    public Text ScoreText;
    int score = 0;
    bool gameOver = false;
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

            if (gameOver)
            {
                break;
            }

            //3 saniye aralıklarla
            yield return new WaitForSeconds(roundAraligi);


        }


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            gameOver = false;
            oyunBittiText.gameObject.SetActive(false);
            yenidenBaslaText.gameObject.SetActive(false);

            SceneManager.LoadScene("Level1");
        }
    }

    public void scoreArttir(int gelenScore)
    {
        score += gelenScore;
        ScoreText.text = "Score: " + score;
        Debug.Log(score);
    }

    public void oyunBitti()
    {
        oyunBittiText.gameObject.SetActive(true);
        yenidenBaslaText.gameObject.SetActive(true);
        gameOver = true;

    }
}
