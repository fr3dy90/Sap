using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDetails
{
    public StageDetails (string nameParent, string nameChild, string nameLayer, Texture2D map, Sprite[] sprites, Color[] colors, float offsetX, float offsetY, float order, Vector3 scale, bool down,int h, int count)
    {
        GameObject go = new GameObject(nameParent);
        go.isStatic = true;
        for (int i = 0; i <map.width ; i++)
        {
            for (int j = 0; j < map.height; j++)
            {
                Color pixelColor = map.GetPixel(i, j);
                if(pixelColor.a != 0)
                {
                    for (int k = 0; k < colors.Length; k++)
                    {
                        if (colors[k].Equals(pixelColor))
                        {
                            GameObject asset = new GameObject(nameChild + i.ToString() + "_" + j.ToString());
                            asset.transform.parent = go.transform;
                            asset.transform.position = ManagerTiles.nGrid[i, j].transform.position + new Vector3(offsetX, offsetY, 0);
                            SpriteRenderer sr = asset.AddComponent<SpriteRenderer>();
                            sr.sprite = sprites[k];
                            sr.sortingLayerName = nameLayer;
                            sr.sortingOrder = (int)(asset.transform.position.y * order);
                            asset.isStatic = true;
                            asset.transform.localScale = scale;
                            if (down)
                            {
                                for (int l = 1; l < count; l++)
                                {
                                    if ((asset.transform.position + new Vector3(0, l * h, 0)).y > -16f)
                                    {
                                        GameObject asset_c = new GameObject(nameChild + i.ToString() + "_" + j.ToString() + "_Child");
                                        SpriteRenderer sr_c = asset_c.AddComponent<SpriteRenderer>();
                                        sr_c.sortingLayerName = sr.sortingLayerName;
                                        sr_c.sortingOrder = sr.sortingOrder;
                                        sr_c.sprite = sprites[k];
                                        asset_c.transform.position = asset.transform.position + new Vector3(0, l * h, 0);
                                        asset_c.transform.parent = asset.transform;
                                        asset_c.isStatic = true;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
