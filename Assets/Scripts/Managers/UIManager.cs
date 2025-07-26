using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _buyMenuPrefab;
    [SerializeField] private Canvas _canvas;
    
    private GameObject _activeMenu;
    public bool IsMenuOpen { get; private set; }

    /// <summary>Opens buy menu at specified screen position</summary>
    public void OpenBuyMenu(Vector3 position, bool isOccupied)
    {
        if (_activeMenu != null) return;
        
        _activeMenu = Instantiate(_buyMenuPrefab, position, Quaternion.identity, _canvas.transform);
        _activeMenu.GetComponent<BuyMenu>().Init(isOccupied);
        IsMenuOpen = true;
    }

    /// <summary>Closes currently open buy menu</summary>
    public void CloseBuyMenu()
    {
        if (_activeMenu == null) return;
        
        Destroy(_activeMenu);
        IsMenuOpen = false;
    }
}
