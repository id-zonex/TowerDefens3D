using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class Money : MonoBehaviour
{
    public static int moneyCount { get; protected set; } = 500;
    private static TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();

        _text.text = moneyCount.ToString();
    }

    public static void AddMoney(int money)
    {
        moneyCount += money;
        DisplayMoney();
    }

    public static bool SubtractMoney(int money)
    {
        if (moneyCount - money >= 0)
        {
            moneyCount -= money;
            DisplayMoney();

            return true;
        }

        return false;   
    }

    private static void DisplayMoney()
    {
        _text.text = moneyCount.ToString();
    }

}
