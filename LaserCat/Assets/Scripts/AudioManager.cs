using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    private static bool isAudioEnabled = true;
    public static bool IsAudioEnabled { get { return isAudioEnabled; } }

    public static void ChangeAudioEnabled()
    {
        if (isAudioEnabled)
        {
            isAudioEnabled = false;
            AudioListener.volume = 0;
        }
        else
        {
            isAudioEnabled = true;
            AudioListener.volume = 1;
        }
    }
}
