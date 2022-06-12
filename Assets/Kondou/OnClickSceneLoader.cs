using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSceneLoader : MonoBehaviour
{
    [SerializeField]
    [Header("ロードするシーンの名前")]
    string _loadSceneName;
    public void OnClickSceneLoad()
    {
        SceneLoder.LoadScene(_loadSceneName);
    }
}
