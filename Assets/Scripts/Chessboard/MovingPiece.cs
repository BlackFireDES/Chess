using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPiece : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera1;
    [SerializeField] private Camera _playerCamera2;
    [SerializeField] private List<Figure> _figures;
    [SerializeField] private Board _board;
    [SerializeField] private Pool _poolOfWhites;
    [SerializeField] private Pool _poolOfBlacks;

    private int _playersTurn;
    private Camera _currentCamera;
    private Figure _selectedFigure;
    private int _length = 8;

    private void Start()
    {
        _playersTurn = 1;
        _currentCamera = _playerCamera1;
    }

    private void OnEnable()
    {
        for (int i = 0; i < _figures.Count; i++)
        {
            _figures[i].SelectedFigureEvent += MovePiece;
            _figures[i].ToBeatFigureEvent += MovePieceToPool;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _figures.Count; i++)
        {
            _figures[i].SelectedFigureEvent -= MovePiece;
            _figures[i].ToBeatFigureEvent -= MovePieceToPool;
        }
    }

    private void Update()
    {
        Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cell cell))
                {
                    Debug.Log("Попал в клетку");
                    if (_selectedFigure != null)
                    {
                        _selectedFigure.Moove(cell);
                        _selectedFigure = null;
                    }
                }
            }
        }
    }

    private void MovePiece(Figure figure)
    {
        Debug.Log("Попал в фигуру");
        figure.ProjectMoovement(_length, _board);
        if (_selectedFigure != null)
        {
            if (figure.Side != _selectedFigure.Side)
            {
                _selectedFigure.Moove(figure.CurrentCell);
                _selectedFigure = null;
            }
            else
            {
                _selectedFigure = null;
            }
        }
        else
        {
            _selectedFigure = figure;
        }
    }

    private void MovePieceToPool(Figure figure)
    {
        if (_playersTurn == 1)
        {
            if (figure.Side == "Black")
                _poolOfBlacks.ToPull(figure);
        }
        else if (_playersTurn == -1)
        {
            if (figure.Side == "White")
                _poolOfWhites.ToPull(figure);
        }
    }

    private void ChangeTurn()
    {
        StartCoroutine(Pause());
       
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        _currentCamera.enabled = false;

        if (_playersTurn == 1)
        {
            _playersTurn = -1;
            _currentCamera = _playerCamera2;
        }
        else if (_playersTurn == -1)
        {
            _playersTurn = 1;
            _currentCamera = _playerCamera1;
        }

        _currentCamera.enabled = true;
    }
}
