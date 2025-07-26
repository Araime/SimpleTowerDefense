using UnityEngine;

using SL = ServiceLocator;

/// <summary>
/// A �service locator� style singleton can be used to provide access to other, non-singleton scripts
/// </summary>
public class ServiceLocator : MonoBehaviour
{
    public static SL Instance { get; private set; }
    public GameManager GameManager { get; private set; }
    public UIManager UIManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameManager = GetComponentInChildren<GameManager>();
        UIManager = GetComponentInChildren<UIManager>();
    }
}
