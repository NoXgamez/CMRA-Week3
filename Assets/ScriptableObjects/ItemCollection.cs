using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Collection", menuName = "Custom/Item Collection")]
public class ItemCollection : ScriptableObject
{
    public List<Item> Items;
}
