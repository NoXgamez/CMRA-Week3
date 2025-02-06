using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Start : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.ShowScreen("Start");
        Invoke("CheckForARSupport", 3);
    }

    private void OnDisable()
    {
        
    }

    void CheckForARSupport()
    {

        if (ARSession.state == ARSessionState.Unsupported || ARSession.state == ARSessionState.None)
        {
            // No AR
            InteractionManager.Instance.EnableMode("NoAR");
        }
        else if (ARSession.state == ARSessionState.Ready || ARSession.state == ARSessionState.SessionTracking)
        {
            // No AR
            InteractionManager.Instance.EnableMode("Scan");
        }

    }
}
