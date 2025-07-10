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
        if (!_isOccupied)
        {
            _renderer.material.color = Color.green;
        }
        else
        {
            _renderer.material.color = Color.yellow;
        }
        
    }

    void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }
}
