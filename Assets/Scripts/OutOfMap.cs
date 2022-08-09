using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    CharacterMovementHelper cmh;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterMovementHelper>()) {
            cmh = other.GetComponent<CharacterMovementHelper>();
            cmh.Respawn();
        }
    }
}
