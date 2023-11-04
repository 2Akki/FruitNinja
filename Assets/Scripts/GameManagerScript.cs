using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    int score;

    public Text txtScore;
    public Text txtHighScore;



    public AudioClip[] slicesounds;
    private AudioSource audioSource;
    private void Awake()
    {
        int mynum = PlayerPrefs.GetInt("highScore", 0);
        audioSource= GetComponent<AudioSource>();
        txtHighScore.text = mynum.ToString();
    }
    public void IncreaseScore(int hitperscore=2)
    {
        score += hitperscore;
       txtScore.text = score.ToString();


        int mynum = PlayerPrefs.GetInt("highScore",0);

        if (score > mynum)
        {
            
            PlayerPrefs.SetInt("highScore", score);
            txtHighScore.text = score.ToString();
        }
    }

    public void PlaySound()
    {
        AudioClip randomSound = slicesounds[Random.Range(0,slicesounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }
   public void OnBombHit() {
       Time.timeScale= 0;
          Thread.Sleep(300);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
}
 
