using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    private List<GameObject> screens = new List<GameObject>();
    private float[] scores;
    GameObject[] scoreTexts;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < transform.childCount; i++) {
            screens.Add(transform.GetChild(i).gameObject);
        }
        scores = ScoreManager.instance.GetScores();
        scoreTexts = new GameObject[scores.Length];
        for (int i = 0; i < scores.Length; i++) {
            scoreTexts[i] = screens[1].transform.Find("Score" + i).gameObject;
        }
        ChangeScores();
    }
    private void ChangeScores() {
        for(int i=0; i<scores.Length; i++) {
            scoreTexts[i].GetComponent<Text>().text = "Highscore: " + scores[i].ToString("F2") + "s";
        }
    }

    public void ChangeScreen(int screennr) {
        foreach (GameObject screen in screens) {
            screen.SetActive(false);
        }
        screens[screennr].SetActive(true);
        if (screennr == 1) {
            ChangeScores();
        }
    }

    public void Exit(){
        Application.Quit();
    }

    public void ChangeScene(int scenennr) {
        SceneManager.LoadScene(scenennr,LoadSceneMode.Single);
    }

   
}



