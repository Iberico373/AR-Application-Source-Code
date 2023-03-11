using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeFunction : MonoBehaviour
{    
    public GameObject canvas;
    public GameObject helpButton;
    public RectTransform mainMenu;
    public ButtonFunctions buttonFunctions;

    //The previous position of where the user pressed on the screen
    private Vector2 previousPos;
    //The current position of where the user pressed on the screen
    private Vector2 currentPos;
    //The original/starting position of the main menu 
    public Vector3 originalPos;
    private Touch touch;

    public enum MenusState
    {
        isDown, isUp
    }

    public MenusState menusState;

    private void Start()
    {
        originalPos = mainMenu.anchoredPosition;
    }

    private void Update()
    {
        //This switch statement has 2 cases: isUp and isDown (default case)
        //isDown is when the menu is pulled all the way down
        //isUp is when the menu is fully pulled up
        switch (menusState)
        {
            //If the menu is pulled halfway up, the menu will slide
            //all the way up the top of the canvas
            case MenusState.isDown:

                helpButton.SetActive(true);

                if (mainMenu.position.y > canvas.transform.position.y 
                    && mainMenu.anchoredPosition.y < canvas.GetComponent<RectTransform>().rect.height)
                {
                    mainMenu.position += new Vector3(0, canvas.GetComponent<RectTransform>().rect.height, 0).normalized * 100 * Time.deltaTime;
                }

                //If the y position of the main menu exceeds the canvas' height,
                //set the position of the main menu to be at the top of the canvas and 
                //change the case to become isUp
                else if (mainMenu.anchoredPosition.y > canvas.GetComponent<RectTransform>().rect.height)
                {
                    mainMenu.anchoredPosition = new Vector3(0, canvas.GetComponent<RectTransform>().rect.height, 0);
                    menusState = MenusState.isUp;
                }     
                
                else
                {
                    //Reads user touch inputs if one of the menu buttons were pressed
                    if (buttonFunctions.onTouch)
                    {
                        touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Began)
                        {
                            previousPos = touch.position;
                        }

                        //Determine which direction the user is swiping in based on said inputs
                        //This is then used to drag the main menu up or down depending on the direction of the swipe
                        if (touch.phase == TouchPhase.Moved)
                        {
                            if(touch.position != previousPos)
                            {
                                currentPos.y = touch.position.y - previousPos.y;
                                mainMenu.position += (Vector3)currentPos * 0.25f * Time.deltaTime;
                            }
                            
                            previousPos = touch.position;
                        }

                    }

                    else
                    {
                        //Snaps main menu back down if the user did not drag the menu halfway up
                        mainMenu.anchoredPosition = originalPos;
                    }
                }
                break;

            //When the menu is pulled halfway down, the menu will slide all the way down 
            //Once the menu is at the bottom, the current case becomes isDown 
            case MenusState.isUp:

                helpButton.SetActive(false);

                if (mainMenu.position.y < canvas.transform.position.y 
                    && mainMenu.anchoredPosition.y > originalPos.y)
                {
                    mainMenu.position -= originalPos.normalized * 100 * Time.deltaTime;
                }

                //If the y position of the main menu exceeds the canvas' height,
                //set the position of the main menu to be at the bottom of the canvas and 
                //change the case to become isBottom
                else if (mainMenu.anchoredPosition.y < originalPos.y)
                {
                    mainMenu.anchoredPosition = originalPos;
                    menusState = MenusState.isDown;
                }               
                
                else
                {
                    //Reads user touch inputs if one of the menu buttons were pressed
                    if (buttonFunctions.onTouch)
                    {
                        touch = Input.GetTouch(0);

                        if (touch.phase == TouchPhase.Began)
                        {
                            previousPos = touch.position;
                        }

                        //Determine which direction the user is swiping in based on said inputs
                        //This is then used to drag the main menu up or down depending on the direction of the swipe
                        if (touch.phase == TouchPhase.Moved)
                        {
                            if (touch.position != previousPos)
                            {
                                currentPos.y = touch.position.y - previousPos.y;
                                mainMenu.position += (Vector3)currentPos * 0.25f * Time.deltaTime;
                            }
                            
                            previousPos = touch.position;
                        }

                    }

                    else
                    {
                        //Snaps main menu back up if the user did not drag the menu halfway down
                        mainMenu.anchoredPosition = new Vector3(0, canvas.GetComponent<RectTransform>().rect.height, 0);
                    }
                }
                break;

            default:
                menusState = MenusState.isDown;
                break;
        }
        
    }
}
