using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnit : MonoBehaviour {
    
    public NodePoint node { get; private set; }

    [SerializeField] SpriteRenderer spriteRendererAvailability;
    [SerializeField] SpriteRenderer isPartOfPath;
    [SerializeField] GameObject preview;
    [SerializeField] Tower tower;

    void OnTriggerEnter2D(Collider2D col) {
        col.GetComponentInParent<CardPreview>().HandleGridUnitTriggerEnter(this);
        preview.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col) {
        col.GetComponentInParent<CardPreview>().HandleGridUnitTriggerExit();
        preview.SetActive(false);
    }

    public void PlaceTower(TowerStatus towerStatus) {
        if (!tower.isAvailable) { return; }

        tower.HandlePlaceTower(towerStatus);
        node.SetWalkable(false);
        spriteRendererAvailability.color = Color.red;
    }

    public void EnableDisableSpriteRenderer(bool enable) {
        spriteRendererAvailability.enabled = enable;
    }

    public void InitializeGridUnit(int x, int y) {
        bool notFirstLineAndNotLast = y != 0 && y != GridMain.GRID_LIN_QTD - 1;
        bool isTopLeft = x == 0 & y == GridMain.GRID_LIN_QTD - 1;
        bool isBottomRight = x == GridMain.GRID_COL_QTD - 1 & y == 0;
        bool isWalkableOrPlaceable = notFirstLineAndNotLast || isTopLeft || isBottomRight;

        node = new NodePoint(x, y);
        node.SetWalkable(isWalkableOrPlaceable);
        tower.SetTowerAvailability(notFirstLineAndNotLast);

        if (!isWalkableOrPlaceable) {
            spriteRendererAvailability.color = Color.red;
        }
    }

    public void SetIsPathOfThePath() {
        isPartOfPath.enabled = true;
    }
}
