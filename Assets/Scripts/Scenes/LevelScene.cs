using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScene : MonoBehaviour
{
    public int levelId = 0;
    public PlayerController _player;

    private int _mothCount = 0;
    private int _deadMoths = 0;
    private int _savedMoths = 0;
    
    static public bool gameStopped = false;

    public void AddMoth(int count = 1)
    {
        _mothCount += count;
    }

    public void MothDied()
    {
        _deadMoths += 1;
    }

    public void MothSaved()
    {
        _savedMoths += 1;
    }

    public void Start()
    {
        gameStopped = false;
        Time.timeScale = 1f;
        PlayerResults.currentLvl = levelId;
    }

    public void Restart()
    {
        SceneManager.LoadScene($"Scenes/Levels/Level{levelId}", LoadSceneMode.Single);
    }

    public void Home()
    {
        SceneManager.LoadScene("Scenes/SplashScreen", LoadSceneMode.Single);
    }

    public void GameOver(float p)
    {
        gameStopped = true;
        if (p >= 50f) PlayerResults.levels[levelId] = 1;
        if (p >= 75f) PlayerResults.levels[levelId] = 2;
        if (p > 99f) PlayerResults.levels[levelId] = 3;
        SceneManager.LoadScene("Scenes/GameoverScene", LoadSceneMode.Additive);
        _mothCount = 0;
    }

    public void PlayerDeath()
    {
        GameOver(0);
    }

    public void Update()
    {
        if (_deadMoths + _savedMoths == _mothCount && _mothCount != 0 && !gameStopped)
        {
            GameOver(_savedMoths * 100f / _mothCount);
        }
    }
}
