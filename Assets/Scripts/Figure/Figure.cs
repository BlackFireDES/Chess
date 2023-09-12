using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Figure : MonoBehaviour
{
    [SerializeField] private string _side;

    public string Side => _side;
    public delegate void FigureEvent(Figure figure);
    public FigureEvent SelectedFigureEvent;
    public FigureEvent ToBeatFigureEvent;

    protected List<Cell> _avaibleCells;

    public Cell CurrentCell { get; private set;}


    public virtual void Moove(Cell cell) {}
    public virtual void ProjectMoovement(int length, Board board) {}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Cell cell))
        {
            CurrentCell = cell;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Figure figure))
        {
            ToBeatFigureEvent?.Invoke(this);
        }
    }

    private void OnMouseDown()
    {
        SelectedFigureEvent?.Invoke(this);
        Debug.Log("lf");
    }
}
