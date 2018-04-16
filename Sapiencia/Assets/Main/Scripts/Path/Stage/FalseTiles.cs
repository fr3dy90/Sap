using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTiles : MonoBehaviour
{

    public Texture2D map;

    public Sprite sprites;
    public Color colors;
    public float offset_x;
    public float offset_y;
    public float order;

    float offsetH;



    public GameObject grid()
    {
        GameObject go = new GameObject("FalseGrid");
        go.isStatic = true;
        for (int i = 0; i < map.width; i++)
        {
            for (int j = 0; j < map.height; j++)
            {
                Color pixelColor = map.GetPixel(i, j);
                if (pixelColor.a != 0)
                {
                    GameObject tile = new GameObject(i.ToString() + "_" + j.ToString());
                    tile.transform.parent = go.transform;
                    SpriteRenderer sr = tile.AddComponent<SpriteRenderer>();
                    if (colors.Equals(pixelColor))
                    {
                        sr.sprite = sprites;
                        offsetH = 4;
                    }
                    tile.transform.position = new Vector2((i * offset_x) + (j * offset_x), ((i * (-offset_y)) + (j * offset_y) + offsetH));
                    sr.sortingLayerName = "Walls";
                    sr.sortingOrder = (int)(tile.transform.position.y * order);
                    tile.isStatic = true;
                }
            }
        }
        return go;
    }

    private void Awake()
    {
        grid();
    }
}