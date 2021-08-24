using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower = 20;
    GameObject obj;
    GameObject gameController;
    //Sound
    public AudioClip flyClip;
    public AudioClip gameOverClip;
    public AudioClip getPointClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame) //If isendgame false -> play sound fly
            {
                audioSource.clip = flyClip;
                audioSource.Play();
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.clip = getPointClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().GetPoint();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    void EndGame()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
