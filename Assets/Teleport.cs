using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject locationP;
    [SerializeField]
    private Vector3 locationC;

    public GameObject GetLocationP(){
        return locationP;
    }
    public Vector3 GetLocationC() {
        return locationC;
    }


}
