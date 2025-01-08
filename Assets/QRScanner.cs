using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXing;
using ZXing.Common;

public class QRScanner : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    private IBarcodeReader barcodeReader;

    void Start()
    {
        // Initialize the webcam and barcode reader
        webCamTexture = new WebCamTexture();
        barcodeReader = new BarcodeReader
        {
            AutoRotate = true,
            Options = new DecodingOptions
            {
                TryHarder = true,
                PossibleFormats = new[] { BarcodeFormat.QR_CODE }
            }
        };

        // Start the webcam
        webCamTexture.Play();
        GetComponent<RawImage>().texture = webCamTexture; // Assign webcam feed to Raw Image
    }

    void Update()
    {
        // Decode the camera feed for QR codes
        if (webCamTexture.isPlaying && webCamTexture.didUpdateThisFrame)
        {
            try
            {
                var result = barcodeReader.Decode(webCamTexture.GetPixels32(), webCamTexture.width, webCamTexture.height);
                if (result != null)
                {
                    Debug.Log($"QR Code Detected: {result.Text}");
                    HandleQRCode(result.Text);
                }
            }
            catch
            {
                Debug.LogWarning("QR code decoding failed.");
            }
        }
    }

    private void HandleQRCode(string qrCodeText)
    {
        // Stop the camera to prevent duplicate detections
        webCamTexture.Stop();

        // Check QR code content and load the corresponding scene
        if (qrCodeText == "CollectKio")
        {
            Debug.Log("QR Code matched: CollectKio. Loading CollectKio_Scene...");
            SceneManager.LoadScene("CollectKio_Scene");
        }
        else if (qrCodeText == "CollectOopsie")
        {
            Debug.Log("QR Code matched: CollectOopsie. Loading CollectOopsie_Scene...");
            SceneManager.LoadScene("CollectOopsie_Scene");
        }
        else
        {
            Debug.LogWarning($"Unknown QR code detected: {qrCodeText}");
        }
    }

    void OnDestroy()
    {
        // Cleanup the webcam texture
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}
