using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MatchPicture.Tile
{
    public class TileObject : MonoBehaviour
    {
        public static UnityAction<GameObject> TileClicked;

        [SerializeField]
        private Sprite defaultSprite;
        [SerializeField]
        private Sprite themeSprite;

        [SerializeField]
        private float timeCounter;
        private float defaultTime;

        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private bool isTimer;

        private void Start()
        {
            defaultTime = timeCounter;
            defaultSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (isTimer)
            {
                timeCounter -= Time.deltaTime;

                if(timeCounter > 0)
                {
                    return;
                }

                isTimer = false;
                spriteRenderer.sprite = defaultSprite;
                timeCounter = defaultTime;
            }
        }

        public void AddThemeSprite(Sprite sprite)
        {
            themeSprite = sprite;
        }

        public void StartCount()
        {
            TileClicked?.Invoke(gameObject);
            spriteRenderer.sprite = themeSprite;
            isTimer = true;
        }
    }
}