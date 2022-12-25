using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PlayerDialogue : MonoBehaviour
{
    public static PlayerDialogue instance;
    public float typeSpeed = 0.05f;
    public float typeEndingSpeed = 0.1f;
    public float timeDisplay = 3f;

    TMP_Text playerDialogue;
    string[] dialogueDejavu;
    [SerializeField] 
    string[] ending;

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
        playerDialogue = GetComponent<TMP_Text>();
        dialogueDejavu = new string[]
        {
            "I feel like I've been here before.",
            "This feels familiar, but I can't quite place it.",
            "I could swear I've experienced this exact moment before.",
            "It's like I've lived this moment before.",
            "This is déjà vu all over again.",
            "I feel like I've done this a million times before.",
            "This feels like déjà vu.",
            "I could have sworn I've been in this exact situation before.",
            "I feel like I've seen this all before.",
            "This feels like déjà vu to me.",
            "It's like I've been here before.",
            "I feel like I've done this before.",
            "This feels like déjà vu all over again.",
            "I could have sworn I've experienced this before.",
            "I feel like I've been through this before.",
            "It's like I've done this a million times before.",
            "This feels like déjà vu to me.",
            "I feel like I've been in this exact situation before.",
            "I could have sworn I've seen this all before."
        };
        
        Invoke("DejaVu",1.5f);
    }

    private void Update()
    {
        // make dialogue alway scale +
        float parentXscale = transform.parent.transform.localScale.x/Mathf.Abs(transform.parent.transform.localScale.x);
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x)*parentXscale, transform.localScale.y, transform.localScale.z);
    }
    
    // dialogue in ending cutscene
    public void Ending()
    {
        StartCoroutine(EndingCoroutine());
    }

    IEnumerator EndingCoroutine()
    {
        foreach (string s in ending)
        {
            foreach(char word in s)
            {
                playerDialogue.text += word;
                yield return new WaitForSeconds(typeEndingSpeed);
            }
            yield return new WaitForSeconds(timeDisplay);
            playerDialogue.text = "";
        }
    }

    // dialogue when die more than 10 times
    public void DejaVu()
    {
        if (StageCount.instance == null)
            return;
        if (StageCount.instance.restart <= 10)
            return;
        int random = Random.Range(0, dialogueDejavu.Length);
        playerDialogue.text = "";
        StartCoroutine(TypeText(dialogueDejavu[random]));
    }

    // type text with given string
    IEnumerator TypeText(string s)
    {
        foreach (char word in s)
        {
            playerDialogue.text += word;
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return new WaitForSeconds(timeDisplay);
        playerDialogue.text = "";
    }
}
