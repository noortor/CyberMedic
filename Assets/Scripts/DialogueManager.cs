using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private DialogueLoader loader;
    private DialogueFrame currentDialogueFrame;
    private GameObject dialogueBox;
    private static DialogueManager _instance;
    public static DialogueManager Instance { get { return _instance; } }
    private void Awake()
    {
        // Ensure singleton behavior
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void triggerDialogue(string characterName)
    {

    }

    private void startDialogue(string id)
    {

    }

}
