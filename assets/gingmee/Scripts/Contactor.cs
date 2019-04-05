using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contactor : MonoBehaviour
{
    public GameObject Blind;
    public GameObject Popup;
    BluetoothControl bluetoothControl;
    Renderer rend;

    Transform Inputs;
    Text goods_name;
    Text goods_price;
    Text goods_contents;
    Text goods_expiration;
    Image goods_image;

    GoodsData goodsData;

    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("started contactor");
        //bluetoothControl = GameObject.Find("BluetoothControl").GetComponent<BluetoothControl>();
        Inputs = Popup.transform.Find("Inputs").transform;
        goods_name = Inputs.Find("goods_name").GetComponent<Text>();
        goods_price = Inputs.Find("goods_price").GetComponent<Text>();
        goods_contents = Inputs.Find("goods_contents").GetComponent<Text>();
        goods_expiration = Inputs.Find("goods_expiration").GetComponent<Text>();
        goods_image = Inputs.Find("goods_image").GetComponent<Image>();
        goodsData = this.transform.parent.GetComponent<GoodsData>();
    }

    private void OnTriggerEnter(Collider other) {
      Debug.Log("Entered Trigger");
        if (other.gameObject.layer == LayerMask.NameToLayer("User") )
        {
        Debug.Log("Finger got in Trigger");

        //this is the part that sends feedback to the glove
        JsonData data = new JsonData();
        data.Name = this.transform.parent.name; 
        data.Pick = true;
        bluetoothControl.SendData(data);

        Blind.SetActive(true);
        Popup.SetActive(true);
        Debug.Log("Blind is active");

        goods_name.text = this.transform.parent.name;
        goods_price.text = goodsData.price.ToString();
        goods_contents.text = goodsData.contents;
        goods_expiration.text = goodsData.expiration;
        goods_image.sprite = goodsData.img;
        }

        ShoppingManager.SelectedObject = transform.parent.parent.gameObject;
    }


    /*
    private void OnTriggerExit(Collider other)
    {
      Debug.Log("Exited Trigger");
        if (other.gameObject.layer == LayerMask.NameToLayer("User"))
        {
          Debug.Log("Finger left Trigger");
            JsonData data = new JsonData();
            data.Name = this.transform.parent.name;
            data.Pick = false;
          //  bluetoothControl.SendData(data);

            //Blind.SetActive(false);
            //Popup.SetActive(false);
        }
    }
    */
}
