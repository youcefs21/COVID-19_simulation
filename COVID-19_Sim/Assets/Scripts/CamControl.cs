using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public static float speed = 40.0f;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        
            float Vertical = Input.GetAxis("Vertical") * speed;
            float Horizontal = Input.GetAxis("Horizontal") * speed;
            float scroll = Input.GetAxis("Mouse ScrollWheel") * speed * 30;
            scroll *= Time.deltaTime;
            Vertical *= Time.deltaTime;
            Horizontal *= Time.deltaTime;


            transform.Translate(Horizontal, Vertical, scroll);
        
        
    }
}
