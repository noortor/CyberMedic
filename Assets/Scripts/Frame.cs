using System.Collections.Generic;

[System.Serializable]
public class Frame
{
    public string id;
    public string name;
    public string lines;
    public string[] choices;
    public string[] paths;
    public string portrait;
    public Dictionary<string, string> choiceMappings;

    public bool isChoiceFrame()
    {
        return choices.Length != 1;
    }
    /* public bool isMetaFrame;
    public string[] frames;
    public string[] conditions;
    public string setFlag; */
}
