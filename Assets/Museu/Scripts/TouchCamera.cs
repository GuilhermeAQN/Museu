using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchCamera : MonoBehaviour {

    public float boundaryLeft;
    public float boundaryRight;
    public float boundaryUp;
    public float boundaryDown;
    private float camSizeH;
    private float camSizeV;

    public float TouchZoomSpeed = 1f;
	public float ZoomMinBound = 180f;
	public float ZoomMaxBound = 360f;
    Camera cam;
    bool Pinch = false;
    
    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        camSizeV = Camera.main.orthographicSize;
        camSizeH = Camera.main.orthographicSize * Screen.width / Screen.height;
    }
 
    void Update()
    {
        // if (Input.touchCount == 1)
        // {
        //     touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // }
        // Pinch to zoom
        if (Input.touchCount == 2)
        {
			// get current touch positions
            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);
			// get touch position from the previous frame
			Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
			Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;
 
			float oldTouchDistance = Vector2.Distance (tZeroPrevious, tOnePrevious);
			float currentTouchDistance = Vector2.Distance (tZero.position, tOne.position);
 
			// get offset value
			float deltaDistance = oldTouchDistance - currentTouchDistance;
			Zoom (deltaDistance, TouchZoomSpeed);
        }

        if (Camera.main.transform.position.x <= boundaryLeft + camSizeH)
        {
            transform.position = new Vector3(boundaryLeft + camSizeH, Camera.main.transform.position.y, -10);
        }
        if (Camera.main.transform.position.x >= boundaryRight - camSizeH)
        {
            transform.position = new Vector3(boundaryRight - camSizeH, Camera.main.transform.position.y, -10);
        }
        if (Camera.main.transform.position.y <= boundaryDown + camSizeV)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, boundaryDown + camSizeV, -10);
        }
        if (Camera.main.transform.position.y >= boundaryUp - camSizeV)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, boundaryUp - camSizeV, -10);
        }
    }
 
    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.orthographicSize += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, ZoomMinBound, ZoomMaxBound);
        camSizeV = Camera.main.orthographicSize;
        camSizeH = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    // Vector3 touchStart;

    // public float zoomOutMin;
    // public float zoomOutMax;
    // public float boundaryLeft;
    // public float boundaryRight;
    // public float boundaryUp;
    // public float boundaryDown;

    // private float camSizeH;
    // private float camSizeV;
    // // Use this for initialization
    // void Start()
    // {
    //     camSizeV = Camera.main.orthographicSize;
    //     camSizeH = Camera.main.orthographicSize * Screen.width / Screen.height;
    // }
    
    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //         {
    //             touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         }
    //     if (Input.touchCount == 2)
    //     {
    //         Touch touchZero = Input.GetTouch(0);
    //         Touch touchOne = Input.GetTouch(1);

    //         Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
    //         Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

    //         float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
    //         float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

    //         float difference = currentMagnitude - prevMagnitude;

    //         Zoom(difference * 1f);
    //     }else if (Input.GetMouseButton(0))
    //     {   
    //         Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         Camera.main.transform.position += direction;
    //     }

    //     if (Camera.main.transform.position.x <= boundaryLeft + camSizeH)
    //     {
    //         transform.position = new Vector3(boundaryLeft + camSizeH, Camera.main.transform.position.y, -10);
    //     }
    //     if (Camera.main.transform.position.x >= boundaryRight - camSizeH)
    //     {
    //         transform.position = new Vector3(boundaryRight - camSizeH, Camera.main.transform.position.y, -10);
    //     }
    //     if (Camera.main.transform.position.y <= boundaryDown + camSizeV)
    //     {
    //         transform.position = new Vector3(Camera.main.transform.position.x, boundaryDown + camSizeV, -10);
    //     }
    //     if (Camera.main.transform.position.y >= boundaryUp - camSizeV)
    //     {
    //         transform.position = new Vector3(Camera.main.transform.position.x, boundaryUp - camSizeV, -10);
    //     }
    // }

    // void Zoom(float increment)
    // {
    //     Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    //     camSizeV = Camera.main.orthographicSize;
    //     camSizeH = Camera.main.orthographicSize * Screen.width / Screen.height; // Calcula o 'Size' horizontal
    //     //o size da camera é igual a Metade da altura em unidades dela dentro do worldSpace
    // }
}
