using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPopUp;
    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelPopUp.SetActive(true);
    }

    public void StopGame() 
    {
        Application.Quit();
    }
}
