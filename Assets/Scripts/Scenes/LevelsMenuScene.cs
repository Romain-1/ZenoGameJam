using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelsMenuScene : MonoBehaviour
{
    [Serializable]
    public struct Level
    {
        public GameObject level;
        public Image star1;
        public Image star2;
        public Image star3;
    }

    public Sprite[] fullStars;
    public Sprite[] emptyStars;
    public Level[] levels;

    public void OnChooseLevel(int id)
    {
        SceneManager.LoadScene($"Scenes/Levels/Level{id}", LoadSceneMode.Single);
    }

    public void Start()
    {
        for (int i = 0; i < levels.Length; ++i)
        {
            levels[i].level.SetActive(i + 1 < PlayerResults.levels.Length);
            if (i + 1 < PlayerResults.levels.Length)
            {
                levels[i].star1.sprite = (PlayerResults.levels[i + 1] >= 1) ? fullStars[Random.Range(0, fullStars.Length)] : emptyStars[Random.Range(0, emptyStars.Length)];
                levels[i].star2.sprite = (PlayerResults.levels[i + 1] >= 2) ? fullStars[Random.Range(0, fullStars.Length)] : emptyStars[Random.Range(0, emptyStars.Length)];
                levels[i].star3.sprite = (PlayerResults.levels[i + 1] >= 3) ? fullStars[Random.Range(0, fullStars.Length)] : emptyStars[Random.Range(0, emptyStars.Length)];
            }
        }
    }
}
