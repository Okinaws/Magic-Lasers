using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Image soundBtn;
    [SerializeField]
    private Image vibroBtn;

    private void Start()
    {
        if (!AudioManager.IsAudioEnabled)
        {
            ChangeSoundBtnColor();
        }
    }

    public void ChangeSoundBtnColor()
    {
        if (soundBtn.color == Color.red) soundBtn.color = new Color(0.1137255f, 0.1058824f, 0.3098039f);
        else soundBtn.color = Color.red;
    }

    public void ChangeSoundEnabled ()
    {
        AudioManager.ChangeAudioEnabled();
    }

    public void ChangeVibroBtnColor()
    {
        if (vibroBtn.color == Color.red) vibroBtn.color = new Color(0.1137255f, 0.1058824f, 0.3098039f);
        else vibroBtn.color = Color.red;
    }
}
