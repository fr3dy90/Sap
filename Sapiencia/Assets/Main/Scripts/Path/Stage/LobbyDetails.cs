using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyDetails : MonoBehaviour {

    [System.Serializable]
    public class Details
    {
        public string nameParent;
        public string nameChild;
        public string nameLayer;
        public Texture2D map;
        public Sprite[] sprites;
        public Color[] colors;
        public float offsetX;
        public float offsetY;
        public float order;
        public Vector3 scale;
        public bool down;
        public int h;
        public int count;
            
    }
    public Details[] details;

    public void CreateDetails()
    {
        for (int i = 0; i < details.Length; i++)
        {
            StageDetails stage = new StageDetails(details[i].nameParent, details[i].nameChild, details[i].nameLayer, details[i].map, details[i].sprites, details[i].colors, details[i].offsetX, details[i].offsetY, details[i].order, details[i].scale, details[i].down, details[i].h, details[i].count);
        }
    }
}
