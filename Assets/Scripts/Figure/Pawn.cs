using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Figure
{
    private bool _isMoved = false;

    public override void Moove(Cell cell)
    {
        for (int i = 0; i < _avaibleCells.Count; i++)
        {
            if (cell == _avaibleCells[i])
            {
                Vector3 cellPosition = cell.gameObject.transform.position;
                transform.position = new Vector3(cellPosition.x, transform.position.y, cellPosition.z);
                break;
            }
        }
    }

    public override void ProjectMoovement(int length, Board board)
    {
        _avaibleCells = new List<Cell>();
        Cell cell;

        if (Side == "White")
        {
            if (CurrentCell.Number < length)
            {
                for (int i = -1; i < 2; i += 2)
                {
                    if ((int)CurrentCell.Letter + i >= 0 && (int)CurrentCell.Letter + i < length)
                    {
                        cell = board.GetCell(CurrentCell.Number, CurrentCell.Letter + i);
                        if (cell.Figure != null)
                        {
                            if (cell.Figure.Side != Side)
                                _avaibleCells.Add(cell);
                        }
                    }
                }

                cell = board.GetCell(CurrentCell.Number, CurrentCell.Letter);
                if (cell.Figure == null)
                    _avaibleCells.Add(cell);

                if (_isMoved != true)
                {
                    cell = board.GetCell(CurrentCell.Number + 1, CurrentCell.Letter);
                    if (cell.Figure == null)
                    {
                        _avaibleCells.Add(cell);
                        _isMoved = true;
                    }
                }
            }
        }

        if (Side == "Black")
        {
            if (CurrentCell.Number - 2 >= 0)
            {
                for (int i = -1; i < 2; i++)
                {
                    if ((int)CurrentCell.Letter + i >= 0 && (int)CurrentCell.Letter + i < length)
                    {
                        cell = board.GetCell(CurrentCell.Number - 2, CurrentCell.Letter + i);
                        if (cell.Figure != null)
                        {
                            if (cell.Figure.Side != Side)
                                _avaibleCells.Add(cell);
                        }
                    }
                }

                cell = board.GetCell(CurrentCell.Number - 2, CurrentCell.Letter);
                if (cell.Figure == null)
                    _avaibleCells.Add(cell);

                if (_isMoved != true)
                {
                    cell = board.GetCell(CurrentCell.Number - 3, CurrentCell.Letter);
                    if (cell.Figure == null)
                    {
                        _avaibleCells.Add(cell);
                        _isMoved = true;
                    }
                }
            }
        }

        for (int i = 0; i < _avaibleCells.Count; i++)
        {
            Debug.Log(_avaibleCells[i].name);
        }
    }
}
