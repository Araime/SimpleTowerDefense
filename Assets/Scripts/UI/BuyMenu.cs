using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    [SerializeField] private GameObject _buyButton;
    [SerializeField] private GameObject _sellButton;
    [SerializeField] private GameObject _upgradeButton;
    [SerializeField] private GameObject _closeButton;

    public void Init(bool canBuy)
    {
        Debug.Log("Done");

        //_buyButton.GetComponent<ButtonScript>().OnOffButton(canBuy);
        //_sellButton.GetComponent<ButtonScript>().OnOffButton(!canBuy);
        //_upgradeButton.GetComponent<ButtonScript>().OnOffButton(!canBuy);
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
