using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumPClumb : MonoBehaviour
{
    private float _jumpCounter;     // �W�����v���ߎ��Ԋi�[
    private bool _jumpingFlag;      // �W�����v���ߒ� 
    private bool _tochedStonFlag;   //
    private float _donotTochCounter; // ストーンを触らない時間をカウント
    private bool _donotTochFlag;    // ストーンを触らないフラグ
    [SerializeField] float _jumpPower = 15;  // �W�����v�̍ő�p���[
    [SerializeField] float _jumpCountMax = 3;  // �W�����v�̍ő嗭�ߎ���(s) 
    [SerializeField] float _donotTochStonTime = 2;      // 次のストーンに移動するn(s)秒石を無視
    [SerializeField] float _lateralSpeed = 5.0F;         // m/s
    // �R���|�[�l���g�ǉ� (����z��)
    Rigidbody2D rigidbody;
    Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        _jumpCounter = 0;
        _donotTochCounter = 0;
        _donotTochFlag = false;
        _jumpingFlag = false;
        _tochedStonFlag = false;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // --  二段ジャンプ防止処理 -- 
        // -- ストーンに触れているとき
        if (_tochedStonFlag)
        {
            if (_donotTochCounter <= 0)
            {
                // ストーンに触れた位置で停止する
                this.rigidbody.velocity = new Vector3(0, 0, 0);
                this.rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
                this.rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            }

        } else
        {
            // -- ストーンに触れていないとき -- 
            // - ジャンプ中の処理 -  
            rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _lateralSpeed, rigidbody.velocity.y);
            // - ジャンプしていない時 -
        }
        if (!_jumpingFlag)
        {
            // スペースキーでジャンプ力溜めを実行
            if (Input.GetKey(KeyCode.Space))
            {
                _jumpCounter += Time.fixedDeltaTime;
                if (_jumpCounter > _jumpCountMax)
                {
                    _jumpCounter = _jumpCountMax;
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    _jumpingFlag = true;
                    _tochedStonFlag = false;
                    animator.SetBool("IsJump", true);
                    // ストーンから離れる
                    this.rigidbody.constraints = RigidbodyConstraints2D.None;
                    // ストーンから離れた後、指定時間
                    _donotTochCounter = _donotTochStonTime;

                    // スペースキーのリリースでジャンプ実行
                    rigidbody.AddForce(transform.up * PowerCalc(_jumpCounter), ForceMode2D.Impulse);
                    _jumpCounter = 0;
                }
            }
        }
        _donotTochCounter -= Time.fixedDeltaTime;
        if(_donotTochCounter <= 0)
        {
            _donotTochCounter = 0;
        }
    }

    float PowerCalc(float count)
    {
        // --- ���ߎ��Ԃɉ�����addForce�̑傫���𐧌� ---
        
        if(count <= _jumpCountMax)
        {
            // ���Ԋ����ɉ����ăp���[��Ԃ�
            float temp = _jumpPower * (_jumpCounter / _jumpCountMax);
            Debug.Log(temp);
            return temp;


        } else
        {
            // �ő�p���[��Ԃ�

            return _jumpPower; 
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
 
        if (other.gameObject.tag == "Stone")
        {
            _tochedStonFlag = true;
            _jumpingFlag = false;
            animator.SetBool("IsJump", false);
            Debug.Log(_tochedStonFlag + " " + _jumpingFlag);
        }
        
    }

}
