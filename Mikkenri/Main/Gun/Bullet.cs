using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _lifetime = 1.0f;

    private void Start()
    {
        var velocity = _speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
        Destroy(gameObject, _lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   
             Destroy(gameObject);
    }
}
