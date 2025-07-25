using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _buyMenuPrefab;
    [SerializeField] private Canvas _canvas;
    private bool _showMenu = false;
    private GameObject _buyMenu;

    /// <summary>
    /// Open the shopping menu
    /// </summary>
    /// <param name="pos"></param>
    public void CallBuyMenu(Vector3 pos, bool isOccupied)
    {
        _buyMenu = Instantiate(_buyMenuPrefab);
        _buyMenu.transform.SetParent(_canvas.transform, false);
        _buyMenu.transform.SetPositionAndRotation(pos, Quaternion.identity);
        _buyMenu.GetComponent<BuyMenu>().Init(isOccupied);
        ChangeMenuStatus();
    }

    /// <summary>
    /// Close the shopping menu
    /// </summary>
    public void CloseBuyMenu()
    {
        Destroy(_buyMenu);
        ChangeMenuStatus();
    }

    /// <summary>
    /// Flip the status
    /// </summary>
    private void ChangeMenuStatus()
    {
        _showMenu = !_showMenu;
    }

    /// <summary>
    /// Returns the menu status
    /// </summary>
    /// <returns></returns>
    public bool GetMenuStatus() => _showMenu;
}
