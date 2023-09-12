using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Figure
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

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j ++)
            {
                if (i == 0 && j == 0)
                    continue;
                cell = board.GetCell(CurrentCell.Number - 1 + i, CurrentCell.Letter + j);
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
