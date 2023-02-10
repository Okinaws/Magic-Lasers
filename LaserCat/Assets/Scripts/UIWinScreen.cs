using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIWinScreen : MonoBehaviour
{
    [SerializeField]
    private Image win;

    private void Start()
    {
        win.transform.DOScale(2f, 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
