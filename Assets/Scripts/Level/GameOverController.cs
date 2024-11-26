using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject endScreen;
    public HealthManager healthManager;
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            // level is over
            print("Game Over!!");

            //LevelManager.Instance.MarkCurrentLevelComplete();
            endScreen.SetActive(true);
           
            SoundManager.Instance.Play(Sounds.TheEnd);

        }
    }
}
