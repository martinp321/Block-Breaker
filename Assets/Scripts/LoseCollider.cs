using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("OnTriggerEnter2d");
        levelManager.LoadLevel("Lose");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("OnCollisionEnter2d");
    }

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
