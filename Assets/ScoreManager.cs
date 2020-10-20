using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private float starttime = 0;
    private XmlDocument doc = new XmlDocument();
    private XmlNodeList levels;
    private float[] scores;
    private string path;
    
    private void Awake() {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        path = Application.dataPath + "\\scores.xml";
        DontDestroyOnLoad(this.gameObject);

        doc.Load(path);
        levels = doc.GetElementsByTagName("Level");
        scores = new float[levels.Count];
        for (int i = 0; i < levels.Count; i++) {
            scores[i] = float.Parse(levels[i].InnerText);
        }
    }
       
  

    public float[] GetScores() {

        return scores;

    }

    private void WriteScores() {
        for (int i = 0; i < levels.Count; i++) {
            levels[i].InnerText = scores[i].ToString("F2");
        }
        doc.Save(path);
    }
    public void StartLevel() {
        starttime = Time.time;
    }
    public float[] EndLevel(int levelnr) {
        float timeDifference = Time.time - starttime;
        float[] values = new float[2];
        values[0] = timeDifference;
        if (timeDifference < scores[levelnr - 1] || scores[levelnr - 1] == 0) {
            values[1] = -1;
            scores[levelnr-1] = timeDifference;
            WriteScores();
        }
        else {
            values[1] = scores[levelnr-1];
           
        }
        return values;
    }
}
