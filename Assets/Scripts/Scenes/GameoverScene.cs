using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverScene : MonoBehaviour
{
    public Image star1;
    public Image star2;
    public Image star3;

    public GameObject nextButton;
    public Image title;

    public Sprite fullStar;
    public Sprite emptyStar;

    public Sprite cleared;
    public Sprite failed;

    void Start()
    {
        if (PlayerResults.currentLvl == PlayerResults.levels.Length - 1) nextButton.SetActive(false);
        title.sprite = (PlayerResults.levels[PlayerResults.currentLvl] >= 1) ? cleared : failed;
        if (PlayerResults.levels[PlayerResults.currentLvl] >= 1) star1.sprite = fullStar;
        if (PlayerResults.levels[PlayerResults.currentLvl] >= 2) star2.sprite = fullStar;
        if (PlayerResults.levels[PlayerResults.currentLvl] >= 3) star3.sprite = fullStar;
    }

    public void Restart()
    {
        SceneManager.LoadScene($"Scenes/Levels/Level{PlayerResults.currentLvl}", LoadSceneMode.Single);
    }

    public void Home()
    {
        SceneManager.LoadScene($"Scenes/SplashScreen", LoadSceneMode.Single);
    }

    public void Next()
    {
        SceneManager.LoadScene($"Scenes/Levels/Level{PlayerResults.currentLvl + 1}", LoadSceneMode.Single);
    }
}
