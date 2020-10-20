using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool uiStatus = false;
    [SerializeField]
    private PlatformController pC;
    private bool inputLock = false;


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("escape") && !inputLock ) {
            
            ChangeUiStatus();

        }
    }

    public void ChangeUiStatus() {
        if (!uiStatus) {
            GetComponent<Canvas>().enabled = true;
            uiStatus = true;
            Time.timeScale = 0;
            pC.ChangeInputLock(true);
        }
        else {
            GetComponent<Canvas>().enabled = false;
            uiStatus = false;
            Time.timeScale = 1;
            pC.ChangeInputLock(false);
        }

    }

    public void BackToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void FinishGame() {
        inputLock = true;
        
        GetComponent<Canvas>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        float[] values = ScoreManager.instance.EndLevel(int.Parse(SceneManager.GetActiveScene().name.Substring(5)));
        if (values[1] == -1)
        {
            transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "Your Time: " + values[0].ToString("F2") + "s";

        }
        else {
            transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
            transform.GetChild(1).GetChild(3).GetComponent<Text>().text = "Highscore: " + values[1].ToString("F2") + "s";
            transform.GetChild(1).GetChild(2).GetComponent<Text>().text = "Your Time: " + values[0].ToString("F2") + "s";
        }
    }


}
