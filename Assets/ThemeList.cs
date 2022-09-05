using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Theme
{
    public class ThemeList : MonoBehaviour
    {
        public ThemeList instance;

        public ThemeStruct themestruct;

        // Start is called before the first frame update
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
            SetThemeCount();
        }

        private void SetThemeCount()
        {
            PlayerPrefs.SetInt("themecount", themestruct.themes.Count);
            Debug.Log(PlayerPrefs.GetInt("themecount"));
        }
    }
}
