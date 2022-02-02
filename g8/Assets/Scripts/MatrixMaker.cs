using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMaker : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public GameObject placeholderPrefab;

    public float minRowHeight = 2;
    public float minColWidth = 2;

    // bool exists to prevent placeholders to be deleted after operation ends
    public bool isBuildingGrid;

    public List<List<Vector3>> CreateMatrix(Vector3 initialPoint, Vector3 finalPoint)
    {

        // (1, -1, 10) (-20, 20, 0)
        // (-20, -1, 0)

        Vector3 minPoint = Vector3.Min(initialPoint, finalPoint);
        Vector3 maxPoint = Vector3.Max(initialPoint, finalPoint);


        List<List<Vector3>> Matrix = new List<List<Vector3>>();

        float width = maxPoint.z - minPoint.z;
        float height = maxPoint.y - minPoint.y;

        int numRows = Mathf.FloorToInt(height / minRowHeight);
        int numCols = Mathf.FloorToInt(width / minRowHeight);

        for (int i = 0; i < numRows; i++)
        {
            List<Vector3> row = new List<Vector3>();
            for (int j = 0; j < numCols; j++)
            {
                row.Add(
                    new Vector3(
                        initialPoint.x,
                        minPoint.y + height / numRows * i + height / numRows * 0.5f,
                        minPoint.z + width / numCols * j + width / numCols * 0.5f
                    ));
            }
            Matrix.Add(row);
        }

        return Matrix;
    }

    List<GameObject> markers = new List<GameObject>();

    public void VisualizeMatrix(List<List<Vector3>> matrix)
    {
        foreach (var obj in markers)
            Destroy(obj);

        for (int i = 0; i < matrix.Count; i++)
        {
            var row = matrix[i];
            for (int j = 0; j < row.Count; j++)
            {
                Vector3 point = matrix[i][j];

                GameObject marker = Instantiate(placeholderPrefab);
                markers.Add(marker);
                marker.transform.position = point;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isBuildingGrid){
            var Matrix = CreateMatrix(pointA.position, pointB.position);
            /*Debug.Log(Matrix.Count);
            if (Matrix.Count > 0)
            Debug.Log(Matrix[0].Count);*/
            VisualizeMatrix(Matrix);
        }
    }
}
