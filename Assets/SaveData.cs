using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchPicture.Currency;

namespace MatchPicture.SaveData
{
    public class SaveData : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            CurrencyScript.UpdateGold += SaveGold;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SaveGold(int amount)
        {
            int add = PlayerPrefs.GetInt("gold");
            add += amount;
            PlayerPrefs.SetInt("gold", add);
        }
    }
}
