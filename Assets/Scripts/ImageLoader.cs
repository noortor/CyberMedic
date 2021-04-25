using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader
{
    private Dictionary<string, Sprite> sprites;
    public void Load()
    {
        sprites = new Dictionary<string, Sprite>();
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("") as Sprite[];
        foreach (Sprite sprite in loadedSprites)
        {
            sprites[sprite.name] = sprite;
        }
    }

    public Sprite getSprite(string name)
    {
        return sprites[name];
    }
}
