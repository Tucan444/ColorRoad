using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChooser : MonoBehaviour
{
    public int levelID = 1;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(levelID);
    }
}
