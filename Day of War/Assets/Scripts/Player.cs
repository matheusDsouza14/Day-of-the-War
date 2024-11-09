using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float screenwidth;
    [SerializeField]private float screenheight;
    [SerializeField]private float movespeed;
    [SerializeField]private float rotatespeed;
    [SerializeField]private GameManager Manager;
    [SerializeField]private BulletNShooting bulletNShooting;
    //[SerializeField]private WaypointMove waypointMove;
    [SerializeField]private Camera[] cameras = new Camera[2];
    [SerializeField]private Vector3 minBounds,maxBounds;
    void Start()
    {

        Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //waypointMove = GameObject.Find("Main Camera").GetComponent<WaypointMove>();
    }
    void Update()
    {
        screenheight = Screen.height;
        screenwidth = Screen.width;
        if (Manager.bossBattleToggle == false)
        {
            TPDMovement();
        }
        else
        {
            OVSMovement();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(bulletNShooting.canshoot==true)
            {
                bulletNShooting.Shooting();
            }
            
        }
    }
    private void TPDMovement() // Top down movement (gameplay segments)
    {
        // Calls calculate bounds
        CalculateWorldBounds();
        // Player Move
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float z = vertical * movespeed * Time.deltaTime;
        float x = horizontal * movespeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(x, 0f, z);
        // Clamp movement
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.z = Mathf.Clamp(newPosition.z, minBounds.z, maxBounds.z);
        transform.position = newPosition; // Updates position
    }

    public void OVSMovement() // Over the Shoulder Movement (boss battle)
    {
        
    }
    private void CalculateWorldBounds()
    {
        // Get the player's Y position 
        float playerY = transform.position.y;
        // Calculate the screen's bottom-left and top-right corners in world coordinates
        Vector3 bottomLeft = cameras[0].ViewportToWorldPoint(new Vector3(0, 0, cameras[0].transform.position.y - playerY));
        Vector3 topRight = cameras[0].ViewportToWorldPoint(new Vector3(1, 1, cameras[0].transform.position.y - playerY));
        // Define the min and max bounds based on these screen corners
        minBounds = new Vector3(bottomLeft.x, playerY, bottomLeft.z);
        maxBounds = new Vector3(topRight.x, playerY, topRight.z);
    }
}
