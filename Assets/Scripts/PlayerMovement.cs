using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;

    public GameObject gameWonPanel;
    public GameObject gamePausePanel;

    public bool gameWon;


    // Start is called before the first frame update
    void Start()
    {
        gameWonPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWon)
        {
            return;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            rigidbody2d.velocity = new Vector2(speed, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rigidbody2d.velocity = new Vector2(-speed, 0);
        }

        else if (Input.GetAxis("Vertical") > 0)
        {
            rigidbody2d.velocity = new Vector2(0, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rigidbody2d.velocity = new Vector2(0, -speed);

        }

        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 )//&& Input.GetKey(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            gamePausePanel.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            Debug.Log("Level Complete");
            gameWonPanel.SetActive(true);
            gameWon = true;
        }
    }
}
