using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Main : MonoBehaviour
{

    [SerializeField]
    ARPlaneManager planeManager;

    private void OnEnable()
    {
        UIManager.Instance.ShowScreen("Main");
        TogglePlanes();
    }

    private void OnDisable()
    {
        
    }

    public void TogglePlanes()
    {

        bool toggle = planeManager.planePrefab.activeSelf;
        planeManager.planePrefab.SetActive(!toggle);

        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(!toggle);
        }
    }

    public void SwitchToPickMode()
    {
        InteractionManager.Instance.EnableMode("Pick");
    }
}
