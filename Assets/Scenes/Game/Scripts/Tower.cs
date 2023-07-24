using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer spriteRendererMinimap;

    GameObject goFirstChild;
    TowerStatus towerStatus;
    bool isAvailable;

    public void HandlePlaceTower(TowerStatus towerStatus) {
        if (isAvailable) return;

        this.towerStatus = towerStatus;
        spriteRenderer.sprite = towerStatus.GetSprite();
        spriteRenderer.color = towerStatus.GetColor();
        UpdateMinimapSprite();
        goFirstChild = spriteRenderer.gameObject;
        goFirstChild.SetActive(true);
        isAvailable = true;
    }

    void UpdateMinimapSprite() {
        spriteRendererMinimap.sprite = towerStatus.GetSprite();
        spriteRendererMinimap.color = towerStatus.GetColor();
        spriteRendererMinimap.enabled = true;
    }
}
