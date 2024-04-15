using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Transform CoinContainer;
    [SerializeField] private TextMeshProUGUI sign;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private float money = 0;
    [SerializeField] private bool isAdd;
    [SerializeField] private GameObject coinAssign;

    // Start is called before the first frame update
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateCoinImage(GameObject coinImage)
    {
        if (isAdd)
        {
            GameObject coin = Instantiate(coinImage, CoinContainer);
            coin.name = coinImage.gameObject.name;
        }
    }
    public void ChangeSign()
    {
        if (sign.text == "+")
        {
            isAdd = false;
            sign.text = "-";
        }
        else
        {
            isAdd = true;
            sign.text = "+";
        }
    }
    private void DisplayMoney()
    {
        moneyText.text = money.ToString();
    }
    public void ChangeMoney(int money)
    {
        if (isAdd)
        {
            this.money += money;
        }
        else
        {
            RemoveCoin(money.ToString(), money);
        }
    }
    private void RemoveCoin(string coinName, int money)
    {
        if (CoinContainer.childCount < 1)
            return;

        foreach (Transform coin in CoinContainer)
        {
            Debug.Log("Child name: " + coin.name + " CoinName: " + coinName);
            if (coin.name == coinName)
            {
                coinAssign = coin.gameObject;
            }
        }

        if (coinAssign != null)
        {
            Destroy(coinAssign);
            this.money -= money;
        }
    }
}
