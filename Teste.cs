    // void CameraInBounds() {
    //     if(controlCamera && useBounds && cam != null && cam.orthographic) {
    //         cam.orthographicSize = Mathf.Min(cam.orthographicSize, ((boundMaxY - boundMinY) / 2) - 0.001f);
    //         cam.orthographicSize = Mathf.Min(cam.orthographicSize, (Screen.height * (boundMaxX - boundMinX) / (2 * Screen.width)) - 0.001f);

    //         Vector2 margin = cam.ScreenToWorldPoint((Vector2.up * Screen.height / 2) + (Vector2.right * Screen.width / 2)) - cam.ScreenToWorldPoint(Vector2.zero);

    //         float marginX = margin.x;
    //         float marginY = margin.y;

    //         float camMaxX = boundMaxX - marginX;
    //         float camMaxY = boundMaxY - marginY;
    //         float camMinX = boundMinX + marginX;
    //         float camMinY = boundMinY + marginY;

    //         float camX = Mathf.Clamp(cam.transform.position.x, camMinX, camMaxX);
    //         float camY = Mathf.Clamp(cam.transform.position.y, camMinY, camMaxY);

    //         cam.transform.position = new Vector3(camX, camY, cam.transform.position.z);
    //     }
    // }
    
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
    //     {
    //         {
    //             touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         }
    //     }
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
    //     }
    //     else if (Input.GetMouseButton(0))
    //     {
    //         {
    //             Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //             Camera.main.transform.position += direction;
    //         }
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
    //     //observar que o size da camera é igual a Metade da altura em unidades dela dentro do worldSpace
    // }