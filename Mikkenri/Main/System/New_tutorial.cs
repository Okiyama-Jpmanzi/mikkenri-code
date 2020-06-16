using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class New_tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel_tuto = null;
    [SerializeField]
    private GameObject _text_tuto = null;

    private GameObject _pause_obj;
    private Pause _pause_sri;
    private Game_system _game_system_sri;
    private GameObject _game_system_obj;



    private void Start()
    {
        _pause_obj = GameObject.Find("Pause");
        _pause_sri = _pause_obj.GetComponent<Pause>();
        _game_system_obj = GameObject.Find("GameSystem");
        _game_system_sri = _game_system_obj.GetComponent<Game_system>();

        _panel_tuto.SetActive(true);
        _text_tuto.SetActive(true);
    }

    public void EndTutorial()
    {
       // _game_system_sri.Push_se();
        _pause_sri.UnPause();
        _panel_tuto.SetActive(false);
        _text_tuto.SetActive(false);

    }
}
