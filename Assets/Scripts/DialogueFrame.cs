using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueFrame
{
    public string id;
    public string name;
    public string lines;
    public string[] choices;
    public string[] paths;
    public Dictionary<string, string> choiceMappings;


    /* public bool isMetaFrame;
    public string[] frames;
    public string[] conditions;
    public string setFlag; */
}
