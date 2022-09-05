using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MatchPicture.Tile;
namespace MatchPicture.Currency
{
    public class CurrencyScript : MonoBehaviour
    {
        public static UnityAction<int> UpdateGold;

        public CurrencyScript instance;

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
        private void Start()
        {
            TileGroup.TilesCleared += OnAddGold;
        }
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
            UpdateGold?.Invoke(goldAmt);
        }
    }
}
