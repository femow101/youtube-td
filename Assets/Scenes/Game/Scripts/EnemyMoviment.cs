using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour {

    [SerializeField] GridMain gridMain;
    [SerializeField] float  velocity;

    List<GridUnit> path;
    GridUnit currentNode;
    Vector3 target;
    bool onMove;

    void Awake() {
        path = new List<GridUnit>();
    }

    IEnumerator Start() {

        yield return new WaitForSeconds(1);

        path = gridMain.GetPath();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (currentNode != null) {
            if (onMove) {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * velocity);
                if (Vector3.Distance(target, transform.position) == 0) {
                    onMove = false;
                    SetNextNode();
                }
            } else {
                onMove = true;
                target = currentNode.transform.position;
            }
        } else {
            SetNextNode();
        }
    }

    void SetNextNode() {
        if (path.Count > 0) {
            currentNode = path[0];
            path.RemoveAt(0);
        } else {
            currentNode = null;
        }
    }
}
