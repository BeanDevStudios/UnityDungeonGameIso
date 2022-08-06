using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC_Trigger : MonoBehaviour
{
    private int interactionCount = 0;
    public NPCConversation conv1;
    public NPCConversation conv2;
    public AudioSource playSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

     void OnTriggerEnter2D(Collider2D other)
    {
        playSound.Play();

        if(interactionCount == 0)
        {
            firstTalk();
        }
        else
        {
            secondTalk();
        }
    }

    private void firstTalk()
    {
        interactionCount = 1;
        ConversationManager.Instance.StartConversation(conv1);
    }

    private void secondTalk()
    {
        ConversationManager.Instance.StartConversation(conv2);
    }
}
