using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour, IWin
{
    public void WinThis()
    {
        SceneManager.LoadScene("Win");
    }
}
