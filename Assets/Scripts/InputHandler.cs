using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using logic;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject continentMenu;

    private Camera _mainCamera;
    public void Awake()
    {
        _mainCamera = Camera.main;
        continentMenu.SetActive(false);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        var rayHits = Physics2D.GetRayIntersectionAll(_mainCamera.ScreenPointToRay((Vector3)Mouse.current.position.ReadValue()));
        if(rayHits == null || rayHits.Length == 0) //checks if array is empty for reading Buttons in the game canvas
        {
            return;
        }
        if (!rayHits[rayHits.Length - 1].collider)
        {
            return;
        }

        Debug.Log(rayHits[rayHits.Length - 1].collider.gameObject.name); //sends signal
        if (EventSystem.current.IsPointerOverGameObject()==true)
        {
            return;
        }
        if(rayHits[rayHits.Length - 1].collider.gameObject.GetComponent<Continent>()==null)
        {
            if (rayHits[rayHits.Length - 1].collider.gameObject.GetComponent<Continent>() == null)
            {
                continentMenu.SetActive(false);
                return;
            }
            return;
        }
        continentMenu.SetActive(true);
        continentMenu.GetComponent<ContinentMenu>().UpdateContinent(rayHits[rayHits.Length - 1].collider.gameObject.GetComponent<Continent>()); //current continentName reader
        //rayHits[rayHits.Length - 1].collider.gameObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV(); //fun test

    }

}
