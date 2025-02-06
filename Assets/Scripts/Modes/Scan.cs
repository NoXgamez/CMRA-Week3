using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Scan : MonoBehaviour
{
    [SerializeField]
    ARPlaneManager planeManager;

    private void OnEnable()
    {
        UIManager.Instance.ShowScreen("Scan");
        planeManager.enabled = true;
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        if (planeManager)
        {
            if (planeManager.trackables.count > 0)
            {
                InteractionManager.Instance.EnableMode("Main");
            }
        }
    }
}
