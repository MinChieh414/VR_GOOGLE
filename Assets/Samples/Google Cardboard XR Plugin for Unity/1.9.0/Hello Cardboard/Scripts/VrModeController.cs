
//     http://www.apache.org/licenses/LICENSE-2.0

using System.Collections;
using Google.XR.Cardboard;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;


public class VrModeController : MonoBehaviour
{
    
    private bool _isScreenTouched
    {
        get
        {
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }

    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }
    public void Start()
    {
        
        // https://docs.unity3d.com/ScriptReference/Screen-brightness.html.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
    }

  
    public void Update()
    {
        if (_isVrModeEnabled)
        {
            if (Api.IsCloseButtonPressed)
            {
                ExitVR();
            }

            if (Api.IsGearButtonPressed)
            {
                Api.ScanDeviceParams();
            }

            Api.UpdateScreenParams();
        }
        else
        {
            if (_isScreenTouched)
            {
                EnterVR();
            }
        }
    }

    private void EnterVR()
    {
        StartCoroutine(StartXR());
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
    }

    private void ExitVR()
    {
        StopXR();
    }

    /// See https://docs.unity3d.com/Packages/com.unity.xr.management@3.2/manual/index.html.
  
    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }

    
    /// See https://docs.unity3d.com/Packages/com.unity.xr.management@3.2/manual/index.html.
    private void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");
    }
}
