using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{

    public GameObject Blind;
    public GameObject Popup;
    public GameObject _Cart;    //make a grid for objects to be set in
    public static GameObject SelectedObject;
    public GameObject _Dairy;
    public GameObject _Meat;
    GameObject[] CartGrid = new GameObject[8];
    BluetoothControl bluetoothControl;

    int index;
    public void AddSelectedObjectToCart()
    {
        CartGrid[index] = Instantiate(SelectedObject, Vector3.zero, Quaternion.identity);
        CartGrid[index].transform.position = _Cart.transform.GetChild(index).position;
       
        //Add SelectedObject to the Cart Grid List.
        index++;
        Debug.Log("touched " + SelectedObject);
    }

    public void CloseItemInfo()
    {
        Debug.Log("Pressed Close");
        Blind.SetActive(false);
        Popup.SetActive(false);

        JsonData data = new JsonData();                 //I want the glove to stop sending signals when "CloseItemInfo()" is called.
        data.Name = SelectedObject.name;
        data.Pick = false;
        bluetoothControl.SendData(data);
    }

    public void ShowDairy()
    {
        _Meat.SetActive(false);
        _Dairy.SetActive(true);
    }

    public void ShowMeat()
    {
        _Dairy.SetActive(false);
        _Meat.SetActive(true);
    }

}
