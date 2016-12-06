using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Camera mainCamera;

    public float cameraSpeed = 0.06f;
    public Vector3 mousePosition;
    public Vector3 currentCameraPosition;
    private Vector3 resetPosition;
    private Quaternion resetRotation;
    //private Vector3  
    
    // Camera bounds
    private int maxFieldOfView = 50;
    private int minFieldOfView = 20;
    private float maxTransformX = 10;
    private float minTransformX = -10;
    private float maxTransformZ = 7;
    private float minTransformZ = -7;
    

    // Mouse boundaries to move the camera
    private float mouseMinMoveLeft, mouseMaxMoveLeft;
    private float mouseMinMoveRight, mouseMaxMoveRight;
    private float mouseMinMoveUp, mouseMaxMoveUp;
    private float mouseMinMoveDown, mouseMaxMoveDown;

	// Use this for initialization
	void Start ()
    {
        mainCamera = GetComponent<Camera>();
        UpdateCameraBounds();
        resetPosition = transform.position;
        resetRotation = transform.rotation;
    }
	
    void UpdateCameraBounds()
    {
        mouseMaxMoveLeft = -(Screen.width / 2);
        mouseMinMoveLeft = mouseMaxMoveLeft + (Screen.width * 0.02f);
        mouseMaxMoveRight = Mathf.Abs(mouseMaxMoveLeft);
        mouseMinMoveRight = Mathf.Abs(mouseMinMoveLeft);

        mouseMaxMoveDown = -(Screen.height / 2);
        mouseMinMoveDown = mouseMaxMoveDown + (Screen.height * 0.02f);
        mouseMaxMoveUp = Mathf.Abs(mouseMaxMoveDown);
        mouseMinMoveUp = Mathf.Abs(mouseMinMoveDown);
    }

	// Update is called once per frame
	void Update ()
    {
        UpdateCameraBounds();
        currentCameraPosition = GetComponent<Transform>().position;
        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        //// Zooming
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScroll < 0)
            ZoomOut();
        if (mouseScroll > 0)
            ZoomIn();

        // Pan Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            MoveLeft();
        if (mousePosition.x > mouseMaxMoveLeft && mousePosition.x < mouseMinMoveLeft)
            MoveLeft();

        // Pan Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            MoveRight();
        if (mousePosition.x < mouseMaxMoveRight && mousePosition.x > mouseMinMoveRight)
            MoveRight();

        // Pan Up
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            MoveUp();
        if (mousePosition.y < mouseMaxMoveUp && mousePosition.y > mouseMinMoveUp)
            MoveUp();

        // Pan Down
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            MoveDown();
        if (mousePosition.y > mouseMaxMoveDown && mousePosition.y < mouseMinMoveDown)
            MoveDown();

        // Rotate Right
        if (Input.GetKey(KeyCode.E))
            RotateRight();

        // Rotate Left
        if (Input.GetKey(KeyCode.Q))
            RotateLeft();

        // Reset the camera
        if (Input.GetKeyDown(KeyCode.R))
            ResetCamera();
    }

    void ZoomOut()
    {
        if (mainCamera.fieldOfView < maxFieldOfView)
            mainCamera.fieldOfView++;
    }
    
    void ZoomIn()
    {
        if (mainCamera.fieldOfView > minFieldOfView)
            mainCamera.fieldOfView--;
    }

    void MoveLeft()
    {
        Vector3 left = -transform.right;
        left.y = 0;
        transform.position += left * cameraSpeed;
        BindCamera();
    }

    void MoveRight()
    {
        Vector3 right = transform.right;
        right.y = 0;
        transform.position += right * cameraSpeed;
        BindCamera();
    }

    void MoveUp()
    {
        Vector3 forward = transform.forward;
        forward.y = 0;
        transform.position += forward * cameraSpeed;
        BindCamera();
    }

    void MoveDown()
    {
        Vector3 down = -transform.forward;
        down.y = 0;
        transform.position += down * cameraSpeed;
        BindCamera();
    }

    void BindCamera()
    {
        Vector3 curPosition = transform.position;

        if (curPosition.x < minTransformX)
            curPosition.x = minTransformX;
        if (curPosition.x > maxTransformX)
            curPosition.x = maxTransformX;
        if (curPosition.z < minTransformZ)
            curPosition.z = minTransformZ;
        if (curPosition.z > maxTransformZ)
            curPosition.z = maxTransformZ;

        transform.position = curPosition;
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.up, Space.World);
        
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.down, Space.World);
    }

    void ResetCamera()
    {
        transform.position = resetPosition;
        transform.rotation = resetRotation;
    }
}
