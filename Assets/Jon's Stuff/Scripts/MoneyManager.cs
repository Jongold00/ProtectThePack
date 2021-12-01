using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int currentMoney;


    #region UI

    [SerializeField]
    private TextMeshProUGUI moneyText;

    #endregion UI


    #region Singleton

    private static MoneyManager _instance;

    public static MoneyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MoneyManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #endregion Singleton

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyText();
    }

    public void AddMoney(int delta)
    {
        currentMoney += delta;
        UpdateMoneyText();
    }

    public void SubtractMoney(int delta)
    {
        currentMoney -= delta;
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "$" + currentMoney.ToString();
    }
}
