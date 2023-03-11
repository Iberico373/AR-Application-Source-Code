using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

//Script referenced from MXRT Worksheet 1
public class Spawnable : MonoBehaviour
{
    public ARRaycastManager arRaycasatManager;
    public GameObject spawnableObjectPrefab;
    public GameObject spawnedObject = null;
    public GameObject warningText;
    public GameObject placementMenu;
    public GameObject mainMenu;
    public Camera cam;

    //Determines if an object can be placed or not
    private bool place;

    //Determines if an object is currently in preview mode or not
    public bool inPreview;

    private void Awake()
    {
        //Get neccessary variables from hierarchy
        cam = Camera.main;
        mainMenu = GameObject.Find("Main Menu");

        inPreview = true;
    }

    private void Update()
    {
        if (spawnedObject != null)
        {
            //Move object based on camera's orientation
            spawnedObject.transform.position = cam.transform.position + cam.transform.forward * 15;
            //Rotate object to face camera 
            spawnedObject.transform.LookAt(cam.transform);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            //Cast a ray at the position of the previewed object
            arRaycasatManager.Raycast(new Vector2(spawnedObject.transform.position.x, spawnedObject.transform.position.y), hits);
            //If the position of the object is not on a plane, set place to false
            //and give a warning message to the player
            if (hits.Count == 0)
            {
                warningText.SetActive(true);
                place = false;
            }

            //Else, set place = true and disable warning message
            else
            {
                warningText.SetActive(false);
                place = true;
            }
        } 
    }

    //Spawns the selected object in the menu to be previewed
    public void Spawn(Vector3 position, GameObject objectSelected)
    {
        Time.timeScale = 0;
        spawnableObjectPrefab = objectSelected;
        spawnedObject = Instantiate(spawnableObjectPrefab, position, Quaternion.identity);
        placementMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    //Place down the previewed object
    //Can only run if the placement is suitable (i.e., place = true)
    public void Accept()
    {
        if(place)
        {
            Time.timeScale = 1;
            spawnedObject = null;
            placementMenu.SetActive(false);
            mainMenu.SetActive(true);
        }        
    }

    //Cancels the preview
    public void Cancel()
    {
        Time.timeScale = 1;
        Destroy(spawnedObject);
        spawnedObject = null;
        placementMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}


