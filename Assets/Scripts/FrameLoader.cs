using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class FrameLoader
{
    private Dictionary<string, Frame> frames;
    private readonly string[] names = { "xavier_1", "rena_1", "neo_1" };
    public void Load()
    {
        frames = new Dictionary<string, Frame>();
        deserializeFrames();
    }

    private void deserializeFrames()
    {
        foreach (string filename in names)
        {
            FrameList deserializedFrames = JsonUtility.FromJson<FrameList>(Resources.Load<TextAsset>(filename).text);
            foreach (Frame frame in deserializedFrames.frameList)
            {
                frame.choiceMappings = new Dictionary<string, string>();
                for (int i = 0; i < frame.choices.Length; ++i)
                {
                    frame.choiceMappings[frame.choices[i]] = frame.paths[i];
                }
                frames[frame.id] = frame;
            }
        }
    }

    private string getFileText(string path)
    {
        string filename = Path.GetFileNameWithoutExtension(path);
        TextAsset json = Resources.Load<TextAsset>(filename);
        return json.text;
    }

    public Frame getFrame(string id)
    {
        return frames[id];
    }


}
