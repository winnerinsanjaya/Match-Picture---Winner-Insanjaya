using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace MatchPicture.Home
{
    public class HomeScript : MonoBehaviour
    {
        public static UnityAction OnHome;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _themeButton;

        private void Start()
        {
            OnHome?.Invoke();
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _themeButton.onClick.AddListener(OnThemeButtonClick);

            SetTheme();
        }

        private void OnPlayButtonClick()
        {
            SceneManager.LoadScene("Gameplay");
        }

        private void OnThemeButtonClick()
        {
            SceneManager.LoadScene("Theme");
        }

        private void SetTheme()
        {
            if (PlayerPrefs.HasKey("selectedtheme") == false)
            {
                PlayerPrefs.SetInt("selectedtheme", 0);
            }

            Debug.Log("THEME + "+PlayerPrefs.GetInt("selectedtheme"));
        }
    }
}
