using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Text myText;
    [SerializeField] Canvas myCanvas;
    [SerializeField] GameObject myPlayer;
    [SerializeField] Image crossair;
    [SerializeField] Values myValues;
    Shoot myShootCombat;


    bool walking = true;
    bool sprinting = false;
    bool playOnce = true;

    
    private IEnumerator Wait(int seconds, string myString)
    {
        yield return new WaitForSeconds(seconds);

        myText.text = myString;
    }


    private void Awake()
    {
        myShootCombat = myPlayer.GetComponent<Shoot>();
    }
    private void TuTorial()
    {
        #region WASD
        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                myText.text = "well done";
                walking = false;
                sprinting = true;
            }
        }

        if (sprinting)
        {
            if (playOnce)
            {
                StartCoroutine(Wait(2, "now try to spint with LShift"));
                playOnce = false;
                Destroy(myPlayer.GetComponent<walk>());
            }


            if (myPlayer.GetComponent<SprintMove>() == null)
            {
                myPlayer.AddComponent<SprintMove>();
            }


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Wait(2, "good job"));
                StartCoroutine(Wait(2, "you can also shoot, you can do this with the right and then left mouse button"));


                if (myShootCombat.isActiveAndEnabled == false)
                {
                    myShootCombat.enabled = true;
                }
                crossair.gameObject.SetActive(true);

                StartCoroutine(Wait(4, "you do also have some skills"));
                StartCoroutine(Wait(4, "i have given you a skillpoint"));
                myValues.skillPoints++;
                StartCoroutine(Wait(4, "try to open the skill trhee with the B key"));
                

            }
        }
        #endregion
    }

    private void Update()
    {
        TuTorial();
    }
}
