
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private GameObject _particle = null;
    private Game_system _game_system_sri;
    private GameObject _game_system_obj;
    private BoxCollider _box;
    private GameObject _enemy;

    private void Start()
    {
        gameObject.tag = "Objects";
        _game_system_obj = GameObject.Find("GameSystem");
        _game_system_sri = _game_system_obj.GetComponent<Game_system>();
        _box = GetComponent<BoxCollider>();

        _particle = GameObject.Find("Smoke");
        _particle.transform.position = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            _particle.GetComponent<ParticleSystem>().Play();
            _game_system_sri.Appear_se();
            _box.enabled = false;
            StartCoroutine("Wait");        
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f);
        _game_system_sri.Hp_reset();
        _enemy = (GameObject)Resources.Load("Enemy");
        Instantiate(_enemy, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
