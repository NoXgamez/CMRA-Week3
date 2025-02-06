using UnityEngine;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    public Button Button;

    [SerializeField]
    private Image ImgIcon;

    [HideInInspector]
    public GameObject Prefab;

    public void SetData(Item item)
    {
        ImgIcon.sprite = item.Icon;
        Prefab = item.Prefab;
    }
}
