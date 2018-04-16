using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTiles : MonoBehaviour {

    public Texture2D map;

    public Sprite[] sprites;
    public Color[] colors;
    public float offset_x;
    public float offset_y;

    public static int h;
    public static int w;

    float offsetH;

    public static GameObject[,] nGrid;

    public GameObject grid()
    {
        GameObject go = new GameObject("Grid");
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
                    for (int k = 0; k < colors.Length; k++)
                    {
                        if (colors[k].Equals(pixelColor))
                        {
                            offsetH = 0;
                            switch (k)
                            {
                                case 0:
                                    offsetH = k;
                                    sr.sprite = sprites[0];
                                    break;
                                case 1:
                                    offsetH = k-0.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 2:
                                    offsetH = k-0.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 3:
                                    offsetH = 2;
                                    sr.sprite = sprites[0];
                                    break;
                                case 4:
                                    offsetH = 2.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 5:
                                    offsetH = 3.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 6:
                                    offsetH = 4;
                                    sr.sprite = sprites[0];
                                    break;
                                case 7:
                                    offsetH = 2.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 8:
                                    offsetH = 3.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 9:
                                    offsetH = 4.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 10:
                                    offsetH = 5.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 11:
                                    offsetH = 6.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 12:
                                    offsetH = 7.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 13:
                                    offsetH = 8.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 14:
                                    offsetH = 9.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 15:
                                    offsetH = 4.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 16:
                                    offsetH = 5.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 17:
                                    offsetH = 6.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 18:
                                    offsetH = 7.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 19:
                                    offsetH = 8.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 20:
                                    offsetH = 9.5f;
                                    sr.sprite = sprites[1];
                                    tile.layer = 8;
                                    break;
                                case 21:
                                    offsetH = 6;
                                    sr.sprite = sprites[0];
                                    break;
                                case 22:
                                    offsetH = 10;
                                    sr.sprite = sprites[0];
                                    break;
                                case 23:
                                    offsetH = 10.5f;
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;              
                                case 24:                
                                    offsetH = 11.5f;       
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;              
                                case 25:                
                                    offsetH = 12.5f;       
                                    sr.sprite = sprites[2];
                                    tile.layer = 8;
                                    break;
                                case 26:
                                    offsetH = 13;
                                    sr.sprite = sprites[0];
                                    break;
                                case 27:
                                    offsetH = 7;
                                    sr.sprite = sprites[0];
                                    break;
                                case 28:
                                    offsetH = 5;
                                    sr.sprite = sprites[0];
                                    break;
                            }
                        }
                    }
                    tile.transform.position = new Vector2((i * offset_x) + (j * offset_x), ((i * (-offset_y)) + (j * offset_y) + offsetH));
                    sr.sortingLayerName = "Ground";
                    sr.sortingOrder = i - j;
                    PolygonCollider2D pc = tile.AddComponent<PolygonCollider2D>();
                    pc.isTrigger = true;
                    Rigidbody2D rb = tile.AddComponent<Rigidbody2D>();
                    rb.gravityScale = 0;
                    nGrid[i, j] = tile;
                    tile.isStatic = true;
                }
            }
        }
        return go;
    }

    private void Awake()
    {
        h = map.height;
        w = map.width;
        nGrid = new GameObject[map.width, map.height];
        grid();
    }

    private void Start()
    {
        LobbyDetails ld = FindObjectOfType<LobbyDetails>();
        ld.CreateDetails();
    }
}