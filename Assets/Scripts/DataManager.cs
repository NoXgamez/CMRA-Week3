using UnityEngine;

public class DataManager : MonoBehaviour
{
    public ItemCollection ItemCollection;
    public GameObject SelectedItemPrefab;

    public static DataManager Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;
    }
}
