using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class CharacterMovementHelper : MonoBehaviour
{
    [SerializeField] InputActionAsset controls;
    public float speed = 2;
    public float maxSpeed = 6;
    public float immobilizeSpeed = 3;
    private XROrigin xROrigin;
    private CharacterController characterController;
    private CharacterControllerDriver driver;

    Vector3 velocity = new Vector3();
    [HideInInspector] public Vector3 offset = new Vector3();
    Vector3 startPos = new Vector3();

    float sqrMaxSped = 36;

    InputAction imobilize;
    [HideInInspector] public float imobilazed = 1;
    bool imobilizing = false;
    float maxImobilized = 3;

    InputAction menu;

    // Start is called before the first frame update
    void Start()
    {
        xROrigin = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
        Rigidbody body = characterController.GetComponent<Rigidbody>();
        var gameplayActionMap = controls.FindActionMap("XRI RightHand");

        imobilize = gameplayActionMap.FindAction("Slow");
        imobilize.performed += ToggleImobilize;
        imobilize.canceled += ToggleImobilize;
        imobilize.Enable();

        gameplayActionMap = controls.FindActionMap("XRI LeftHand");

        menu = gameplayActionMap.FindAction("Menu");
        menu.performed += ReturnToMenu;
        menu.Enable();

        offset = xROrigin.CameraInOriginSpacePos;
        sqrMaxSped = maxSpeed * maxSpeed;
        startPos = transform.position;
        imobilazed = maxImobilized;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();

        velocity = (xROrigin.CameraInOriginSpacePos - offset) * speed * Time.deltaTime;
        velocity[1] = 0;
        velocity /= imobilazed;
        if (velocity.sqrMagnitude > sqrMaxSped) {
            velocity *= (maxSpeed / velocity.magnitude);
        }
        characterController.Move(velocity);

        if (imobilazed > 1) {
            imobilazed -= Time.deltaTime;
        }

        if (imobilizing) {
            imobilazed += Time.deltaTime * (immobilizeSpeed+1);
            imobilazed = Mathf.Min(imobilazed, maxImobilized);
        }
        Debug.Log(imobilazed);
    }

    void ToggleImobilize(InputAction.CallbackContext context) {
        imobilizing = !imobilizing;
    }

    void ReturnToMenu(InputAction.CallbackContext context) {
        SceneManager.LoadScene(4);
    }

    public void Respawn() {
        characterController.enabled = false;
        transform.position = startPos;
        characterController.enabled = true;
        imobilazed = maxImobilized;

        PaintRoad pr = GetComponent<PaintRoad>();
        pr.ClearRoad();

        if (GameObject.Find("Checkers")) {
            CheckersManager checkersManager = GameObject.Find("Checkers").GetComponent<CheckersManager>();
            checkersManager.SetPainted();
        }

        if (GameObject.Find("PrePainted")) {
            GameObject parentpp = GameObject.Find("PrePainted");
            PrePaint pp = parentpp.GetComponent<PrePaint>();
            pp.done = false;

            Component[] pps = parentpp.GetComponentsInChildren(typeof(PrePaint));

            foreach(PrePaint ppc in pps) {
                ppc.done = false;
            }
        }
    }

    protected virtual void UpdateCharacterController()
        {
            if (xROrigin == null || characterController == null)
                return;
            
            var height = Mathf.Clamp(xROrigin.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

            Vector3 center = xROrigin.CameraInOriginSpacePos;
            center.y = height / 2f + characterController.skinWidth;

            characterController.height = height;
            characterController.center = center;
        }
}
