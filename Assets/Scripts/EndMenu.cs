using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private GameObject playAgainButton;
    
    // restarting the game
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        
    }

    public void QuitGame()
    {
        Application.Quit();
        SoundManager.Instance.Play(Sounds.ButtonClick);
    }
}
