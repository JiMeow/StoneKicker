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

    float soundDeadScale;
    float soundKickScale;
    float soundWinScale;
    float soundBgScale;

    public int newMusicScale = 5;
    public int newSfxScale = 5;

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
        soundDeadScale = allDeadSound[0].volume;
        soundKickScale = allKickSound[0].volume;
        soundWinScale = allWinSound[0].volume;
        soundBgScale = bgSound.volume;
    }

    private void Update()
    {
        bgSound.volume = soundBgScale * (float)newMusicScale / 10f;
    }

    public void PlayDeadSound()
    {
        int random = Random.Range(0, allDeadSound.Length);
        allDeadSound[random].volume = soundDeadScale * (float)newSfxScale / 10f;
        allDeadSound[random].Play();
    }

    public void PlayKickSound()
    {
        int random = Random.Range(0, allKickSound.Length);
        allKickSound[random].volume = soundKickScale * (float)newSfxScale / 10f;
        allKickSound[random].Play();
    }

    public void PlayWinSound()
    {
        int random = Random.Range(0, allWinSound.Length);
        allWinSound[random].volume = soundWinScale * (float)newSfxScale / 10f;
        allWinSound[random].Play();
    }
}
