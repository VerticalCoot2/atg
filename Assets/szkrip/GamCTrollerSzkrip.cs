using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GamCTrollerSzkrip : MonoBehaviour
{
    int speed = 8;

    int score = 0;
    [SerializeField] TMP_Text scoreText;

    void Awake()
    {
        scoreText.text = "0";
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
                score += other.gameObject.GetComponent<WallScript>().number;
                scoreText.text = ""+score;
                Destroy(other.gameObject);
                break;
        }
    }
}
