using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Node parent;
    public int x;
    public int y;
    public int g;
    public int h;
    public int f;

    public Node(Node parent, int x, int y, int goalX, int goalY)
    {
        this.parent = parent;
        this.x = x;
        this.y = y;
        h = Mathf.Abs(goalX - this.x) + Mathf.Abs(goalY - this.y);
    }
}
