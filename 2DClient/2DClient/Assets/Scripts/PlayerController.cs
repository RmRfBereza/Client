using UnityEngine;
using System.Collections;

//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;		//Store a reference to the Rigidbody2D component required to use 2D Physics.

    private Vector2 newPosition;
    private Random rand = new Random();
    private double timeleft;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.position = Vector2.zero;

        timeleft = 1;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //следующий код предназначен для передвижения игрока стрелками. Будет выпилено позже. Сейчас оставил для тестов.
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        //следующий код отвечает за передвежиние игрока по полченным координатам, через апи

        if (timeleft < 0)
        {
            newPosition = GetPlayerCoordTest();
            timeleft = 1;
            rb2d.position = newPosition;
        }
        timeleft -= Time.deltaTime;
    }

    Vector2 GetPlayerCoordTest()
    {
        float x = rb2d.position.x;
        float y = rb2d.position.y;

        //бросаю монету(возможные вариант 1 или 0)
        if (rand.Next(0, 2) == 0)
        {
            x += 3.6f;
            y -= 3.6f;
        }
        else
        {
            x -= 3.6f;
            y += 3.6f;
        }

        if (x > 10.8 || x < -10.8f)
        {
            x = 0f;
        }
        if (y > 10.8 || y < -10.8f)
        {
            y = 0f;
        }
        return new Vector2(x, y);
    }
}
