using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKickStone : MonoBehaviour
{
    public static SoundKickStone instance;
    AudioSource[] allSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        allSound = transform.GetComponentsInChildren<AudioSource>();
    }

    public void PlayKickSound()
    {
        int random = Random.Range(0, allSound.Length);
        allSound[random].Play();
    }
}
