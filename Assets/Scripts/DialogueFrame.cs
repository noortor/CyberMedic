[System.Serializable]
public class DialogueFrame
{
    public string id;
    public string portrait;
    public string lines;
    public bool isChoice;
    public string[] choiceDestinations;
    public string nextFrame;
    public bool isMetaFrame;
    public string[] frames;
    public string[] conditions;
    public string setFlag;
}
