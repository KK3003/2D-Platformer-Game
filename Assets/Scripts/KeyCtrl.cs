using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerCtrl>()!= null)
        {
            PlayerCtrl playerctrl = collision.gameObject.GetComponent<PlayerCtrl>();
            playerctrl.pickUpKey();
            Destroy(gameObject);
        }
    }
}
