using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ray : MonoBehaviour {

    public FollowAStarScript Princess;
    public AudioClip trailSound;
    public AudioSource trailSource;

    public AudioClip cheerSound;
    public AudioSource cheerSource;   

    public float followTime;
    public float howManyCheers;
    public float timer;
    public GameObject particles;

    public Text cheerText;
    public Text supportText;
    public Text timerText;

	// Use this for initialization
	void Start () {

        trailSource.clip = trailSound;
        followTime = 0;
        howManyCheers = 0;
        timer = 200f;

        cheerSource.clip = cheerSound;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        timerText.text = "Time Left: " + timer;

        cheerText.text = "Cheers: " + howManyCheers;
        supportText.text = "Support: " + followTime;

        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit) {
            Debug.Log("hit");

            if (Input.GetMouseButtonUp(0))
            {
                cheerSource.Play();
                howManyCheers++;
                Princess.speed += 0.1f;
            }
        }

        if (hit.collider.tag == "Princess")
        {
            Debug.Log("princess!");
            trailSource.Play();

            followTime++;

            Instantiate(particles, rayPos, Quaternion.identity);

        }


    }
}
