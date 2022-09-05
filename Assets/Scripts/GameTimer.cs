using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MatchPicture.Tile;
using UnityEngine.UI;
using System;

namespace MatchPicture.Timer
{
    public class GameTimer : MonoBehaviour
    {
        public static UnityAction<int> TimeOver;

        [SerializeField]
        private float gameTime;

        private bool timerStart;

        [SerializeField]
        private Text timerText;

        // Start is called before the first frame update
        void Start()
        {
            TileGroup.ReadyToPlay += StartTimer;
        }

        // Update is called once per frame
        void Update()
        {
            if (timerStart)
            {
                gameTime -= Time.deltaTime;
                if (gameTime <= 0)
                {
                    TimeOver?.Invoke(0);
                }
            }
            var ts = TimeSpan.FromSeconds(gameTime);
            timerText.text = "Timer : " + string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            
        }

        private void StartTimer()
        {
            timerStart = true;
        }
    }
}
