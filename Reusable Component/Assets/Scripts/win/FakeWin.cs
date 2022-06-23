using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWin : MonoBehaviour, IWin
{
    [SerializeField] GameObject pPlayer;
    [SerializeField] GameObject checkpoint;

    [SerializeField] AudioSource playAudio;
    public void WinThis()
    {
        pPlayer.transform.position = checkpoint.transform.position;
        playAudio.Play();
    }
}
