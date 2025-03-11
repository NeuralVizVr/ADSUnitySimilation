using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // Assign cameras in the Inspector
    private int currentCameraIndex = 0;
    public Button switchButton; // Assign the UI button in the Inspector

    void Start()
    {
        if (cameras.Length == 0)
        {
            Debug.LogError("No cameras assigned to CameraSwitcher!");
            return;
        }

        // Enable only the first camera, disable others
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchCamera);
        }
    }

    void Update()
    {
        // Check if "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    public void SwitchCamera()
    {
        // Disable current camera
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Increment index and loop back if necessary
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Enable the next camera
        cameras[currentCameraIndex].gameObject.SetActive(true);
    }
}
