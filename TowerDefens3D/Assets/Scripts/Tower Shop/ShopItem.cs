using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    [SerializeField] private Tower _towerPrefab;
    [SerializeField] private GameObject _templateTower;

    private Button button;

    private void Awake() 
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Builder.BuildTower(_towerPrefab, _templateTower);
    }
}
