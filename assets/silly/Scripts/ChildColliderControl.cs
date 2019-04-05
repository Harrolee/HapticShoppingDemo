using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderControl : MonoBehaviour {

    BluetoothControl bluetoothControl;
    bool isin = false;

    // Use this for initialization
    void Start () {
        bluetoothControl = GameObject.Find("BluetoothControl").GetComponent<BluetoothControl>();
        this.gameObject.layer = LayerMask.NameToLayer("Col");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.layer == LayerMask.NameToLayer("Arm") && !isin)
        {
            isin = true;
            Debug.Log("this.transform.name :: " + isin);
            JsonData data = new JsonData();
            data.Name = this.transform.name;
            data.Pick = true;
            bluetoothControl.SendData(data);
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.layer == LayerMask.NameToLayer("Arm") && isin)
        {
            isin = false;
            Debug.Log(this.transform.name);
            JsonData data = new JsonData();
            data.Name = this.transform.name;
            data.Pick = false;
            bluetoothControl.SendData(data);
        }

    }

}
