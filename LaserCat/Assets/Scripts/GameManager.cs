using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> 
{

    public static UnityEvent<int> OnEnemyKilled = new UnityEvent<int>();
    public int enemiesOnLevel;

    public void ChangeScene(string name)
    {
        if (name == "Level_1")
        {
            enemiesOnLevel = 1;
        }
        else if (name == "Level_2")
        {
            enemiesOnLevel = 2;
        }
        SceneManager.LoadScene(name);
    }
}
