using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour, IWin
{
    public void WinThis()
    {
        SceneManager.LoadScene("Cheat");
    }
}
