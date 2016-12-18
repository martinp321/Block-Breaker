using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    private float xMax = 14f;
    private float xMin = 0.5f;

    public bool autoPlay = false;

    private Ball ball;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (autoPlay)
        {
            Vector3 paddlePos = new Vector3(.5f, this.transform.position.y, 0f);
            Vector3 ballPos = ball.transform.position;

            paddlePos.x = Mathf.Clamp(ballPos.x, xMin, xMax);
            this.transform.position = paddlePos;
        }
        else
        {
            ManualPlayer();
        }
    }

    private void ManualPlayer()
    {
        float xPos;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xPos = Mathf.Clamp(this.transform.position.x - 1, xMin, xMax);
            Vector3 pos = new Vector3(xPos, this.transform.position.y, 0f);
            this.transform.position = pos;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            xPos = Mathf.Clamp(this.transform.position.x + 1, xMin, xMax);
            Vector3 pos = new Vector3(xPos, this.transform.position.y, 0f);
            this.transform.position = pos;
        }
    }
}
