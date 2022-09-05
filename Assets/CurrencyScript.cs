using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPicture.Currency
{
    public class CurrencyScript : MonoBehaviour
    {
        private void OnAddGold(int goldAmt)
        {
            SetGold(goldAmt);
        }

        private void OnDecreaseGold(int goldAmt)
        {
            SetGold(goldAmt);
        }

        private void SetGold(int goldAmt)
        {
            PlayerPrefs.SetInt("gold", goldAmt);
        }
    }
}
