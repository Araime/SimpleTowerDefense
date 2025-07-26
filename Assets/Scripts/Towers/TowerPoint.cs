using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPoint : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private bool _isOccupied;
    public bool IsOccupied => _isOccupied;
    
    [Header("Settings")]
    [SerializeField] private Color _freeColor = Color.green;
    [SerializeField] private Color _occupiedColor = Color.yellow;

    private readonly Color _defaultColor = Color.white;
    
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        _renderer.material.color = _isOccupied ? _occupiedColor : _freeColor;
    }

    void OnMouseExit() => _renderer.material.color = _defaultColor;
}
