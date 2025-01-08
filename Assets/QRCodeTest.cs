using UnityEngine;
using ZXing;

public class QRCodeTest : MonoBehaviour
{
    void Start()
    {
        IBarcodeReader barcodeReader = new BarcodeReader();
        Debug.Log("ZXing.Net library is set up and working!");
    }
}
