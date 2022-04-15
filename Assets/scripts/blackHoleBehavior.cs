using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHoleBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,playerTransform.position,speed*Time.deltaTime);
    }
}
