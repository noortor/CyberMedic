using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;


public class DialogueBox : MonoBehaviour, IPointerClickHandler
{
    private DialogueManager dialogueManager;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI dialogueText;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("running awake");
        dialogueManager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        dialogueText = GameObject.Find("Dialogue Text").GetComponent<TextMeshProUGUI>();
        nameText = GameObject.Find("Name Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateBoxContent(string name, string text)
    {
        Debug.Log(nameText);
        Debug.Log(dialogueText);
        nameText.text = name;
        dialogueText.text = text;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        dialogueManager.advanceFrame("default");
    }
}
