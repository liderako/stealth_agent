using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySlider : MonoBehaviour
{
    private Slider _slider;
    public Image _image;
    public GameObject _gameOverPanel;
    public AudioSource _endGame;
    public bool isGameOver;
    public bool isPanic;
    public bool isNormal;
    [SerializeField] private PlayerController _pc;
    public AudioSource _panic;
    public AudioSource _normal;
    
    
    public void Start()
    {
        isNormal = true;
       _slider = GetComponent<Slider>();
    }
    
    public void Update()
    {
        if (_slider.value >= 100 && !isGameOver)
        {
            isGameOver = true;
            _gameOverPanel.SetActive(true);
            _endGame.Play();
            _pc.end = true;
            _panic.Stop();
            _normal.Stop();
            StartCoroutine(restart());
        }
        else if (_slider.value >= 65 && _slider.value <= 99)
        {
            if (!isPanic)
            {
                _normal.Stop();
                _panic.Play();
                isPanic = true;
            }
            _image.color = Color.red;
        }
        else if (_slider.value < 75)
        {
            if (!isNormal)
            {
                isNormal = true;
                _panic.Stop();
                _normal.Play();
            }
            _image.color = Color.white;
        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(5);
        Application.LoadLevel(Application.loadedLevel);
    }
}
