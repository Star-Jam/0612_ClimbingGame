using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObsBreak : MonoBehaviour
{
    [SerializeField]
    private string _deathTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _deathTag)
        { 
            Destroy(gameObject);
        }
    }
}
