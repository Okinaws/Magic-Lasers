using UnityEngine;
using UnityEngine.Events;

public class CashManager : Singleton<CashManager>
{
    private int cash = 0;

    /// <summary>
    /// arg1 - new total cash<br>
    /// arg2 - delta change</br>
    /// </summary>
    public static UnityEvent<int, int> OnCashUpdated = new UnityEvent<int, int>();
    public int Cash { get { return cash; } }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Cash"))
        {
            cash = PlayerPrefs.GetInt("Cash");
        }
    }

    private void Start()
    {
        OnCashUpdated?.Invoke(cash, 0);
    }

    /// <summary>
    /// add user cash
    /// </summary>
    public void AddCash(int amount)
    {
        cash += amount;
        PlayerPrefs.SetInt("Cash", cash);
        OnCashUpdated?.Invoke(cash, amount);
        AudioPlayer.Instance.PlayCoinSound();
    }

    /// <summary>
    /// spend user's cash
    /// </summary>
    public void SpendCash(int amount)
    {
        cash -= amount;
        PlayerPrefs.SetInt("Cash", cash);
        OnCashUpdated?.Invoke(cash, -amount);
    }
}
