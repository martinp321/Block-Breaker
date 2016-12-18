using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour
{
    private LevelManager levelManager;

    private static int brickCount = 0;
    private int hits = 0;
    public Sprite[] hitSprites;
    public AudioClip audioClip;
    public ParticleSystem smokePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable)
            HandleHits();
    }

    private void HandleHits()
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        hits++;
        if (hits >= hitSprites.Length + 1)
        {
            var cnt = GameObject.FindObjectsOfType<Brick>();
            if (cnt.Length == 1)
            {
                levelManager.LoadNextLevel();
            }
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        ParticleSystem smoke = Instantiate(smokePrefab, gameObject.transform.position, Quaternion.identity) as ParticleSystem;
        smoke.startColor = this.GetComponent<SpriteRenderer>().color;
    }

    private void LoadSprites()
    {
        int SpriteIndex = hits - 1;
        if (hitSprites[SpriteIndex])
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
    }

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        brickCount++;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
