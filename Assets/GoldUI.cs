using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MatchPicture.Currency;

namespace MatchPicture.UI
{
    public class GoldUI : MonoBehaviour
    {
        [SerializeField]
        private Text goldText;

        public GoldUI instance;
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
        }
        void Start()
        {
            if (PlayerPrefs.HasKey("gold") == false)
            {
                PlayerPrefs.SetInt("gold", 0);
            }
                UpdateGold(0);
            CurrencyScript.UpdateGold += UpdateGold;
        }

        private void UpdateGold(int amount)
        {
            
            goldText.text = "GOLD : " + PlayerPrefs.GetInt("gold");
        }
    }
}
