using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.GetComponent<PlayerController>().isWeapon = true;
            Destroy(gameObject);
        }
    }
}
