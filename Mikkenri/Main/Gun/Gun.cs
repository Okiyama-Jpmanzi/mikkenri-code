using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    public GameObject _bullet = null;
    [SerializeField]
    public Transform _muzzle = null;
    private AudioSource _audio;
    [SerializeField]
    private AudioClip _clip = null;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audio.PlayOneShot(_clip);
            Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
        }
    }

}
