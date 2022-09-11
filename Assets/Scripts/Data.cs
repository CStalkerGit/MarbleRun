using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Data
{
    public static int Coins = 0;
    public static bool DisableInput = false;

    public static void Restart()
    {
        Coins = 0;
        DisableInput = false;
        SceneManager.LoadScene(0);
    }
}
