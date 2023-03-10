using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //move to middle of screen
        while (player.transform.position.x < -0.088f)
        {
            player.transform.position += new Vector3(0.01f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        
        // make player turn left
        player.transform.localScale = new Vector3(-player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);
        
        // make dialogue is alway scale +
        GameObject dialoguePlayerGameObject = player.transform.GetChild(0).gameObject;
        dialoguePlayerGameObject.transform.localScale = new Vector3(-dialoguePlayerGameObject.transform.localScale.x, dialoguePlayerGameObject.transform.localScale.y, dialoguePlayerGameObject.transform.localScale.z);
        
        // type dialogue endgame
        PlayerDialogue dialoguePlayer = dialoguePlayerGameObject.GetComponent<PlayerDialogue>();
        dialoguePlayer.Ending();
        
        yield return new WaitForSeconds(32f);

        // load menu scene
        GameManager.instance.LoadNextStage();
    }
}
