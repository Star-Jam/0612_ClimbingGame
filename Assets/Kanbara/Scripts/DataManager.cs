using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static string ClearTime { get; private set; }

    public static void SetTime(string time)
    {
        ClearTime = time;
    }
}
