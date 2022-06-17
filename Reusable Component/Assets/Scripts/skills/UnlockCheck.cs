using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCheck : MonoBehaviour
{
    [SerializeField] Button JetJump;
    [SerializeField] GameObject myValueObject;
    [SerializeField] GameObject _Player;
    private Values myValues;

    private void Awake()
    {
        myValues = myValueObject.GetComponent<Values>();
    }

    public void UnlockJetJump()
    {
        if (myValues.skillPoints >= 1)
        {
            _Player.AddComponent<JetJump>();
            myValues.skillPoints--;
        }
        else
        {
            Debug.Log("niet genoeg punten");
        }
    }
}
