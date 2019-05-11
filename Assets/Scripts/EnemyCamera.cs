using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCamera : MonoBehaviour
{
    public Slider slider;
    public PlayerController player;
    public float oldTime;
    public bool isPlayer;
    public float _step;
        
    public void Start()
    {
        oldTime = Time.time;
    }
    
    private void Update()
    {
        if (Time.time - oldTime > _step)
        {
            if (!player.isZona)
            {
                slider.value -= 2;
            }
            if (player.isZona && isPlayer)
            {
                slider.value += 2;
            }
            oldTime = Time.time;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.isZona = true;
            isPlayer = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.isZona = false;
            isPlayer = false;
        }
    }
}
