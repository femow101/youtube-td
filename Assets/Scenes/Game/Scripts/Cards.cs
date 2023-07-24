using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour {

    GameObject goFirstChild;

    void Start() {
        goFirstChild = transform.GetChild(0).gameObject;
    }

    public void EnableDisable(bool enable) {
        goFirstChild.SetActive(enable);
    }
}
