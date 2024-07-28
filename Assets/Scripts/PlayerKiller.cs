using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
    public GameObject Player;
    public Transform instantiatePoint;

    public PlayerController playerController;

    private void Awake()
    {
        playerController = Player.GetComponent<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerController>())
        {            
            Player.transform.position = instantiatePoint.position;
            playerController.health -= 1;
        } 
    }
}
