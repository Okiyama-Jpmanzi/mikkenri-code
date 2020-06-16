using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    private float _alpha = 1.0f;
    private float _speed = 0.01f;
    private Image _ren;


    private void Start()
    {
        _ren = GetComponent<Image>();
    }

    private void Update()
    {
        if(_ren.color.a >= 0.0f)
        {
            _ren.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
            _alpha -= _speed;

        }
    }
}
