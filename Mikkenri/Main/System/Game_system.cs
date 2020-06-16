using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Game_system : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet = null;
    private GameObject _search_obj = null;
    public Transform _target_trans;
    [SerializeField]
    private List<Transform> _target_list = new List<Transform>();
    [SerializeField]
    private List<CinemachineVirtualCamera> _camera_list = new List<CinemachineVirtualCamera>();

    private int list_cnt = 0;
    private int _target_obj = 0;
    public int _enemy_count = 7;
    public float _hpcounter = 300.0f;
    private float _Clearcounter = 100.0f;
    //public float _wait = 0.0f;

    [SerializeField]
    private Slider _hpslider = null;
    [SerializeField]
    private Slider _clearslider = null;
    private Text _enemy_remaining;
    public AudioSource _audio;
    [SerializeField]
    public AudioClip _die_clip = null;
    [SerializeField]
    public AudioClip _push_clip = null;
    [SerializeField]
    public AudioClip _appear_clip = null;
    [SerializeField]
    public AudioClip _page_clip = null;

    private void Start()
    {
        _search_obj = GameObject.Find("Objects");
        _audio = GetComponent<AudioSource>();
        foreach(Transform child in _search_obj.transform)       //ターゲットのオブジェクトをリストに入れる
        {
            _target_list.Add(child);
        }
        Target_obj();   //ランダムで決める
        _clearslider.value = 100.0f;
        _hpslider.value = 300.0f;   //hpの設定
    }

    public void Update()
    {
      //  _wait += Time.deltaTime;
        _hpcounter -= 0.1f;
        _hpslider.value = _hpcounter;   //hpゲージ減少
   
        if (Input.GetKeyDown(KeyCode.Escape))   //マウスカーソル描画
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }

        if (_hpslider.value <= 0.0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Hp_reset()  //hp回復
    {
        _hpcounter = 300.0f;
    }

    private void Target_obj()   //ターゲット決める
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        _target_obj = Random.Range(0, _target_list.Count);   //10個から一つをランダムで取り、ターゲットを決める

        _target_list[_target_obj].gameObject.AddComponent<Object>();
        _camera_list[_target_obj].Priority++;
        _target_trans = _target_list[_target_obj];
    }

    public void Remove_obj()    //リストから消去
    {
        _target_list.RemoveAt(_target_obj);
        _camera_list.RemoveAt(_target_obj);
        Clear_SliderUp();
        _enemy_count--;

        if(_enemy_count <= 1)   //残りが１つになったらゲーム終了
        {
            GameEnd();
        }

        else
        {

            Target_obj();

        }
    }

    private void Clear_SliderUp()   //クリアーゲージ
    {
        _clearslider.value -= 17f;
    }

    public void GameEnd()   //ゲーム終了
    {
        Debug.Log("aaa");
        SceneManager.LoadScene("GameEnd");
        //ここにゲームエンド時の演出
    }

    public void Die_se()
    {
        _audio.PlayOneShot(_die_clip);
    }

    public void Push_se()
    {
        _audio.PlayOneShot(_push_clip);

    }

    public void Appear_se()
    {
        _audio.PlayOneShot(_appear_clip);

    }

    public void Page_se()
    {
        _audio.PlayOneShot(_page_clip);

    }
}
