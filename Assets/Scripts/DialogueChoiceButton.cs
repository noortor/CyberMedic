using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class DialogueChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer in");
        //this.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer out");
        //this.GetComponent<SpriteRenderer>().color = Color.green;
    }


    public void makeChoice()
    {

    }
}
