using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckersManager : MonoBehaviour
{
    public static List<Vector3> checkers = new List<Vector3>();

    GameObject player;
    CharacterMovementHelper cmh;
    PaintRoad pr;
    List<bool> painted = new List<bool>();
    List<bool> left = new List<bool>();
    int paintedC = 0;
    bool win = false;
    float winTime = 0;

    public void SetPainted() {
        painted = new List<bool>();
        left = new List<bool>();
        for (int i = 0; i < checkers.Count; i++) {
            painted.Add(false);
            left.Add(false);
        }
        paintedC = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPainted();
        player = GameObject.Find("XR Origin");
        cmh = player.GetComponent<CharacterMovementHelper>();
        pr = player.GetComponent<PaintRoad>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (win == false) {
            Vector3 v = player.transform.position + cmh.offset;
            for (int i = 0; i < checkers.Count; i++) {
                if ((checkers[i] - v).magnitude < pr.radius) {
                    if (painted[i] == false) {
                        painted[i] = true;
                        paintedC++;
                    } else {
                        if (left[i] == true) {
                            cmh.Respawn();
                        }
                    }
                } else {
                    if (painted[i] == true && left[i] == false) {
                        left[i] = true;
                    }
                }
            }

            if (paintedC == painted.Count) {  //////    WINNNNNNNN
                win = true;
                AudioSource ass = GetComponent<AudioSource>();
                ass.Play();
            }
        } else {
            cmh.imobilazed += Time.deltaTime * 10;
            winTime += Time.deltaTime;

            if (winTime > 3) {
                SceneManager.LoadScene(4);
            }
        }
    }
}
