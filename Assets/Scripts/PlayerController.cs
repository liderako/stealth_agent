using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;

    public GameObject camera;

    [HideInInspector]public bool isKey;
    [SerializeField] public bool isWeapon;

    public AudioSource _audioFire;

    public AudioSource _pick;
    
    public bool isZona;

    public bool end;

    public Text _text;
    
    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(fadeOff());
    }

    public IEnumerator fadeOff()
    {
        float delta = 1f;
        for (int i = 0; i < 10; i++) {
            _text.color = new Color(255, 255, 255, delta);
            yield return new WaitForSeconds(0.1f);
            delta -= 0.1f;
        }
        _text.text = "";
    }
    
    void Update()
    {
        if (!end)
            transform.rotation = Quaternion.Euler(0.0f, camera.transform.rotation.eulerAngles.y, 0.0f);
    }

    private void FixedUpdate()
    {
        if (!end)
            Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {   
            _rb.AddForce(transform.forward * _speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(-transform.forward * _speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {   
            _rb.AddForce(transform.right * _speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(-transform.right * _speed, ForceMode.Force);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Key" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(other.gameObject);
            StartCoroutine(fadeOff());
            isKey = true;
            pick();
        }
    }

    public void fire()
    {
        _audioFire.Play();
    }

    public void pick()
    {
        _pick.Play();
    }
}
