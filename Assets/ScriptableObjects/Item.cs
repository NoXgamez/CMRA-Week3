using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item")]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public GameObject Prefab;
}
