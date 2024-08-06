using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
    public GameObject Player;
    public Transform instantiatePoint;

    public HealthManager healthManager;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<PlayerController>())
        {
            Player.transform.position = instantiatePoint.position;
            Debug.Log("Ellen got hurt!!");
            healthManager.health--;
        }
    }
}
