using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float gravityModifier = 1f; 
	public float jumpForce = 10f;
	private bool isOnGround = true;
	public bool gameOver = false;
	
	public ParticleSystem explosionParticle, dirtParticle;
	private Rigidbody playerRb;
	private Animator playerAnim;
	
	public AudioSource audioPlayer, gameMusic;
	public AudioClip jumpSound, crashSound;
	
    // Start is called before the first frame update
    void Start()
    {
		playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
		Physics.gravity *= gravityModifier;
		audioPlayer = GetComponent<AudioSource>();
		gameMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space)) && (isOnGround) && !(gameOver))
		{
			playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
			
			playerAnim.SetTrigger("Jump_trig");
			dirtParticle.Stop();
			audioPlayer.PlayOneShot(jumpSound, 1f);
		}
    }
	
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.tag == "Obstacle")
		{
			Debug.Log("game over");
			gameOver = true;
			
			playerAnim.SetBool("Death_b", true);
			playerAnim.SetInteger("DeathType_int", 1);
			
			audioPlayer.PlayOneShot(crashSound,1f);
			explosionParticle.Play();
			dirtParticle.Stop();
			gameMusic.Stop();
			
		} else if(collision.collider.tag == "Ground")
		{
			isOnGround = true;
			dirtParticle.Play();
		}
	}
}
