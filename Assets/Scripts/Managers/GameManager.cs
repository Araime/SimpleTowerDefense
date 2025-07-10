using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Texture2D _cursorGreenTexture;
    [SerializeField] Texture2D _cursorRedTexture;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.CompareTag("TowerPoint"))
            {
                if (!hit.collider.GetComponent<TowerPoint>().GetStatus())
                {
                    Cursor.SetCursor(_cursorGreenTexture, Vector2.zero, CursorMode.Auto);
                }
                else
                {
                    Cursor.SetCursor(_cursorRedTexture, Vector2.zero, CursorMode.Auto);
                }
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
