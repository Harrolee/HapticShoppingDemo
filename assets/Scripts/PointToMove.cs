using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMove : MonoBehaviour
{
    public Transform _IndexPoint;
    public GameObject _LIndexCollider;
    public GameObject _LThumbCollider;

    LayerMask layer = 11;   //Layer 11 is Wall
    

    //find point orientation



        //if fingers collide, fire this script.
    public void FingersCollide()
    {
        RaycastHit hit;
        if (Physics.Raycast(_IndexPoint.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layer))
        {
            print("I hit: " + hit.transform.gameObject);
            Debug.DrawRay(_IndexPoint.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            //move us toward hit
        }
        else
        {
            Debug.DrawRay(_IndexPoint.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            print("I didn't hit it");
        }
        //bring transform.position to point.transform.position
        //raycast from point.
    }

}
