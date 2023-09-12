using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Figure
{
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
        for (int i = CurrentCell.Number; i < length; i++)
        {
            Cell cell = board.GetCell(i, CurrentCell.Letter);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }
            break;
        }

        for (int i = CurrentCell.Number - 2; i >= 0; i--)
        {
            Cell cell = board.GetCell(i, CurrentCell.Letter);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = (int)CurrentCell.Letter + 1; i < length; i++)
        {
            Cell cell = board.GetCell(CurrentCell.Number - 1, (LetterNumbering)i);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = (int)CurrentCell.Letter - 1; i >= 0; i--)
        {
            Cell cell = board.GetCell(CurrentCell.Number - 1, (LetterNumbering)i);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = CurrentCell.Number, j = (int)CurrentCell.Letter + 1; i < length && j < length; i++, j++)
        {
            Cell cell = board.GetCell(i, (LetterNumbering)j);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = CurrentCell.Number - 2, j = (int)CurrentCell.Letter - 1; i >= 0 && j >= 0; i--, j--)
        {
            Cell cell = board.GetCell(i, (LetterNumbering)j);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = CurrentCell.Number, j = (int)CurrentCell.Letter - 1; i < length && j >= 0; i++, j--)
        {
            Cell cell = board.GetCell(i, (LetterNumbering)j);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = CurrentCell.Number - 2, j = (int)CurrentCell.Letter + 1; i >= 0 && j < length; i--, j++)
        {
            Cell cell = board.GetCell(i, (LetterNumbering)j);
            if (cell.Figure == null)
            {
                _avaibleCells.Add(cell);
                continue;
            }
            else if (cell.Figure.Side != Side)
            {
                _avaibleCells.Add(cell);
                break;
            }

            break;
        }

        for (int i = 0; i < _avaibleCells.Count; i++)
        {
            Debug.Log(_avaibleCells[i].name);
        }
    }
}
