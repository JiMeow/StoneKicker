using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;

    [SerializeField]
    GameObject BgSound;
    AudioSource bgSound;
    [SerializeField]
    GameObject DeadSound;
    AudioSource[] allDeadSound;
    [SerializeField]
    GameObject KickSound;
    AudioSource[] allKickSound;
    [SerializeField]
    GameObject WinSound;
    AudioSource[] allWinSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        bgSound = BgSound.GetComponent<AudioSource>();
        allDeadSound = DeadSound.GetComponentsInChildren<AudioSource>();
        allKickSound = KickSound.GetComponentsInChildren<AudioSource>();
        allWinSound = WinSound.GetComponentsInChildren<AudioSource>();
    }

    public void PlayDeadSound()
    {
        int random = Random.Range(0, allDeadSound.Length);
        allDeadSound[random].Play();
    }

    public void PlayKickSound()
    {
        int random = Random.Range(0, allKickSound.Length);
        allKickSound[random].Play();
    }

    public void PlayWinSound()
    {

        int random = Random.Range(0, allWinSound.Length);
        allWinSound[random].Play();
    }
}
