using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoiceButtons : MonoBehaviour
{
    private GameObject dialogueManager;
    private string choiceMade;
    private List<GameObject> buttons;
    // Start is called before the first frame update
    void Awake()
    {

        choiceMade = "";
        dialogueManager = GameObject.Find("Dialogue Manager");
        buttons = new List<GameObject>();
        for (int i = 0; i < 3; i++)
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
    }

    public void unLoadButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    public void setChoiceMade(string choice, bool changeDisplay)
    {
        choiceMade = choice;
        if (changeDisplay)
        {
            dialogueManager.GetComponent<DialogueManager>().advanceDisplay();
        }
    }

    public string getChoiceMade()
    {
        return choiceMade;
    }
}
