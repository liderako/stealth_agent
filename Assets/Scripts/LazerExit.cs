using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerExit : MonoBehaviour
{
    public PlayerController _pc;
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.GetComponent<PlayerController>().isWeapon = false;
            _pc.fire();
            Destroy(gameObject);
        }
    }
}
