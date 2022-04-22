// File: ButtonBehaviour.cs
// Author: Pauleen Lam (STU# 101065605)
// Date Last Modified: 2021-10-24
// 
// Description: Functions for buttons, plays a sound upon click.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    // Go to game scene
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    // Go to instructions scene
    public void OnHowToPlayButtonPressed()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    // Go to start scene
    public void OnHomeButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // For Debugging purposes, go straight to gameover scene
    public void OnLoseButtonPressed()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
