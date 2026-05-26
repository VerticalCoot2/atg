using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamCTrollerSzkrip : MonoBehaviour
{
    int speed = 8;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        //pc cnemntroll
        transform.Translate(Input.GetAxis("Horizontal") * 5 * Time.deltaTime, 0, 0);


        //mobil controll
        transform.Translate(Input.acceleration.x / 3, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Finish":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Gate":
                Destroy(other.gameObject);
                break;
        }
    }
}
