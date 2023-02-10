using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashTextUpdater : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;

    private void Start()
    {
        CashManager.OnCashUpdated.AddListener(UpdateCash);
        textComponent.text = CashManager.Instance.Cash.ToString();
    }

    public void UpdateCash(int totalCash, int deltaChange)
    {
        textComponent.text = totalCash.ToString();
    }
}
