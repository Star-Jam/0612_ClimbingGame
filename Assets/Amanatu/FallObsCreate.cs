using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObsCreate : MonoBehaviour
{
    [SerializeField]
    private GameObject _fallObject; //�����Ă������

    [SerializeField]
    private float _interval;�@//�C���^�[�o��

    private float _timer; //�^�C�}�[
    void Start()
    {
        _timer = 0f;
    }

    void Update()
    {
        
        _timer += Time.deltaTime;
        //���Ƃ����o
        if( _timer >= _interval )
        {
            Debug.Log("aaaaaaa");
            _timer = 0f;
            Instantiate(_fallObject, transform);
            Debug.Log("bbbbbb");
        }

    }
}
