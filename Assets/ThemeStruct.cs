using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Theme
{
    [System.Serializable]
    public class ThemeStruct
    {
        public List<ThemeSprite> themes;
    }

    [System.Serializable]
    public class ThemeSprite
    {
        public List<Sprite> themeSprites;
        public string themeName;
        public int themePrice;
    }
}