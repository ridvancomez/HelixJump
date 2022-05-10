using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Vector3 offSet;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        offSet = new Vector3(0,-3,7);
        playerTransform = GameObject.FindObjectOfType<PlayerJump>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position - offSet, 0.02f);
    }
}
