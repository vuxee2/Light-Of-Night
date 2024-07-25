using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;

    List<Vector2> points;

    public void UpdateLine(Vector2 position)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        if(Vector2.Distance(points.Last(), position) > .05f)
        {
            SetPoint(position);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }

    void Start()
    {
        InvokeRepeating("_Destroy", 3f, 0.01f);
    }

    private void _Destroy()
    {
        if(lineRenderer.positionCount > 0)
        {
            lineRenderer.positionCount--;
        }
        else
        {
            CancelInvoke();
            Destroy(gameObject);
        }
    }
}
