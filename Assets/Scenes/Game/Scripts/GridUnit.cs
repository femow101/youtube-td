using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnit : MonoBehaviour {
    
    public NodePoint node { get; private set; }

    [SerializeField] SpriteRenderer spriteRenderer;
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
        tower.HandlePlaceTower(towerStatus);
        spriteRenderer.color = Color.red;
    }

    public void EnableDisableSpriteRenderer(bool enable) {
        spriteRenderer.enabled = enable;
    }

    public void InitializeGridUnit(int x, int y) {
        node = new NodePoint(x, y);
    }

    public void SetIsPathOfThePath() {
        isPartOfPath.enabled = true;
    }
}
