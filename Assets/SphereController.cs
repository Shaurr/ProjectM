using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    private UIManager uimanager;
    [SerializeField]
    private AudioSource audio;
    private GameObject cam;
    private GameObject board;
    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("PlayingBoard");
        cam = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Goal")) {
            uimanager.FinishGame();
        }
        else if(other.CompareTag("Teleporter")){
            audio.Play();
            
            
            board.GetComponent<Rigidbody>().freezeRotation = true;
            board.transform.rotation = new Quaternion(0, 0, 0, 0);
            
            GameObject locationP =    other.GetComponent<Teleport>().GetLocationP();
            Vector3 locationC = other.GetComponent<Teleport>().GetLocationC();
           
            
            Debug.Log(locationP.transform.position);
            cam.transform.position = locationC;
            transform.position = locationP.transform.position;
            
            board.GetComponent<Rigidbody>().freezeRotation = false;
            
        }
    }
  
}
