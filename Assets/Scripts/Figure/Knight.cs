using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Figure
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
        Cell cell;

        for (int i = -1; i < 2; i += 2)
        {
            for (int j = -2; j <= 3; j += 4)
            {
                cell = board.GetCell(CurrentCell.Number - 1 + i, CurrentCell.Letter + j);
                if (cell != null)
                {
                    if (cell.Figure == null)
                        _avaibleCells.Add(cell);
                    else if (cell.Figure.Side != Side)
                        _avaibleCells.Add(cell);
                }

                cell = board.GetCell(CurrentCell.Number - 1 + j, CurrentCell.Letter + i);
                if (cell != null)
                {
                    if (cell.Figure == null)
                        _avaibleCells.Add(cell);
                    else if (cell.Figure.Side != Side)
                        _avaibleCells.Add(cell);
                }
            }
        }

        for (int i = 0; i < _avaibleCells.Count; i++)
        {
            Debug.Log(_avaibleCells[i].name);
        }
    }
}
