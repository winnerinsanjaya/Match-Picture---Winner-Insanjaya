using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchPicture.Theme;

namespace MatchPicture.Tile
{
    public class TileTheme : MonoBehaviour
    {

        private TileGroup tilegroup;

        private int _count = 2;

        private Sprite spriteToAdd;
        // Start is called before the first frame update
        void Start()
        {
            tilegroup = GetComponent<TileGroup>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GiveSprite(int width, int height)
        {

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Debug.Log(tilegroup._tileGrid[x, y].name);
                    _count -= 1;

                    if(_count == 1)
                    {
                        GameObject themelistObj = GameObject.Find("ThemeList");
                        ThemeList themelist = themelistObj.GetComponent<ThemeList>();

                        int themeIndex = PlayerPrefs.GetInt("selectedtheme");
                        int spriteAmt = themelist.themestruct.themes[themeIndex].themeSprites.Count;
                        spriteToAdd = themelist.themestruct.themes[themeIndex].themeSprites[Random.Range(0, spriteAmt)];

                       // tilegroup = GetComponent<TileGroup>();
                        
                        Debug.Log(tilegroup._tileGrid[x, y].name);
                       // tilegroup._tileGrid[x, y].name = 1.ToString();
                        //TileObject tileobject = tiles.GetComponent<TileObject>();
                    }

                    if (_count <= 0)
                    {
                        Debug.Log(y);
                        // tilegroup._tileGrid[x, y].name = 2.ToString();
                        //TileObject tileobject = tiles.GetComponent<TileObject>();
                        _count = 2;
                    }
                    //tileobject.AddThemeSprite();
                }
            }
        }
    }
}
