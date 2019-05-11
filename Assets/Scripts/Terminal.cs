using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] private GameObject door;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerController>().isKey && Input.GetKeyDown(KeyCode.E))
        {
            other.gameObject.GetComponent<PlayerController>().isKey = false;
            gameObject.GetComponent<AudioSource>().Play();
            StopCoroutine(other.gameObject.GetComponent<PlayerController>().fadeOff());
            Destroy(door);
        }
    }
}
