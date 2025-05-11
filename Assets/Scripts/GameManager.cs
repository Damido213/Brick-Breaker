using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int Lives = 3;
    public GameObject ball;
    public GameObject grid;
    public List<Image> Hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    public int Score = 0;
    public string Reason;
    public TMP_Text ScoreText;
    public TMP_Text ReasonText;

    private void Update()
    {
        if (grid != null)
        {
            if (grid.transform.childCount == 0)
            {
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.SetString("Reason", "You win!");
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void Restart()
    {
        if (Lives > 0)
        {
            Lives--;
            UpdateHeartsUI();
            ball.transform.position = new Vector3(0, -2.8f, 0);
            int dir = Mathf.RoundToInt(Random.Range(1, 3));
            switch (dir)
            {
                case 1:
                    ball.GetComponent<Ball>().direction = new Vector3(-1, 1, 0);
                    break;
                case 2:
                    ball.GetComponent<Ball>().direction = new Vector3(1, 1, 0);
                    break;
            }
        }

        if (Lives <= 0)
        {
            PlayerPrefs.SetInt("Score", Score);
            PlayerPrefs.SetString("Reason", "You lost all your lifes!");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Start()
    {
        if (ScoreText == null) 
        { }
        else
        {
            Score = PlayerPrefs.GetInt("Score");
            Reason = PlayerPrefs.GetString("Reason");
            ReasonText.text = Reason;
            ScoreText.text = "Score: " + Score.ToString();
            PlayerPrefs.DeleteAll();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Restart();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < Hearts.Count; i++)
        {
            Hearts[i].sprite = i < Lives ? HeartFull : HeartEmpty;
        }
    }
}
