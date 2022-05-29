using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScene : MonoBehaviour
{
    public Animator animator;

    public void OnButtonStart()
    {
        animator.Play("SceneTransition");
    }

    public void OnTransitionEnded()
    {
        SceneManager.LoadScene("Scenes/LevelsMenu", LoadSceneMode.Single);
    }
}
