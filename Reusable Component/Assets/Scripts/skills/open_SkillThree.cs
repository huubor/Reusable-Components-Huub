using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class open_SkillThree : MonoBehaviour
{
    [SerializeField] Canvas _Interface;
    [SerializeField] Canvas _SkillThree;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                _Interface.gameObject.SetActive(false);
                _SkillThree.gameObject.SetActive(true);
            }

            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                _Interface.gameObject.SetActive(true);
                _SkillThree.gameObject.SetActive(false);
            }
        }
    }
}
