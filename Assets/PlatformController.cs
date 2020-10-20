using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody rb;
    private bool inputLock = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ScoreManager.instance.StartLevel();
    }

    public void ChangeInputLock(bool state) {
        inputLock = state;
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("w") || Input.GetKey("up") )&& !inputLock) {
            //transform.Rotate(1, 0, 0);
            rb.AddRelativeTorque(20000,0,0);
            Debug.Log("Up");
        }
        if ((Input.GetKey("s") || Input.GetKey("down")) && !inputLock) {
            // transform.Rotate(-1, 0, 0);
            rb.AddRelativeTorque(-20000, 0, 0);
            Debug.Log("Down");
        }
        if ((Input.GetKey("a") || Input.GetKey("left")) && !inputLock) {
            rb.AddRelativeTorque(0, 0, 20000);
            // transform.Rotate(0, 0, 1);
            Debug.Log("Left");
        }
        if ((Input.GetKey("d") || Input.GetKey("right")) && !inputLock) {
            rb.AddRelativeTorque(0, 0, -20000);

            // transform.Rotate(0, 0, -1);
            Debug.Log("Right");
        }
    }
}
