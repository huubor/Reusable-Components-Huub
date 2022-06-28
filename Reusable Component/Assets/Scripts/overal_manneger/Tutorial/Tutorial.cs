using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Canvas myCanvas;
    [SerializeField] GameObject myPlayer;
    [SerializeField] GameObject myCam;
    [SerializeField] Image crossair;
    [SerializeField] Values myValues;


    [SerializeField] AudioClip wasdAudio;
    [SerializeField] AudioClip sprintAudio;
    [SerializeField] AudioClip shootAudio;
    [SerializeField] AudioClip skillPointAudio;


    Shoot myShootCombat;

    private AudioSource mySource;
    private AudioClip myClip;

    bool walking = true;
    bool sprinting = false;
    bool playOnce = true;
    bool playAudio = true;


    private void Awake()
    {
        myShootCombat = myPlayer.GetComponent<Shoot>();
        mySource = myCam.GetComponent<AudioSource>();

        mySource.clip = wasdAudio;
        mySource.Play();
    }
    private void TuTorial()
    {
        #region WASD
        if (walking)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && !mySource.isPlaying)
            {
                walking = false;
                sprinting = true;
            }
        }

        if (sprinting && !mySource.isPlaying && playAudio)
        {
            if (playOnce)
            {
                mySource.clip = sprintAudio;  
                mySource.Play();

                playOnce = false;
                Destroy(myPlayer.GetComponent<walk>());
            }


            if (myPlayer.GetComponent<SprintMove>() == null)
            {
                myPlayer.AddComponent<SprintMove>();
            }


            if (Input.GetKey(KeyCode.LeftShift) && !mySource.isPlaying && playAudio)
            {
                mySource.clip = shootAudio;
                mySource.Play();


                if (myShootCombat.isActiveAndEnabled == false)
                {
                    myShootCombat.enabled = true;
                }
                crossair.gameObject.SetActive(true);

                myValues.skillPoints++;
            }

            if(myValues.skillPoints == 1 && !mySource.isPlaying && playAudio)
            {
                mySource.clip = skillPointAudio;
                mySource.Play();
                playAudio = false;
            }
        }
        #endregion
    }

    private void Update()
    {
        TuTorial();
    }
}
