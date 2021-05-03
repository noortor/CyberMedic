using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class DialogueChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameObject dialogueChoiceButtons;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueChoiceButtons = GameObject.Find("Choice Buttons");
        GetComponent<Button>().onClick.AddListener(makeChoice);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<SpriteRenderer>().color = new Color(0.484375f, 0.70703125f, 0.64453125f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void makeChoice()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        dialogueChoiceButtons.GetComponent<DialogueChoiceButtons>().setChoiceMade(getChoiceText(), true);
    }


    public void setChoiceText(string choice)
    {
        gameObject.GetComponentInChildren<TextMeshPro>().text = choice;
    }

    public string getChoiceText()
    {
        return gameObject.GetComponentInChildren<TextMeshPro>().text;
    }

    private void hi()
    {
        Debug.Log('hi');
    }

}
