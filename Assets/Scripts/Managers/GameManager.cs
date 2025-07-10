using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Texture _texture;
    [SerializeField] Texture2D _cursorTexture;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(transform.position), out hit))
        {
            if (hit.collider.CompareTag("TowerPoint"))
            {
                Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
