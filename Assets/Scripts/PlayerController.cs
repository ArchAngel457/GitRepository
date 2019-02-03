using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 3;
        SetAllText();
        winText.text = "";
        loseText.text = "";
    }

    private void SetCountText()
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Pick Up Bad"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetAllText();
        }
        if (count == 12)
        {
            transform.position = new Vector3(151.27f, transform.position.y, 0f);
        }
        if (score == 0)
        {
         
        }
    }
    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
        scoreText.text = "Lives: " + score.ToString();
        if (score <= 0)
        {
            loseText.text = "You Lose!";
        }
    }
}


/*scoreText.text = "Score: " + score.ToString();
    if (count >=3)
    {
      lossText.text = "You Lose!";
   */
