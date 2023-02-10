using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private GameObject playButton;

    private bool isWinScreenOpen = false ;

    private void Start()
    {
        settingsMenu.SetActive(false);
        winScreen.SetActive(false);
        isWinScreenOpen = false;
        GameManager.OnEnemyKilled.AddListener(CheckWin);
    }

    private void CheckWin(int enemiesKilled)
    {
        GameManager.Instance.enemiesOnLevel -= enemiesKilled;
        if (GameManager.Instance.enemiesOnLevel <= 0)
        {
            AudioPlayer.Instance.PlayWinSound();
            OpenWinScreen();
        }
    }


    public void OpenSettingsMenu()
    {
        settingsMenu.SetActive(true);
        if (isWinScreenOpen) winScreen.SetActive(false);
        if (playButton != null)
        {
            playButton.SetActive(false);
        }
    }

    public void CloseSettingsMenu()
    {
        settingsMenu.SetActive(false);
        if (isWinScreenOpen) winScreen.SetActive(true);
        if (playButton != null)
        {
            playButton.SetActive(true);
        }
    }

    public void OpenWinScreen()
    {
        winScreen.SetActive(true);
        isWinScreenOpen = true;
    }

    public void CloseWinScreen()
    {
        winScreen.SetActive(false);
        isWinScreenOpen = false;
    }


    public void OpenNextLevel(string levelName)
    {
        GameManager.Instance.ChangeScene(levelName);
    }
}
