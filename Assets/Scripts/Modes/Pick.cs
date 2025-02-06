using UnityEngine;
using UnityEngine.UI;

public class Pick : MonoBehaviour
{
    [SerializeField]
    private Transform lstItems; // Content of ScrollView

    [SerializeField]
    private Button btnPlace;

    [SerializeField]
    private GameObject ImageButtonPrefab;

    private void OnEnable()
    {
        UIManager.Instance.ShowScreen("Pick");

        AddItemsToList();
    }

    private void OnDisable()
    {
        
    }

    void AddItemsToList()
    {
        foreach(Transform child in lstItems.transform)
        {
            Destroy(child.gameObject);
        }

        //foreach (Item item in DataManager.Instance.ItemCollection.Items)
        //{
        //    ImageButton instance = Instantiate(ImageButtonPrefab, lstItems);
        //    instance.SetData(item);

        //    instance.Button.onClick.AddListener(() =>
        //    {
        //        //instance.Prefab;
        //        btnPlace.gameObject.SetActive(true);
        //    });
        //}
    }

    public void CancelPick()
    {
        InteractionManager.Instance.EnableMode("Main");
    }

    public void SwitchToPlaceMode()
    {
        if (DataManager.Instance.SelectedItemPrefab != null)
            InteractionManager.Instance.EnableMode("Place");
    }
}
