using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    private float _speed = 3.0f;

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * _speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * _speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * _speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * _speed * Time.deltaTime;
            }
        }
}
