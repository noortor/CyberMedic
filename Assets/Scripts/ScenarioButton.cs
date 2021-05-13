using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ScenarioButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public readonly Color GREEN = new Color(0.484375f, 0.70703125f, 0.64453125f, 1);
    private Image image;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = GREEN;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.EnterDialogueScene(this.name); 
    }
}
