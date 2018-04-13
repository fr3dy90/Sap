using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int pX;
    public int pY;
    public int gX;
    public int gY;

    public PathFinder p;
    public List<Node> path;

    public float speed;
    public float accuracy;

    public float radius;
    public Vector3 offset;
    public Collider2D[] hits;

    Transform target;
    bool canWalk;
    bool isStairs;
    bool isFront;
    public LayerMask collsionLayer;
    Vector2 dir;

    int wayPointIndex;

    public GameObject[] characterAnimation;

    private void Start()
    {
        canWalk = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerSearch();
        }
        Walk();
    }

    private void PlayerSearch()
    {
        canWalk = false;
        hits = Physics2D.OverlapCircleAll(transform.position + offset, radius);
        isStairs = (Physics2D.OverlapCircle(transform.position + offset, radius, collsionLayer));
        float dis = 0;
        int index = 0;
        for (int i = 0; i < hits.Length; i++)
        {
            if (i == 0)
            {
                dis = Vector2.Distance(hits[i].transform.position, transform.position);
            }
            else
            {
                if(dis > Vector2.Distance(hits[i].transform.position, transform.position))
                {
                    dis = Vector2.Distance(hits[i].transform.position, transform.position);
                    index = i;
                }
            }
        }

        string[] name = hits[index].name.Split('_');
         pX = System.Int32.Parse(name[0]);
         pY = System.Int32.Parse(name[1]);

        RaycastHit2D hit2d = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit2d)
        {

            string[] nameGoal = hit2d.transform.name.Split('_');
            gX = System.Int32.Parse(nameGoal[0]);
            gY = System.Int32.Parse(nameGoal[1]);
        }

        p = new PathFinder();
        path = p.Search(pX, pY, gX, gY, ManagerTiles.w, ManagerTiles.h);
        target = ManagerTiles.nGrid[path[0].x, path[0].y].transform;
        wayPointIndex = 0;
        canWalk = true;
    }

    public void Walk()
    {
        isStairs = (Physics2D.OverlapCircle(transform.position + offset, radius, collsionLayer));
        if (target != null)
        {
            dir = target.position - transform.position;
        }

        if (dir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (dir.y > 0)
        {
            isFront = false;
        }
        else
        {
            isFront = true;
        }

        if (canWalk)
        {
            if (Vector3.Distance(target.position, transform.position) < accuracy)
            {
                GetWayPointIndex();
            }
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            if (isFront)
            {
                if (isStairs)
                {
                    SetCharacter(2);
                    //Aqui detecta que esta caminando sobre las escalas.
                }
                else
                {
                    SetCharacter(1);
                }
            }
            else
            {
                if (isStairs)
                {
                    SetCharacter(5);
                    //Aqui detecta que esta caminando sobre las escalas.
                }
                else
                {
                    SetCharacter(4);
                }
            }
        }
        else
        {
            if (isFront)
            {
                if (isStairs)
                {
                    SetCharacter(6);
                }
                else
                {
                    SetCharacter(0);
                }
            }
            else
            {
                if (isStairs)
                {
                    SetCharacter(7);
                }
                else
                {
                    SetCharacter(3);
                }
            }
        }
    }

    void GetWayPointIndex()
    {
        wayPointIndex++;
        if(wayPointIndex == path.Count)
        {
            canWalk = false;
            return;
        }
        target = ManagerTiles.nGrid[path[wayPointIndex].x, path[wayPointIndex].y].transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position+offset, radius);
    }

    public void SetCharacter(int index)
    {
        for (int i = 0; i < characterAnimation.Length; i++)
        {
            characterAnimation[i].SetActive(false);
        }
        characterAnimation[index].SetActive(true);
    }
}
