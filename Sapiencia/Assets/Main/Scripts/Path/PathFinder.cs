using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    public Node[,] nMatrix;
    public List<Node> open;
    public List<Node> close;
    public List<Node> path;
    public int goalX;
    public int goalY;

    public List<Node> Search(int startX, int startY, int goalX, int goalY, int width, int height)
    {
        path = new List<Node>();
        if (startX != goalX || startY != goalY)
        {
            nMatrix = new Node[width, height];
            open = new List<Node>();
            close = new List<Node>();
            this.goalX = goalX;
            this.goalY = goalY;
            AddNodeClose(new Node(null, startX, startY, goalX, goalY));
        }
        return path;
    }

    public void AddNodeClose(Node node)
    {
        close.Add(node);
        nMatrix[node.x, node.y] = node;
        SearchNeighborhood(node);
    }

    public void SearchNeighborhood(Node node)
    {
        Node finalNode = null;
        if(node.x > 0)
        {
            finalNode = AbstractNeighborhood(node, node.x - 1, node.y);
        }
        
        if(finalNode == null && node.x < nMatrix.GetLength(0) - 1)
        {
            finalNode = AbstractNeighborhood(node, node.x + 1, node.y);
        }

        if (finalNode == null && node.y > 0)
        {
            finalNode = AbstractNeighborhood(node, node.x, node.y - 1);
        }

        if (finalNode == null && node.y < nMatrix.GetLength(1) - 1)
        {
            finalNode = AbstractNeighborhood(node, node.x, node.y + 1);
        }

        if (finalNode != null)
        {
            Node insert = finalNode;
            do
            {
                path.Insert(0, insert);
                insert = insert.parent;

            }
            while (insert.parent != null);
        }
        else
        {
            int minDist = 0;
            int index = 0;
            for (int i = 0; i < open.Count; i++)
            {
                if (i == 0)
                {
                    minDist = open[i].h;
                    index = 0;
                }
                else
                {
                    if (minDist > open[i].h)
                    {
                        minDist = open[i].h;
                        index = i;
                    }
                }
            }

            Node n = open[index];
            open.RemoveAt(index);
            AddNodeClose(n);
        }
    }

    Node AbstractNeighborhood(Node node ,int x, int y)
    {
        if(ManagerTiles.nGrid[x, y] == null)
        {
            return null;
        }
        if (nMatrix[x, y] == null)
        {
            nMatrix[x,y] = new Node(node, x, y, goalX, goalY);
            if(x == goalX && y == goalY)
            {
                return nMatrix[x, y];
            }
            open.Add(nMatrix[x, y]);
        }
        else
        {

        }
        return null;
    }
}
