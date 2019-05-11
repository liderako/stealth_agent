using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class active : MonoBehaviour
{
    public string action;

    public Text _text;
    
    public bool isFade;
    
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player" && isFade)
        {
            StartCoroutine(fadeOff());
            isFade = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isFade)
        {
            StartCoroutine(fadeOff());
            isFade = false;
        }
    }

    IEnumerator fadeUp()
    {
        float delta = 0.1f;
        for (int i = 0; i < 10; i++) {
            _text.color = new Color(255, 255, 255, delta);
            yield return new WaitForSeconds(0.1f);
            delta += 0.1f;
        }
    }
    
    IEnumerator fadeOff()
    {
        float delta = 1f;
        for (int i = 0; i < 10; i++) {
            _text.color = new Color(255, 255, 255, delta);
            yield return new WaitForSeconds(0.1f);
            delta -= 0.1f;
        }
        _text.text = "";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !isFade)
        {
            StartCoroutine(fadeUp());
            _text.text = action;
            isFade = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isFade)
        {
            StartCoroutine(fadeUp());
            _text.text = action;
            isFade = true;
        }
    }


}
