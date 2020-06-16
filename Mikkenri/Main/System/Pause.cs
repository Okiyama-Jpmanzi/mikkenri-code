using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Game_system _game_system_sri;
    public FovAngleController _fovangle_sri;
    public PlayerCon _playercon_sri;
    public Gun _gun_sri;

    public GameObject _game_system_obj;
    public GameObject _fovangle_obj;
    public GameObject _playercon_obj;
    public GameObject _gun_obj;
    [SerializeField]
    public GameObject _pause_obj;

	private bool _check = false;

    //ボタンによる進行、keycodeではなく


    private void Start()
    {
        _game_system_obj = GameObject.Find("GameSystem");
        _fovangle_obj = GameObject.Find("MainCamera");
        _playercon_obj = GameObject.Find("Player");
        _gun_obj = GameObject.Find("Gun");

        _game_system_sri = _game_system_obj.GetComponent<Game_system>();
        _fovangle_sri = _fovangle_obj.GetComponent<FovAngleController>();
        _playercon_sri = _playercon_obj.GetComponent<PlayerCon>();
        _gun_sri = _gun_obj.GetComponent<Gun>();
        OnPause();
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))     //ポーズ
        {
			if(!_check)
			{ 
				OnPause();	
				_check = true;
			}
			
			else 
			{
				UnPause();
				_check = false;
			}
        }
        
    }

    public void OnPause()       //ポーズ
    {
        _game_system_sri.enabled = false;
        _fovangle_sri.enabled = false;
        _playercon_sri.enabled = false;
        _gun_sri.enabled = false;
        _pause_obj.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }

    public void UnPause()       //ポーズ解除
    {
        _game_system_sri.enabled = true;
        _fovangle_sri.enabled = true;
        _playercon_sri.enabled = true;
        _gun_sri.enabled = true;
        _pause_obj.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;   //マウス消す
        Cursor.visible = false;

    }
}
