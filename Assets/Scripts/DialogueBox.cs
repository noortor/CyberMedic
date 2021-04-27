using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class DialogueBox : MonoBehaviour, IPointerClickHandler
{
    private GameObject dialogueManager;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueManager = GameObject.Find("Dialogue Manager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        dialogueManager.GetComponent<DialogueManager>().advanceDisplay();
    }
}
