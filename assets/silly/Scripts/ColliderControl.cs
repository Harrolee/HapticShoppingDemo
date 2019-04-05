using System;
using UnityEngine;

public class ColliderControl : MonoBehaviour {

    BluetoothControl bluetoothControl;
    Renderer rend;

    GameObject Child;
    public float colliderSize = 1.1f;
    BoxCollider childCollider;

    void Start()
    {
        bluetoothControl = GameObject.Find("BluetoothControl").GetComponent<BluetoothControl>();
        rend = GetComponent<Renderer>();

        Child = new GameObject();
        Child.transform.parent = this.transform;
        Child.name = this.transform.name;


        childCollider = Child.AddComponent<BoxCollider>();
        childCollider.isTrigger = true;


        Child.transform.localPosition = Vector3.zero;
        childCollider.size = new Vector3(colliderSize, colliderSize, colliderSize) * this.transform.localScale.x;
        Child.AddComponent<ChildColliderControl>();
    }




    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="obj"></param>
    //void OnCollisionEnter(Collision obj)
    //{
    //    if (obj.gameObject.layer == LayerMask.NameToLayer("Arm"))
    //    {
    //        Debug.Log(this.transform.name);
    //        JsonData data = new JsonData();
    //        data.Name = this.transform.name;
    //        Console.WriteLine(data.Name);
    //        bluetoothControl.SendData(data);
    //    }
    //}

    //void OnCollisionExit(Collision obj)
    //{
        
    //}

}
