using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour, IDamage
{
    public void DamageThis()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
