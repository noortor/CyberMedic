﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private FrameLoader frameLoader;
    private Frame currentFrame;

    private ImageLoader imageLoader;

    private static DialogueManager _instance;
    private GameObject dialogueBox;
    private GameObject choiceButtons;

    private SpriteRenderer portrait;
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
        dialogueBox = GameObject.Find("Dialogue Box");
        choiceButtons = GameObject.Find("Choice Buttons");

        portrait = GameObject.Find("Portrait").GetComponent<SpriteRenderer>();

        frameLoader = new FrameLoader();
        imageLoader = new ImageLoader();
        frameLoader.Load();
        imageLoader.Load();

        //temporary
        startDialogue(SceneManager.GetActiveScene().name);
    }

    public void Update()
    {

    }

    /*
        starts a new dialogue given a frame id
    */
    private void startDialogue(string id)
    {
        currentFrame = frameLoader.getFrame(id);
        switchToDialogue();
        Debug.Log("starting dialogue");
        dialogueBox.GetComponent<DialogueBox>().updateBoxContent(currentFrame.name, currentFrame.lines);
        updateSprite();
    }

    /*
    */
    public void advanceFrame(string choice)
    {
        string nextId = currentFrame.choiceMappings[choice];
        currentFrame = frameLoader.getFrame(nextId);
        if (currentFrame.isChoiceFrame())
        {
            switchToChoices();
            // Debug.Log(choiceButtons);
            // Debug.Log(choiceButtons.GetComponent<DialogueChoiceButtons>());
            choiceButtons.GetComponent<DialogueChoiceButtons>().loadButtons(currentFrame.choices);
        }
        else
        {
            switchToDialogue();
            dialogueBox.GetComponent<DialogueBox>().updateBoxContent(currentFrame.name, currentFrame.lines);
        }
        updateSprite();
    }


    private void updateSprite()
    {
        portrait.sprite = imageLoader.getSprite(currentFrame.name + "_" + currentFrame.portrait);
    }

    public void switchToChoices()
    {
        dialogueBox.SetActive(false);
        choiceButtons.SetActive(true);
    }

    public void switchToDialogue()
    {
        dialogueBox.SetActive(true);
        choiceButtons.SetActive(false);
    }


}
