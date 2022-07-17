using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;

    public GameObject gameWonPanel;
    public GameObject gameLoss;
    public GameObject gamePausePanel;

    public bool isGameOver;


    // Start is called before the first frame update
    void Start()
    {
        gameWonPanel.SetActive(false);
        gamePausePanel.SetActive(false);
        gameLoss.SetActive(false);
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
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
            isGameOver = true;
        }
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("You loss");
            gameLoss.SetActive(true);
            isGameOver = true;
        }
    }

    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Button Clicked..");
    }
}
