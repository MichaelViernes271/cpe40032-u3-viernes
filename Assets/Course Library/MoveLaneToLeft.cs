﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaneToLeft : MonoBehaviour
{
	private RepeatBackground repeatBg;
	private Vector3 startPos;
	private PlayerController playerControllerScript;
	private float speed = 25f;
	
    // Start is called before the first frame update
    void Start()
    {
		startPos = transform.position;
		repeatBg = GameObject.Find("Background").GetComponent<RepeatBackground>();
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -7f)
		{
			transform.position = startPos;
		} else if(playerControllerScript.gameOver == false)
		{
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
    }
}
