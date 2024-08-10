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
            Debug.Log("Level Over!!");
            SceneManager.LoadScene("Scene_2");
        }
    }
}
