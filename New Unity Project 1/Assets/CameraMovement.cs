using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private GameObject[] gates;

    void Start()
    {
        gates = GameObject.FindGameObjectsWithTag("Gate");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            EnableGates();
    }
    public void MoveToAdjacent(Vector2 newCamPos)
    {
        DisableGates();
        transform.position = new Vector3(newCamPos.x, newCamPos.y, -10);
        
    }

    public void DisableGates()
    {
        foreach (GameObject g in gates)
        {
            g.SetActive(false);
        }
    }

    public void EnableGates()
    {
        foreach (GameObject g in gates)
        {
            g.SetActive(true);
        }
    }

}
