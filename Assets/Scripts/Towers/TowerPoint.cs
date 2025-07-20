using UnityEngine;

public class TowerPoint : MonoBehaviour
{
    [SerializeField] bool _isOccupied = false;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void OnMouseOver()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (!_isOccupied)
            {
                _renderer.material.color = Color.green;
            }
            else
            {
                _renderer.material.color = Color.yellow;
            }
        }
        else
        {
            _renderer.material.color = Color.white;
        }
    }

    void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }

    /// <summary>
    /// Returns the state of the tower point
    /// </summary>
    /// <returns></returns>
    public bool GetStatus() => _isOccupied;
}
