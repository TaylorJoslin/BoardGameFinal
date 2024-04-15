using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Map : MonoBehaviour
{
    [SerializeField] private bool useCameraDrage = false;

    public float dragSpeed = .1f;
    private Vector3 dragOrigin;

    public GameObject button;
    public GameObject GoBack;
    public GameObject PlayerListUI;
    public GameObject TextUI;

    public void Update()
    {
        if (useCameraDrage == true)
        {
            CameraMovement();
        }
        else if (useCameraDrage == false)
        {
            transform.position = new Vector3(-19.75f, 35.82436f, 1.25f);
        }
    }

    public void CameraMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);


        transform.Translate(move, Space.World);

    }

    public void ViewMap()
    {
        button.SetActive(false);
        GoBack.SetActive(true);
        PlayerListUI.SetActive(false);
        TextUI.SetActive(false);
        useCameraDrage = true;
    }

    public void back()
    {
        GoBack.SetActive(false);
        button.SetActive(true);
        PlayerListUI.SetActive(true);
        TextUI.SetActive(true);
        useCameraDrage = false;
    }
}
