using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuScene : MonoBehaviour
{
    public void OnChooseLevel(int id)
    {
        SceneManager.LoadScene($"Scenes/Levels/Level{id}", LoadSceneMode.Single);
    }
}
