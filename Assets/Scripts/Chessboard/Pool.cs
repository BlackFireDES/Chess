using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private Figure[] _figures;

    private void Start()
    {
        _points = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            _points[i] = transform.GetChild(i);
        _figures = new Figure[_points.Length];
    }

    public void ToPull(Figure figure)
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            if (_figures[i] == null)
            {
                _figures[i] = figure;
                figure.transform.position = _points[i].transform.position;
                break;
            }
        }
    }
}
