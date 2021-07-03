using UnityEngine;

public class StartShopButtonHandler : MonoBehaviour
{
    [SerializeField] GameObject _layout;

    public void Click()
    {
        _layout.gameObject.SetActive(!_layout.gameObject.active);
    }
}
