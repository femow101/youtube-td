using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CardsSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] CardPreview cardPreview;
    [SerializeField] GridMain gridMain;

    Card[] cards;
    bool onDraggingPreview;

    void Start() {
        cards = GetComponentsInChildren<Card>(true);
    }

    void Update() {
        if (onDraggingPreview) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                HandleClickCancel();
            } else if (Input.GetMouseButtonDown(0)) {
                HandleClickConfirm();
            }
        }
    }

    void DisablePreviewMode() {
        onDraggingPreview = false;
        gridMain.EnableDisableEditView(false);
    }

    void HandleClickConfirm() {
        cardPreview.HandleConfirm();
        DisablePreviewMode();
    }

    public void OnSelectCard(TowerStatus towerStatus) {
        cardPreview.HandleDragStart(towerStatus);
        gridMain.EnableDisableEditView(true);
        onDraggingPreview = true;
    }

    public void HandleClickCancel() {
        DisablePreviewMode();
        cardPreview.HandleCancel();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!onDraggingPreview) { return; }

        cardPreview.EnableDisableCollider(false);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (!onDraggingPreview) { return; }
        
        cardPreview.EnableDisableCollider(true);
    }
}
