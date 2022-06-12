using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResulutTime : MonoBehaviour
{
    [SerializeField]
    Text _timeText;

    private void Start()
    {
        _timeText.text = DataManager.ClearTime;
    }
}
