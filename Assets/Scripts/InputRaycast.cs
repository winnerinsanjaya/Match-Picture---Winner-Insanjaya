using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using MatchPicture.Tile;


namespace MatchPicture.InputManager
{
    public class InputRaycast : MonoBehaviour
    {
        private TileGroup tilegroup;

        // Start is called before the first frame update
        void Start()
        {
            tilegroup = GetComponent<TileGroup>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);


                if (hit.collider != null)
                {
                    if(hit.collider.gameObject.tag == "grid")
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        GameObject obj = hit.collider.gameObject;

                        TileObject tileobj = obj.GetComponent<TileObject>();
                        tileobj.StartCount();
                    }
                }
            }
        }
    }
}
