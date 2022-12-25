using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    Transform[] musicScale;
    Transform[] sfxScale;
    int nowMusicScale;
    int nowSfxScale;
    void Start()
    {
        nowMusicScale = Sound.instance.newMusicScale;
        nowSfxScale = Sound.instance.newSfxScale;
        musicScale = GameObject.Find("MusicUI").GetComponentsInChildren<Transform>();
        sfxScale = GameObject.Find("SFXUI").GetComponentsInChildren<Transform>();
        ChangeMusicUI();
        ChageSFXUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            DecreaseMusicScale();
        if (Input.GetKeyDown(KeyCode.E))
            IncreaseMusicScale();
        if (Input.GetKeyDown(KeyCode.A))
            DecreaseSFXScale();
        if (Input.GetKeyDown(KeyCode.D))
            IncreaseSFXScale();
        Sound.instance.newMusicScale = nowMusicScale;
        Sound.instance.newSfxScale = nowSfxScale;
    }

    public void IncreaseMusicScale()
    {
        nowMusicScale += 1;
        nowMusicScale = Mathf.Min(nowMusicScale, 10);
        ChangeMusicUI();
    }

    public void DecreaseMusicScale()
    {
        nowMusicScale -= 1;
        nowMusicScale = Mathf.Max(nowMusicScale, 0);
        ChangeMusicUI();
    }

    public void IncreaseSFXScale()
    {
        nowSfxScale += 1;
        nowSfxScale = Mathf.Min(nowSfxScale, 10);
        ChageSFXUI();
    }

    public void DecreaseSFXScale()
    {
        nowSfxScale -= 1;
        nowSfxScale = Mathf.Max(nowSfxScale, 0);
        ChageSFXUI();
    }

    void ChangeMusicUI()
    {
        for (int i = 1; i < musicScale.Length; i++)
        {
            if (i <= nowMusicScale)
            {
                SetUIToNormal(musicScale[i].gameObject);
            }
            else
            {
                SetUIToTranParent(musicScale[i].gameObject);
            }
        }
    }

    void ChageSFXUI()
    {
        for (int i = 1; i < sfxScale.Length; i++)
        {
            if (i <= nowSfxScale)
            {
                SetUIToNormal(sfxScale[i].gameObject);
            }
            else
            {
                SetUIToTranParent(sfxScale[i].gameObject);
            }
        }
    }

    void SetUIToTranParent(GameObject g)
    {
        Color color = g.GetComponent<SpriteRenderer>().color;
        g.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 100f/255f);
    }

    void SetUIToNormal(GameObject g)
    {
        Color color = g.GetComponent<SpriteRenderer>().color;
        g.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1);
    }
}
