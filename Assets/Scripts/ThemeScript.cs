using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MatchPicture.Theme
{
    public class ThemeScript : MonoBehaviour
    {
        [SerializeField]
        private GameObject _themeButtonFabs;

        [SerializeField]
        private Transform _buttonParent;

        private ThemeList themelist;

        [SerializeField]
        private List<Button> _buyThemeButton;

        // Start is called before the first frame update
        void Start()
        {
            CreateThemeButton();
            GetThemeList();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void CreateThemeButton()
        {
            int themeCount = PlayerPrefs.GetInt("themecount");

            for(int i = 0; i < themeCount; i++)
            {
                GameObject themeBtn = Instantiate(_themeButtonFabs, new Vector3(0, 0, 0), Quaternion.identity, _buttonParent);
                
                Text btnText = themeBtn.GetComponentInChildren<Text>();

                GameObject themelistObj = GameObject.Find("ThemeList");
                themelist = themelistObj.GetComponent<ThemeList>();
                btnText.text = themelist.themestruct.themes[i].themeName;
                int price = (themelist.themestruct.themes[i].themePrice);
                int index = themelist.themestruct.themes.IndexOf(themelist.themestruct.themes[i]);

                Button buyBtn = themeBtn.GetComponent<Button>();
                _buyThemeButton.Add(buyBtn);
                buyBtn.onClick.AddListener(delegate {
                    OnBuyTheme(price, index);
                });
               // themeBtn.GetComponentInChildren<Text>().text = themelist.themestruct.themes[i].themeName;
            }
        }

        private void GetThemeList()
        {
            GameObject themelistObj = GameObject.Find("ThemeList");
            themelist = themelistObj.GetComponent<ThemeList>();

            Debug.Log(themelist.themestruct.themes.Count);
        }

        private void OnBuyTheme(int price, int i)
        {
            PlayerPrefs.SetInt("selectedtheme", i);
            SceneManager.LoadScene("Home");
            Debug.Log(price.ToString());
        }
    }
}
