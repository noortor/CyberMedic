using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoiceButtons : MonoBehaviour
{
    private List<GameObject> buttons;
    // Start is called before the first frame update
    void Awake()
    {
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
}
