using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacement2 : MonoBehaviour
{
    public GameObject ObjToMove;
    public GameObject ObjToPlace;
    public LayerMask mask;
    public float LastPosY;
    public Vector3 mousepos;

    private Renderer rend;
    public Material matGrid, matDefault;
    void Start()
    {
        rend = GameObject.Find("Ground").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousepos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            int Posx = (int)Mathf.Round(hit.point.x);
            int Posz = (int)Mathf.Round(hit.point.z);

            ObjToMove.transform.position = new Vector3(Posx, LastPosY, Posz);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ObjToPlace, ObjToMove.transform.position, Quaternion.identity);

        }
    }

}
