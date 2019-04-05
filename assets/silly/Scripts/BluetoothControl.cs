using UnityEngine;
using System;

/// <summary>
/// json data
/// </summary>
[Serializable]
public class JsonData
{
    public string Name;
    public bool Pick;
}


public class BluetoothControl : MonoBehaviour
{
    string COMPort = "\\\\.\\COM4";
    

    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR|| UNITY_STANDALONE

        // 현재 연결된 컴포트 확인
        //foreach (string name in System.IO.Ports.SerialPort.GetPortNames())
        //{
        //    Debug.Log(name);
        //}

        string portName = @"\\.\" + COMPort;
        SerialPortControl.GetInstance().OpenPort(portName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
#endif
    }
    
    /// <summary>
    /// 블루투스 데이터 전송
    /// </summary>
    /// <param name="str"></param>
    public void SendData(JsonData data)
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        SerialPortControl.GetInstance().SendData(JsonUtility.ToJson(data));
#endif
    }
}


