using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject furnitureMenu;
    public GameObject animalsMenu;
    public GameObject plantsMenu;
    public GameObject othersMenu;
    public GameObject helpMenu;
    public GameObject helpButton;
    //Determines if the user is touching the main menu buttons or not
    public bool onTouch;

    //Swaps to the furniture menu
    public void SwitchToFurniture()
    {
        furnitureMenu.SetActive(true);
        animalsMenu.SetActive(false);
        plantsMenu.SetActive(false);
        othersMenu.SetActive(false);
    }

    //Swaps to the animals menu
    public void SwitchToAnimals()
    {
        furnitureMenu.SetActive(false);
        animalsMenu.SetActive(true);
        plantsMenu.SetActive(false);
        othersMenu.SetActive(false);
    }

    //swaps to the plants menu
    public void SwitchToPlants()
    {
        furnitureMenu.SetActive(false);
        animalsMenu.SetActive(false);
        plantsMenu.SetActive(true);
        othersMenu.SetActive(false);
    }

    //swaps to the others menu
    public void SwitchToOthers()
    {
        furnitureMenu.SetActive(false);
        animalsMenu.SetActive(false);
        plantsMenu.SetActive(false);
        othersMenu.SetActive(true);
    }

    //Sets onTouch to true when any of the buttons are pressed
    public void OnTouch()
    {
        onTouch = true;
    }

    //Sets onTouch to false when any of the buttons are released
    public void OnRelease()
    {
        onTouch = false;
    }

    //Opens the help menu and pauses the app
    public void OpenMenu()
    {
        helpMenu.SetActive(true);
        helpButton.SetActive(false);
        Time.timeScale = 0;
    }

    //Closes the help menu and resumes the app
    public void CloseMenu()
    {
        helpMenu.SetActive(false);
        helpButton.SetActive(true);
        Time.timeScale = 1;
    }
}
