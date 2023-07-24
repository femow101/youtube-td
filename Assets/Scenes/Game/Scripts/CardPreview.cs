using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPreview : MonoBehaviour {
    
    [SerializeField] SpriteRenderer spriteRenderer;

    TowerStatus currentStatus;
    GameObject goFirstChild;
    Collider2D cardCollider;
    GridUnit gridUnit;
    bool onDragging;

    void Start() {
        goFirstChild = transform.GetChild(0).gameObject;
        cardCollider = GetComponentInChildren<Collider2D>(true);
    }

    void Update() {
        if (onDragging) {
            HandleDragging();
        }
    }

    void ResetCardPreview() {
        currentStatus = null;
        goFirstChild.SetActive(false);
        onDragging = false;
    }

    public void HandleDragStart(TowerStatus status) {
        currentStatus = status;
        goFirstChild.SetActive(true);
        spriteRenderer.sprite = status.GetSprite();
        spriteRenderer.color = status.GetColor();
        onDragging = true;
        EnableDisableCollider(false);
    }

    public void HandleDragging() {
        Vector3 mousePos = Input.mousePosition;
        
        mousePos.z = Camera.main.nearClipPlane;
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void HandleConfirm() {
        if (gridUnit != null) {
            gridUnit.PlaceTower(currentStatus);
        }
        
        ResetCardPreview();
    }

    public void HandleCancel() {
        ResetCardPreview();
    }

    public void HandleGridUnitTriggerEnter(GridUnit gridUnit) {
        this.gridUnit = gridUnit;
    }

    public void HandleGridUnitTriggerExit() {
        gridUnit = null;
    }

    public void EnableDisableCollider(bool enable) {
        cardCollider.enabled = enable;
    }
}
