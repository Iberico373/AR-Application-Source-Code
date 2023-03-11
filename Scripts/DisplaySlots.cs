using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySlots : MonoBehaviour
{
    public SwipeFunction swipe;
    public Spawnable spawnable;
    public Object _object;
    public Image icon;
    public Camera cam;

    private void Awake()
    {
        //If an object is assigned to the slot, change slot icon to the object's icon
        if(_object != null)
        {
            icon.sprite = _object.icon;
        }

        //Get neccessary variables from hierarchy
        spawnable = GameObject.Find("Spawner").GetComponent<Spawnable>();
        swipe = GameObject.Find("Canvas").GetComponent<SwipeFunction>();
        cam = Camera.main;
    }

    //Slides the main menu down to the bottom 
    //Passes the GameObject information of the selected object into Spawn() and calls it
    public void CallSpawn()
    {
        swipe.mainMenu.anchoredPosition = swipe.originalPos;
        swipe.menusState = SwipeFunction.MenusState.isDown;
        spawnable.Spawn(cam.transform.position + cam.transform.forward * 15, _object.objectPrefab);
    }
}
