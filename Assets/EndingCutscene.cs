using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
        StartCoroutine(ending());
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(2f);
        while (player.transform.position.x < -0.088f)
        {
            player.transform.position += new Vector3(0.0025f, 0, 0);
            yield return new WaitForSeconds(0.0025f);
        }
        yield return new WaitForSeconds(2f);
        player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
        GameObject dialoguePlayerGameObject = player.transform.GetChild(0).gameObject;
        dialoguePlayerGameObject.transform.localScale = new Vector3(-dialoguePlayerGameObject.transform.localScale.x, dialoguePlayerGameObject.transform.localScale.y, dialoguePlayerGameObject.transform.localScale.z);
        PlayerDialogue dialoguePlayer = dialoguePlayerGameObject.GetComponent<PlayerDialogue>();
        dialoguePlayer.Ending();
    }
}
