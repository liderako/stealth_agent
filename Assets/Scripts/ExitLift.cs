using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLift : MonoBehaviour
{
    [SerializeField] private GameObject _gm1;
    [SerializeField] private GameObject _gm2;
    [SerializeField] private GameObject _panel;
    [SerializeField] private PlayerController _pc;
    
    public AudioSource _victorySource;
    public AudioSource _restarting;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            
            Destroy(_gm1);
            Destroy(_gm2);
            _victorySource.Play();
            _panel.SetActive(true);
            _pc.end = true;
            StartCoroutine(restart());
        }
    }
    
    IEnumerator restart()
    {
        yield return new WaitForSeconds(10);
        _restarting.Play(1);
        yield return new WaitForSeconds(5);
        Application.LoadLevel(Application.loadedLevel);
    }
}
