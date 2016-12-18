using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D body;

    private bool hasStarted = false;

    private new AudioSource audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, .2f), Random.Range(0f, .2f));
        body.velocity += tweak;
        print(body.velocity);
        audio.Play();
    }

    private void Awake()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
    }

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            body.velocity = new Vector2(2f, 10f);

        }

    }
}
