using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    
    public bool isAvailable { get; private set; }

    [SerializeField] SpriteRenderer spriteRendererTowerSprite;
    [SerializeField] SpriteRenderer spriteRendererMinimap;

    GameObject goFirstChild;
    TowerStatus towerStatus;

    void UpdateMinimapSprite() {
        spriteRendererMinimap.sprite = towerStatus.GetSprite();
        spriteRendererMinimap.color = towerStatus.GetColor();
        spriteRendererMinimap.enabled = true;
    }

    public void SetTowerAvailability(bool enable) {
        isAvailable = enable;
    }

    public void HandlePlaceTower(TowerStatus towerStatus) {
        this.towerStatus = towerStatus;
        spriteRendererTowerSprite.sprite = towerStatus.GetSprite();
        spriteRendererTowerSprite.color = towerStatus.GetColor();
        UpdateMinimapSprite();
        goFirstChild = spriteRendererTowerSprite.gameObject;
        goFirstChild.SetActive(true);
        isAvailable = false;
    }

}
