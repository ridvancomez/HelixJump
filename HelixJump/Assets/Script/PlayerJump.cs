using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private GameManager gameManager;
    bool flag;
    float power = 7;
    int jump;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        flag = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flag)
        {
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
            flag = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {


        flag = true;


        if(collision.gameObject.tag == "Obstacle")
        {
            transform.position = new Vector3(0, 12, -3);
        }

        if(collision.gameObject.tag == "Finish")
        {
            gameManager.LevelDegistir();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PuanArtir")
        {
            gameManager.ScoreArtir();
        }
    }
}
