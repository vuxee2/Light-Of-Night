using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject lineParent;

    Line activeLine;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Srca.health > 0)
        {
            GameObject newLine = Instantiate(linePrefab, lineParent.transform.position, Quaternion.identity);
            activeLine = newLine.GetComponent<Line>();

            newLine.transform.parent = lineParent.transform;
        }

        if(Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            //mousePos.x = Mathf.Clamp(mousePos.x, -4.9f, 4.9f);
            //mousePos.y = Mathf.Clamp(mousePos.y, -4.9f, 4.9f);

            activeLine.UpdateLine(mousePos);
        }
    }
}
