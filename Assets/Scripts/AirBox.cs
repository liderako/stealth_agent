using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBox : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ps;

    [SerializeField] private EnemyCamera _camera;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            _camera._step = 0.09f;
            _ps.Play();
        }
    }
}
