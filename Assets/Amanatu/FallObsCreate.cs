using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObsCreate : MonoBehaviour
{
    [SerializeField]
    private GameObject _fallObject; //落ちてくるもの

    [SerializeField]
    private float _interval;　//インターバル

    private float _timer; //タイマー
    void Start()
    {
        _timer = 0f;
    }

    void Update()
    {
        
        _timer += Time.deltaTime;
        //落とす感覚
        if( _timer >= _interval )
        {
            Debug.Log("aaaaaaa");
            _timer = 0f;
            Instantiate(_fallObject, transform);
            Debug.Log("bbbbbb");
        }

    }
}
