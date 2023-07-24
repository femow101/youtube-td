using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePoint {

    public GridUnit parent { get; private set; }
    public int H_DistanceToTarget { get; private set; }
    public int G_DistanceToStart { get; private set; }
    public int F_DistanceTotal { get; private set; }
    public int x { get; private set; }
    public int y { get; private set; }

    List<GridUnit> neightbors;

    public NodePoint(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public Vector3 ToPosition() {
        return new Vector3(x, y, 0);
    }

    public void SetInitialValues(Vector3 start, Vector3 target) {
        SetG((int)(Mathf.Abs(x - start.x) + Mathf.Abs(y - start.y)));
        SetH((int)(Mathf.Abs(x - target.x) + Mathf.Abs(y - target.y)));
        SetF();
    }

    public void SetF() {
        F_DistanceTotal = G_DistanceToStart + H_DistanceToTarget;
    }

    public void SetH(int h) {
        H_DistanceToTarget = h;
    }

    public void SetG(int g) {
        G_DistanceToStart = g;
    }

    public void AddNeighbor(GridUnit gridUnit) {
        if (neightbors == null) {
            neightbors = new List<GridUnit>();
        }

        neightbors.Add(gridUnit);
    }

    public List<GridUnit> GetNeighbors() {
        return neightbors;
    }

    public void SetParent(GridUnit gridUnit) {
        parent = gridUnit;
    }
}
