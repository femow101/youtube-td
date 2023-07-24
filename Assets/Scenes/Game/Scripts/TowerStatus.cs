using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatus : MonoBehaviour {
    
    [SerializeField] int id;
    [SerializeField] string displayName;
    [SerializeField] Sprite sprite;
    [SerializeField] Color color;

    public Sprite GetSprite() { return sprite; }

    public Color GetColor() { return color; }
}
