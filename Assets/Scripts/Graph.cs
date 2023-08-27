using System;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;

    [SerializeField, Range(10, 100)] private int resolution = 10;

    private Transform[] points;

    void Awake()
    {
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i] = Instantiate(pointPrefab, transform, false);
            float x = (i + 0.5f) * step - 1f;
            float y = x * x * x;
            point.localPosition = new Vector3(x, y);
            point.localScale = scale;
        }
    }

    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin((position.x + time));
            point.localPosition = position;
        }
    }
}