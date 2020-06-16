using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_enemy : MonoBehaviour
{
    private Game_system _game_system_sri;
    private GameObject _game_system_obj;

    private Renderer _ren;
    private Color _alpha_color = new Color(0.0f, 0.0f, 0.0f, 0.01f);
    private BoxCollider _box;

    private GameObject _point_obj;
    private GameObject _point_obj1;
    private GameObject _point_obj2;
    private GameObject _point_obj3;
    private GameObject _die_effect;

    private float _alpha = 0.0f;
    private float _speed = 0.03f;
    [SerializeField]
    private int _root = 0;



    private void Start()
    {
        _point_obj = GameObject.Find("Point");
        _point_obj1 = GameObject.Find("Point1");
        _point_obj2 = GameObject.Find("Point2");
        _point_obj3 = GameObject.Find("Point3");
        _die_effect = GameObject.Find("Die_effect");
        Random.InitState(System.DateTime.Now.Millisecond);
        _root = Random.Range(0, 4);

        _box = GetComponent<BoxCollider>();
        _box.enabled = false;
        _ren = GetComponent<Renderer>();
        _game_system_obj = GameObject.Find("GameSystem");
        _game_system_sri = _game_system_obj.GetComponent<Game_system>();

    }

    private void Update()
    {
        Vector3 _pos = gameObject.transform.position;

        if(_pos.y <= 2.80f)
        {
            gameObject.transform.position = new Vector3(_pos.x, _pos.y + 0.01f, _pos.z);
            
        }
        
        if(_pos.y >= 2.80f){

            _box.enabled = true;
            Root();
        }
        
        if (_ren.material.color.a <= 1.0f)
        {
            _ren.material.color += _alpha_color;
        }



    }

    private void Root()
    {
        switch (_root)
        {
            case 0:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _point_obj.transform.position, _speed);
                break;
            case 1:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _point_obj1.transform.position, _speed);
                break;
            case 2:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _point_obj2.transform.position, _speed);
                break;
            case 3:
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _point_obj3.transform.position, _speed);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Bullet")
        {
            if(_ren.material.color.a >= 1.0f)
            {
                _die_effect.transform.position = gameObject.transform.position;
                _die_effect.GetComponent<ParticleSystem>().Play(); ;
              //  _game_system_sri._wait = 0.0f;
                _game_system_sri.Remove_obj();
                _game_system_sri.Die_se();
                Destroy(gameObject);
            }       
        }

        if(collision.gameObject.tag == "Point")
        {
            _root++;
            if(_root >= 4)
            {
                _root = 0;
            }
        }
    }
}
