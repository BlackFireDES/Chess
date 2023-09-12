using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _length;
    [SerializeField] private int _width;
    [SerializeField] private Cell _cell;
    [SerializeField] private float _scale;

    public int Length => _length;
    public int Width => _width;

    private Cell[,] _cells;


    private void Start()
    {
        _cells = new Cell[_length, _width];
        for (int i = 0; i < _length; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                _cells[i, j] = Instantiate(_cell, transform.position + new Vector3(j * _scale, 0, i * _scale), Quaternion.identity, transform);
                _cells[i, j].CellInit(i + 1 , (LetterNumbering)j);
                _cells[i, j].gameObject.name = $"{_cells[i, j].Number}{_cells[i, j].Letter}";
            }
        }
    }


    public Cell GetCell(int number, LetterNumbering letter)
    {
        if (number >= 0 && number < _length && (int)letter >= 0 && (int)letter < _width)
            return _cells[number, (int)letter];
        else return null;
    }
}