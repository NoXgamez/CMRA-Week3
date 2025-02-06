using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Place : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager raycastManager;

    [SerializeField]
    PlayerInput playerInput;

    private Vector2 pointerPosition;

    private void OnEnable()
    {
        InteractionManager.Instance.EnableMode("Place");
        raycastManager.enabled = true;
        playerInput.enabled = true;
    }

    private void OnDisable()
    {
        raycastManager.enabled = false;
        playerInput.enabled = false;
    }

    public void OnPointerPosition(InputValue inputValue)
    {
        pointerPosition = inputValue.Get<Vector2>();
    }

    public void OnInteract()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(pointerPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Vector3 position = hits[0].pose.position;
            Instantiate(DataManager.Instance.SelectedItemPrefab, position, Quaternion.identity);

            InteractionManager.Instance.EnableMode("Main");
        }
    }
}
