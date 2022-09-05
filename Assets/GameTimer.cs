using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MatchPicture.Tile;
using UnityEngine.UI;

namespace MatchPicture.Timer
{
    public class GameTimer : MonoBehaviour
    {
        public static UnityAction TimeOver;

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
                    TimeOver?.Invoke();
                }
            }
            timerText.text = "Timer : " + gameTime;
            
        }

        private void StartTimer()
        {
            timerStart = true;
        }
    }
}
