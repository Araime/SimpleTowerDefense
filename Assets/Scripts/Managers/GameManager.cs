using UnityEngine;

using SL = ServiceLocator;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorGreenTexture;
    [SerializeField] private Texture2D _cursorRedTexture;

    private SL _serviceLocator;

    private void Start()
    {
        _serviceLocator = ServiceLocator.Instance;
    }

    private void Update()
    {
        bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
        
        // Сброс курсора если над UI или если не попали в TowerPoint
        if (isOverUI || !Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
        {
            ResetCursor();
            
            if (Input.GetMouseButtonDown(0) && !isOverUI)
                _serviceLocator.UIManager.CloseBuyMenu();
            
            return;
        }

        // Обработка TowerPoint
        if (hit.collider.CompareTag("TowerPoint"))
        {
            bool isOccupied = false;
            
            if (hit.collider.TryGetComponent(out TowerPoint towerPoint))
            {
                isOccupied = towerPoint.IsOccupied;
            }
            
            Cursor.SetCursor(isOccupied ? _cursorRedTexture : _cursorGreenTexture, Vector2.zero, CursorMode.Auto);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (_serviceLocator.UIManager.IsMenuOpen)
                    _serviceLocator.UIManager.CloseBuyMenu();
                else
                    _serviceLocator.UIManager.OpenBuyMenu(Input.mousePosition, isOccupied);
            }
        }
        else
        {
            ResetCursor();
            if (Input.GetMouseButtonDown(0))
                _serviceLocator.UIManager.CloseBuyMenu();
        }
    }

    private void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
