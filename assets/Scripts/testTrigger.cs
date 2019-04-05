using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Test Trigger");
        if(other.gameObject.layer == LayerMask.NameToLayer("Finger"))
        {
            Debug.Log(gameObject.name + "recognized 'Finger'");
        }
    }
}
