using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchPicture.Tile;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using MatchPicture.Timer;

namespace MatchPicture.GameFlow
{
    public class GameFlow : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TileGroup.TilesCleared += SetGameOverState;
            GameTimer.TimeOver += SetGameOverState;
        }

       private void SetGameOverState()
        {
            SceneManager.LoadScene("Home");
        }
    }
}
