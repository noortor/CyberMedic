using System.Collections;
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
    private TextMeshPro nameBox;
    private TextMeshPro textBox;

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
        textBox = GameObject.Find("Dialogue Text").GetComponent<TextMeshPro>();
        nameBox = GameObject.Find("Name Box").GetComponent<TextMeshPro>();

        frameLoader = new FrameLoader();
        imageLoader = new ImageLoader();
        frameLoader.Load();
        imageLoader.Load();

        //temporary
        startDialogue(SceneManager.GetActiveScene().name);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentFrame.choices.Length == 1)
        {
            advanceFrame();
        }
    }

    /*
        starts a new dialogue given a frame id
    */
    private void startDialogue(string id)
    {
        currentFrame = frameLoader.getFrame(id);
        textBox.text = currentFrame.lines;
        nameBox.text = currentFrame.name;
        updateSprite();
    }

    /*
    */
    private void advanceFrame()
    {
        setNextFrame("default");
        textBox.text = currentFrame.lines;
        nameBox.text = currentFrame.name;
        updateSprite();
    }

    private void setNextFrame(string choice)
    {
        currentFrame = frameLoader.getFrame(currentFrame.choiceMappings[choice]);

    }

    private void updateSprite()
    {
        portrait.sprite = imageLoader.getSprite(currentFrame.name + "_" + currentFrame.portrait);
    }

    private void setDialogueVisibility(bool isVisible)
    {
        dialogueBox.SetActive(isVisible);
    }
}
