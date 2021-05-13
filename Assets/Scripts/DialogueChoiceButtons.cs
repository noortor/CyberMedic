﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoiceButtons : MonoBehaviour
{
    private List<GameObject> buttons;
    public readonly int CHOICE_COUNT = 3;
    // Start is called before the first frame update
    void Awake()
    {
        buttons = new List<GameObject>();
        for (int i = 0; i < CHOICE_COUNT; i++)
        {
            buttons.Add(GameObject.Find("Choice Button " + (i + 1)));
            buttons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadButtons(string[] choices)
    {
        for (int i = 0; i < choices.Length; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponent<DialogueChoiceButton>().setChoiceText(choices[i]);
        }
        for (int i = choices.Length; i < CHOICE_COUNT; i++)
        {
            buttons[i].SetActive(false);
            buttons[i].GetComponent<DialogueChoiceButton>().setChoiceText("");
        }
    }
}
