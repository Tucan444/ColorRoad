using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checker : MonoBehaviour
{
    void OnEnable() {
        CheckersManager.checkers.Add(transform.position);
    }
    void OnDisable() {
        CheckersManager.checkers.Remove(transform.position);
    }
}
