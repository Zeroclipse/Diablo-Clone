using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Input : MonoBehaviour
{
    #region Variables and Delegates
    #region delete later
    //Temporary camera things
    [Tooltip("The Mouse Sensitivity for rotating Right and Left")]
    public float sensitivityX;
    [Tooltip("The Mouse Sensitivity for rotating Up and Down")]
    public float sensitivityY;

    [Tooltip("The farthest You can look down.")]
    public float minY = -60;

    [Tooltip("The farthest you can look up.")]
    public float maxY = 60;

    float rotationY = 0f;

    private Vector3 cameraStartPosition;
    private Vector3 cameraStartRotation;

    [SerializeField] private GameObject testInfoScreen;
    #endregion
    //This is just to check if the inventory is open or closed
    public bool inventoryOpen; //This is permanent

    //This is just to check if the Dungeon Randomization Menu is open or closed
    public bool dungeonOpen;  //This all may be just temporary and is probably temporary, if so delete any instances of this or stuff that requires this

    //Delete this, this is just for setting up the inventory
    public SetupInventory setup;

    //Sends when you click the inventory button, which is i
    public event Action OnInventoryPress = delegate { }; //Needed
    //sends when you press escape
    public event Action OnEscPress = delegate { }; //Needed

    //Sends when you press G, opens dungeon management things
    public event Action OnGPress = delegate { }; //Delete later
    #endregion

    private void Start()
    {
        if (inventoryOpen == false && dungeonOpen == false)
        {
            testInfoScreen.SetActive(true);
        }
        else
        {
            testInfoScreen.SetActive(false);
        }
        cameraStartPosition = Camera.main.transform.position;
        cameraStartRotation = Camera.main.transform.localEulerAngles;
    }
    void Update()
    {
        #region Dungeon Randomization Test
        //Test Code for the Dungeon Management things
        if (Input.GetKeyDown(KeyCode.G) && inventoryOpen == false || inventoryOpen == false && Input.GetButtonDown("Escape") && dungeonOpen == true)
        {
            //Calls the delegate that has the method to open or close the Dungeon Menu
            OnGPress();
            //Switches Dungeon open to true or false
            if (dungeonOpen == false)
            {
                dungeonOpen = true;
                testInfoScreen.SetActive(false);
            }
            else
            {
                testInfoScreen.SetActive(true);
                dungeonOpen = false;
                Camera.main.transform.position = cameraStartPosition;
                Camera.main.transform.localEulerAngles = cameraStartRotation;
            }
        }
        #endregion
        #region Open and Close Inventory
        //Check if you want to close the inventory
        if (Input.GetButtonDown("InventoryButton") && dungeonOpen == false || inventoryOpen == true && Input.GetButtonDown("Escape") && dungeonOpen == false)
        {
            //Calls the delegate that has the method to open or close the inventory
            OnInventoryPress();
            //Switches inventory open to true or false
            if (inventoryOpen == false)
            {
                inventoryOpen = true;
                testInfoScreen.SetActive(false);
            }
            else
            {
                testInfoScreen.SetActive(true);
                inventoryOpen = false;
            }
        }
        #endregion
        #region Escape
        if (inventoryOpen == false && dungeonOpen == false && Input.GetButtonDown("Escape"))
        {
            OnEscPress();
        }
        #endregion
        if (inventoryOpen == true && dungeonOpen == false)
        {
            #region Temporary Test Things for Inventory
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setup.Place1();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                setup.Place2();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                setup.Place3();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                setup.Place4();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                setup.Place5();
            }
            #endregion
        }
        #region Test things for dungeon
        else if (dungeonOpen == true && inventoryOpen == false)
        {
            //Use this for the camera moving scripts, maybe make a method that this calls and can be commented out
            CameraMove();
        }
        #endregion
    }

    #region CameraMove
    //Moves, rotates and changes height of the camera.
    private void CameraMove()
    {
        //If tester pressed w or s buttons, camera moves forward and backwards
        if (Input.GetButton("Vertical Movement"))
        {
            Camera.main.transform.position += transform.forward * Input.GetAxis("Vertical Movement") * .5f;
        }
        
        //If tester pressed a or d buttons, camera moves left and right
        if (Input.GetButton("Horizontal Movement"))
        {
            Camera.main.transform.position += transform.right * Input.GetAxis("Horizontal Movement") * .5f;
        }

        //If tester moves mouse, it rotates the camera
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            Camera.main.transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
        }

        //If tester presses space or left alt, camera moves up or down
        if (Input.GetButton("Raise/Lower Camera"))
        {
            Camera.main.transform.position += transform.up * Input.GetAxis("Raise/Lower Camera");
        }
    }
    #endregion
}
