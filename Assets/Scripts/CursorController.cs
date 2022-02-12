using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    public Texture2D cursor;

    public Texture2D cursorClicked;

    private CursorControls controls;

    private Camera mainCamera;

    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }

    // Detects whether an object is being pressed
    private void DetectObject()
    {
        // 3D
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            if (hit.collider != null){
                IClick click = hit.collider.GetComponent<IClick>();
                if (click != null) click.onClickAction();
                Debug.Log("Hit: " + hit.collider.tag);
            }
        }

        // For raycasting with multiple hits
        /*
        RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        for (int i = 0; i < hits.Length; i++){
            if (hits[i].collider != null){
                Debug.Log("Hit All: " + hits[i].collider.tag);
            }
        }
        */

        // 2D
        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null){
            Debug.Log("2D Hit " + hits2D.collider.tag);
        }
    }


    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }


}
