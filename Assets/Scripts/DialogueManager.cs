using System.Collections;using System.Collections.Generic;using UnityEngine.SceneManagement;using TMPro;using UnityEngine;public class DialogueManager : MonoBehaviour{    private FrameLoader frameLoader;    private Frame currentFrame;    private ImageLoader imageLoader;    private static DialogueManager _instance;    private TextMeshPro nameBox;    private TextMeshPro textBox;    [SerializeField]    private SpriteRenderer portrait;    public static DialogueManager Instance { get { return _instance; } }    private void Awake()    {        // Ensure singleton behavior        if (_instance != null && _instance != this)        {            Destroy(this.gameObject);        }        else        {            _instance = this;        }        frameLoader = new FrameLoader();        imageLoader = new ImageLoader();        frameLoader.Load();        imageLoader.Load();        startDialogue(SceneManager.GetActiveScene().name);    }    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentFrame.choices.Length == 1)
        {
            advanceFrame();
        }
    }    private void triggerDialogue(string characterName)    {    }    private void startDialogue(string id)    {        currentFrame = frameLoader.getFrame(id);
        textBox = gameObject.GetComponentsInChildren<TextMeshPro>()[0];        textBox.text = currentFrame.lines;        nameBox = gameObject.GetComponentsInChildren<TextMeshPro>()[1];        nameBox.text = currentFrame.name;        updateSprite();    }    private void advanceFrame()
    {
        updateFrame("default");
        textBox.text = currentFrame.lines;
        nameBox.text = currentFrame.name;
        updateSprite();
    }    private void updateFrame(string path)
    {
        currentFrame = frameLoader.getFrame(currentFrame.choiceMappings[path]);
    }    private void updateSprite()
    {
        portrait.sprite = imageLoader.getSprite(currentFrame.name + "_" + currentFrame.portrait);
    }}