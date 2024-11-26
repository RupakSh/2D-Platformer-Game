using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            print("Someone collided with us");
            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();
            playercontroller.pickupkey();
            Destroy(gameObject);
        }
    }
}
