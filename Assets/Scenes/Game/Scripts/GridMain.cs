using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMain : MonoBehaviour {
    
    const int GRID_COL_QTD = 10; // note, aways use upper case to declare constants variables :)    
    const int GRID_LIN_QTD = 10;

    [SerializeField] GridUnit pfUnit;

    Pathfinding pathfinding;
    GridUnit[,] gridUnits;

    void Start() {
        pathfinding = new Pathfinding();
        InitializeGrid();
    }

    void InitializeGrid() {
        var grid = new int[GRID_COL_QTD, GRID_LIN_QTD];
        gridUnits = new GridUnit[GRID_COL_QTD, GRID_LIN_QTD];

        for (int i = 0; i < GRID_COL_QTD; i++) {
            for (int j = 0; j < GRID_LIN_QTD; j++) {
                var unit = Instantiate(pfUnit, new Vector3(i, j, 0), Quaternion.identity, transform);
                unit.InitializeGridUnit(i, j);
                
                gridUnits[i, j] = unit;
            }
        }

        SetGridgridUnitsNeighbors();
        SetStartPositionOfTheGrid();
    }

    void SetGridgridUnitsNeighbors() {
        for (int i = 0; i < GRID_COL_QTD; i++) {
            for (int j = 0; j < GRID_LIN_QTD; j++) {
                var curNode = gridUnits[i, j];
                // Add left neighbor
                if (i > 0) { curNode.node.AddNeighbor(gridUnits[i - 1, j]); }
                // Add right neigbor
                if (i < GRID_COL_QTD - 1) { curNode.node.AddNeighbor(gridUnits[i + 1, j]); }
                // Add bottom neigbor
                if (j > 0) { curNode.node.AddNeighbor(gridUnits[i, j - 1]); }
                // Add top neigbor
                if (j < GRID_LIN_QTD - 1) { curNode.node.AddNeighbor(gridUnits[i, j + 1]); }
            }
        }
    }

    void SetStartPositionOfTheGrid() {
        float fullWidth  = GRID_COL_QTD;
        float fullHeigth = GRID_LIN_QTD;

        transform.position = new Vector3(-fullWidth / 2, -fullHeigth / 2, 0);
    }

    public void EnableDisableEditView(bool enable) {
        foreach(GridUnit unit in gridUnits) {
            unit.EnableDisableSpriteRenderer(enable);
        }
    }

    public List<GridUnit> GetPath() {
        return pathfinding.FindPath(gridUnits[0, 0], gridUnits[5, 5]);
    }
}
