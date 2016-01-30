using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

    public bool isVert;
    private bool lockPos;
    void OnTriggerEnter2D(Collider2D coll)
    {
        Camera.main.GetComponent<CameraMovement>().MoveToAdjacent(FindBG().position);
    }

    Transform FindBG()
    {

        GameObject[] allBg = GameObject.FindGameObjectsWithTag("Bg");
        Transform bgTransform = allBg[0].transform;

        foreach (GameObject bg in allBg)
        {
            //Debug.Log(bg.name + " " + Vector3.Distance(transform.position, bg.transform.position));
            if (Vector3.Distance(transform.position, bgTransform.position) > Vector3.Distance(transform.position, bg.transform.position))
            {
                
                if (isVert)
                {
                    lockPos = bg.transform.position.x == 0;
                }
                else
                {
                    lockPos = bg.transform.position.y == 0;
                }

                if (lockPos && !GetComponent<Collider2D>().bounds.Intersects(bg.GetComponent<SpriteRenderer>().bounds))
                {
                    bgTransform = bg.transform;
                }

            }

        }

        Debug.Log(bgTransform.gameObject.name);
        return bgTransform;
    }
}