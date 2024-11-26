using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            // level is over
            print("Level Over!!");
            
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SoundManager.Instance.Play(Sounds.ClearLevel);

        }
    }
}
