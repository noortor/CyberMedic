﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class DialogueChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public readonly Color GREEN = new Color(0.484375f, 0.70703125f, 0.64453125f, 1);
    private DialogueManager dialogueManager;
    private GameObject dialogueChoiceButtons;
    private Image image;
    private TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueManager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        dialogueChoiceButtons = GameObject.Find("Choice Buttons");
        image = this.GetComponent<Image>();
        buttonText = this.GetComponentInChildren<TextMeshProUGUI>();
        GetComponent<Button>().onClick.AddListener(makeChoice);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = GREEN;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }
    public void makeChoice()
    {
        image.color = Color.white;
        dialogueManager.advanceFrame(buttonText.text);
    }


    public void setChoiceText(string choice)
    {
        buttonText.text = choice;
    }

    public string getChoiceText()
    {
        return buttonText.text;
    }

}
