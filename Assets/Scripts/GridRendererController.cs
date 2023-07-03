using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GridRendererController : Graphic
{
    [Min(0f)]
    [SerializeField] private float thickness = 10f;

    [Min(1f)]
    [SerializeField] private Vector2Int gridSize = new Vector2Int(1, 1);
    private float width;
    private float height;
    private float cellWidth;
    private float cellHeight;

    protected override void OnPopulateMesh(VertexHelper vertexHelper)
    {
        vertexHelper.Clear();

        width = rectTransform.rect.width;
        height = rectTransform.rect.height;

        cellWidth = width / gridSize.x;
        cellHeight = height / gridSize.y;

        int count = 0;
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                DrawCell(x, y, count, vertexHelper);
                count++;
            }
        }
    }

    private void DrawCell(int x, int y, int index, VertexHelper vertexHelper)
    {
        float xPos = cellWidth * x;
        float yPos = cellHeight * y;

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(xPos, yPos, 0f);
        vertexHelper.AddVert(vertex);

        vertex.position = new Vector3(xPos, yPos + cellHeight, 0f);
        vertexHelper.AddVert(vertex);

        vertex.position = new Vector3(xPos + cellWidth, yPos + cellHeight, 0f);
        vertexHelper.AddVert(vertex);

        vertex.position = new Vector3(xPos + cellWidth, yPos, 0f);
        vertexHelper.AddVert(vertex);

        //vertexHelper.AddTriangle(0, 1, 2);
        //vertexHelper.AddTriangle(2, 3, 0);

        float widthSquare = thickness * thickness;
        float distanceSquare = widthSquare / 2f;
        float distance = Mathf.Sqrt(distanceSquare);

        vertex.position = new Vector3(xPos + distance, yPos + distance, 0f);
        vertexHelper.AddVert(vertex);

        vertex.position = new Vector3(xPos + distance, yPos + (cellHeight - distance), 0f);
        vertexHelper.AddVert(vertex);

        vertex.position = new Vector3(xPos + (cellWidth - distance), yPos + (cellHeight - distance), 0f);
        vertexHelper.AddVert(vertex);

        vertex.position = new Vector3(xPos + (cellWidth - distance), yPos + distance, 0f);
        vertexHelper.AddVert(vertex);

        int offset = index * 8;

        // Left Edge
        vertexHelper.AddTriangle(offset + 0, offset + 1, offset + 5);
        vertexHelper.AddTriangle(offset + 5, offset + 4, offset + 0);

        //Top Edge
        vertexHelper.AddTriangle(offset + 1, offset + 2, offset + 6);
        vertexHelper.AddTriangle(offset + 6, offset + 5, offset + 1);

        //Right Edge
        vertexHelper.AddTriangle(offset + 2, offset + 3, offset + 7);
        vertexHelper.AddTriangle(offset + 7, offset + 6, offset + 2);

        //Bottom Edge
        vertexHelper.AddTriangle(offset + 3, offset + 0, offset + 4);
        vertexHelper.AddTriangle(offset + 4, offset + 7, offset + 3);

    }
}
