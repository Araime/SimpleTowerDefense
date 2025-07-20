using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] protected Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
    }

    public void OnOffButton(bool NewState)
    {
        _button.interactable = NewState;
    }

    public virtual void ButtonClick()
    {

    }
}
