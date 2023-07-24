using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour {
    
    // [SerializeField] TowerToggleAnimation towerToggleAnimation;
    [SerializeField] CardsSelection cardsSelection;
    [SerializeField] Image imageTower;
    
    TowerStatus status;

    void Awake() {
        status = GetComponent<TowerStatus>();
    }

    void Start() {
        InitializeCard();
    }

    void InitializeCard() {
        imageTower.sprite = status.GetSprite();
        imageTower.color = status.GetColor();
    }

    public void HandleClick() {
        cardsSelection.OnSelectCard(status);
    }
}
