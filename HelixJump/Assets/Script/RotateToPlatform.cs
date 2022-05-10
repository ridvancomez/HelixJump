using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontal * speed * Time.deltaTime);
    }
}
