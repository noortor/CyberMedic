using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;


public class DialogueLoader : MonoBehaviour
{
    private static DialogueLoader _instance;
    public static DialogueLoader Instance { get { return _instance; } }

    private static Dictionary<string, DialogueFrame> dialogueFrames;
    void Awake()
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

        dialogueFrames = new Dictionary<string, DialogueFrame>();
        populateFramesMap();
    }

    private void populateFramesMap()
    {
        string[] dialogueFilePaths = Directory.GetFiles("./Assets/Dialogue/Resources", "*.json");
        foreach (string filePath in dialogueFilePaths)
        {
            string fileText = getFileText(filePath);
            DialogueFrameList frames = JsonUtility.FromJson<DialogueFrameList>(fileText);
            foreach (DialogueFrame frame in frames.dialogueFrameList)
            {
                frame.choiceMappings = new Dictionary<string, string>();
                for (int i = 0; i < frame.choices.Length; i++)
                {
                    frame.choiceMappings[frame.choices[i]] = frame.paths[i];
                }
                dialogueFrames[frame.id] = frame;
            }

            Debug.Log(dialogueFrames["xavier1_2"].choiceMappings["I've never heard of it."]);
        }
    }

    private string getFileText(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
        return jsonFile.text;
    }


}
