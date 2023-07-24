using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    // A* (star) Pathfinding
    public List<GridUnit> FindPath(GridUnit start, GridUnit target) {
        start.node.SetInitialValues(start.node.ToPosition(), target.node.ToPosition());
        target.node.SetInitialValues(start.node.ToPosition(), target.node.ToPosition());

        // Initialize both open and closed list
        List<GridUnit> openList;
        List<GridUnit> closedList;

        // Add the start node
        // put the startNode on the openList (leave it's f at zero)
        openList = new List<GridUnit> { start };
        closedList = new List<GridUnit>();

        // Loop until you find the end
        // while the openList is not empty
        while (openList.Count > 0) {
            // Get the current node
            // let the currentNode equal the node with the least f value
            var currentNode = GetLeastF(openList);

            // remove the currentNode from the openList
            openList.Remove(currentNode);
            // add the currentNode to the closedList
            closedList.Add(currentNode);

            // Found the goal
            // if currentNode is the goal
            if (currentNode == target) {
                // Congratz! You've found the end! Backtrack to get path
                // path = []
                // current = current_node
                // while current is not None:
                //     path.append(current.position)
                //     current = current.parent
                // return path[::-1] # Return reversed path
                List<GridUnit> path = new List<GridUnit>();
                var current = currentNode;

                while (current != null) {
                    path.Add(current);
                    current.SetIsPathOfThePath();
                    current = current.node.parent;
                }

                path.Reverse();

                Debug.Log("The path is:");
                for (int i = 0; i < path.Count; i++) {
                    Debug.Log($"{i + 1} = {path[i].node.ToPosition()}");
                }

                return path;
            }

            // Generate neighbors
            // let the neighbort of the currentNode equal the adjacent nodes
            var neighbors = currentNode.node.GetNeighbors();
                
            // for each child in the children
            foreach (var neighbor in neighbors) {
                // Child is on the closedList
                // if child is in the closedList
                //     continue to beginning of for loop
                if (!closedList.Contains(neighbor)) {
                    // Create the f, g, and h values
                    var curNode = currentNode.node;
                    var neigPos = neighbor.node.ToPosition();
                    var targPos = target.node.ToPosition();

                    // child.g = currentNode.g + distance between child and current
                    neighbor.node.SetG(curNode.G_DistanceToStart + 1);
                    // child.h = distance from child to end
                    int distNeigToTarget = (int)(
                        Mathf.Abs(targPos.x - neigPos.x) +
                        Mathf.Abs(targPos.y - neigPos.y));
                    neighbor.node.SetH(distNeigToTarget);
                    // child.f = child.g + child.h
                    neighbor.node.SetF();

                    // Child is already in openList
                    // if child.position is in the openList's nodes positions
                    if (!openList.Contains(neighbor) ||
                        (openList.Contains(neighbor) && neighbor.node.G_DistanceToStart <= curNode.G_DistanceToStart)) {
                        // Add the child to the openList
                        openList.Add(neighbor);
                        neighbor.node.SetParent(currentNode);
                    }
                }
            }
        }
        
        return new List<GridUnit>();
    }

    GridUnit GetLeastF(List<GridUnit> list) {
        var leastFUnit = list[0];

        foreach(var unit in list) {
            if (unit.node.F_DistanceTotal < leastFUnit.node.F_DistanceTotal) {
                leastFUnit = unit;
            }
        }

        return leastFUnit;
    }
}
