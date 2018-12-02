using UnityEngine;
using System;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchCameraa : MonoBehaviour {

    public float boundaryLeft = -1630f;
    public float boundaryRight = 1630f;
    public float boundaryUp = 940f;
    public float boundaryDown = -450f;
    private float camSizeH;
    private float camSizeV;

    public float TouchZoomSpeed = 1f;
	public float ZoomMinBound = 180f;
	public float ZoomMaxBound = 360f;
    Camera cam;
    bool Pinch = false;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    
    void Start()
    {
        cam = GetComponent<Camera>();
        camSizeV = Camera.main.orthographicSize;
        camSizeH = Camera.main.orthographicSize * Screen.width / Screen.height;
    }
 
    void Update()
    {
        if (Input.touchCount == 1 && Pinch)
        {
            Pinch = false;
        }
        
        if(Input.touchCount == 1)//Mover a camera
        {
            if(!Pinch)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 NewPosition = GetWorldPosition();
                    Vector2 PositionDifference = NewPosition - StartPosition;
                    cam.transform.Translate(-PositionDifference);
                }
                StartPosition = GetWorldPosition();
            }
        }else if (Input.touchCount == 2)//Fazer o zoom
        { 
            Pinch = true;
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

        //limite da camera
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

    IEnumerator TempoPinch(){
		yield return new WaitForSeconds(0.0150f);
	}
    Vector2 GetWorldPosition(){
        return cam.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(0).position);
    }
    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.orthographicSize += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, ZoomMinBound, ZoomMaxBound);
        camSizeV = Camera.main.orthographicSize;
        camSizeH = Camera.main.orthographicSize * Screen.width / Screen.height;
    }
}
