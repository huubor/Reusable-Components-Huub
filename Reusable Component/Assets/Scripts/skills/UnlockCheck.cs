using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCheck : MonoBehaviour
{
    [SerializeField] Button JetJump;
    [SerializeField] Values myValues;

    private void Awake()
    {
        JetJump.onClick.AddListener(UnlockJetJump);
    }

    private void UnlockJetJump()
    {
        if(myValues.skillPoints >= 1)
        {

        }
    }
}
