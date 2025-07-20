using UnityEngine;

using SL = ServiceLocator;

public class GameManager : MonoBehaviour
{
    [SerializeField] Texture2D _cursorGreenTexture;
    [SerializeField] Texture2D _cursorRedTexture;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.CompareTag("TowerPoint") && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (!hit.collider.GetComponent<TowerPoint>().GetTowerPointStatus())
                {
                    Cursor.SetCursor(_cursorGreenTexture, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(_cursorRedTexture, Vector2.zero, CursorMode.Auto);
                }

                if (Input.GetMouseButtonDown(0) && !SL.Instance.UIManager.GetMenuStatus())
                {
                    SL.Instance.UIManager.CallBuyMenu(Input.mousePosition, hit.collider.GetComponent<TowerPoint>().GetTowerPointStatus());
                }
                else if (Input.GetMouseButtonDown(0) && SL.Instance.UIManager.GetMenuStatus())
                {
                    SL.Instance.UIManager.CloseBuyMenu();
                }
            }
            else if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                // ignore CloseMenuFunc
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

                if (Input.GetMouseButtonDown(0))
                {
                    SL.Instance.UIManager.CloseBuyMenu();
                }
            }
        }
    }
}
