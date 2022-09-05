using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MatchPicture.Theme;
using UnityEngine.Events;

namespace MatchPicture.Tile
{
    public class TileGroup : MonoBehaviour
    {

        [SerializeField] private GameObject _tileCell;

        public static UnityAction ClickedTilesMatch;

        public static UnityAction ReadyToPlay;


        public static UnityAction TilesCleared;

        private int itemFinish;

        private int itemCount;


        public GameObject[,] _tileGrid;

        [SerializeField] private int _xSize;
        [SerializeField] private int _ySize;

        [SerializeField]
        private float _space = 3.5f;

        [SerializeField]
        private Transform _tileParent;

        [SerializeField]
        private TileList tileslist;

        private bool isSecond;

        private int _count = 2;

        private Sprite spriteToAdd;
        // Start is called before the first frame update
        void Start()
        {
            GenerateGrid(_xSize, _ySize);
            TileObject.TileClicked += AddToTile;

        }

        private void GenerateGrid(int width, int height)
        {
            _tileGrid = new GameObject[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _tileGrid[x, y] = Instantiate(_tileCell, new Vector3(x * _space, y * _space, 0), Quaternion.identity, _tileParent);
                    _tileGrid[x, y].gameObject.name = "Tile" + x + y;
                    ChangeTheme(_tileGrid[x, y]);
                }
            }

            SetCenterGridContainer(width, height);
            ReadyToPlay?.Invoke();
            itemCount = _tileGrid.Length;
            SwitchPos();
        }

        private void SetCenterGridContainer(int xSize, int ySize)
        {
            int xAmt = xSize - 1;
            int yAmt = ySize - 1;

            float posX = -_space * xAmt / 2;
            float posY = -_space * yAmt / 2;

            _tileParent.transform.position = new Vector2(posX, posY);
        }

         public void AddToTile(GameObject obj)
        {
            
            if (!isSecond)
            {
                tileslist.tile1 = obj;
                isSecond = true;
                return;
            }
            if (isSecond)
            {
                if(tileslist.tile1 != obj)
                {
                    tileslist.tile2 = obj;
                    TryMatchClickedTiles();
                    isSecond = false;
                }
            }
        }

        private void TryMatchClickedTiles()
        {
            if(tileslist.tile1.name == tileslist.tile2.name)
            {
                ClearTile();
                ClickedTilesMatch?.Invoke();
                AddItemFinish();
            }
            else
            {
                tileslist.tile1 = null;
                tileslist.tile2 = null;
            }
        }

        private void ClearTile()
        {
            Destroy(tileslist.tile1);
            Destroy(tileslist.tile2);
        }

        private void ChangeTheme(GameObject tileObj)
        {
            if(_count == 2)
            {
                GameObject themelistObj = GameObject.Find("ThemeList");
                ThemeList themelist = themelistObj.GetComponent<ThemeList>();
                int themeIndex = PlayerPrefs.GetInt("selectedtheme");
                int spriteAmt = themelist.themestruct.themes[themeIndex].themeSprites.Count;
                spriteToAdd = themelist.themestruct.themes[themeIndex].themeSprites[Random.Range(0, spriteAmt)];

                TileObject tileobject = tileObj.GetComponent<TileObject>();
                tileobject.AddThemeSprite(spriteToAdd);
                tileObj.name = spriteToAdd.name;

                _count -= 1;
                return;
            }

            if (_count == 1)
            {

                TileObject tileobject = tileObj.GetComponent<TileObject>();
                tileobject.AddThemeSprite(spriteToAdd);
                tileObj.name = spriteToAdd.name;

                _count = 2;
            }
        }
        private void AddItemFinish()
        {
            itemFinish += 2;
            Debug.Log(itemFinish.ToString());
            if (itemFinish >= itemCount)
            {
                TilesCleared?.Invoke();
            }
        }
        

        private void SwitchPos()
        {
            for (int y = 0; y < _ySize; y++)
            {
                for (int x = 0; x < _xSize; x++)
                {
                    int ranX = Random.Range(0, _xSize);
                    int ranY = Random.Range(0, _ySize);
                    Vector3 puzPos, ranPos;
                    puzPos = _tileGrid[x, y].transform.position;
                    ranPos = _tileGrid[ranX, ranY].transform.position;

                    _tileGrid[x, y].transform.position = ranPos;
                    _tileGrid[ranX, ranY].transform.position = puzPos;
                }
            }
        }
    }
}
