using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectMove : MonoBehaviour
{

    Vector2 position;

    void Update()
    {
        position.x += 60 * Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
    }

}
