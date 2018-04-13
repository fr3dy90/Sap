using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_Walls : MonoBehaviour
{
    public bool isParent;

    private void Awake()
    {
        if (isParent)
        {
            GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.x - (int)transform.position.y;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = transform.parent.GetComponent<SpriteRenderer>().sortingOrder;
        }
    }
}
