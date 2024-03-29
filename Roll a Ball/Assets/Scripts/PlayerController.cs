﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;


    private Rigidbody rb;
    private int count;
    private AudioSource myAudio;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
        
    }

    void FixedUpdate()
    {
  
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Pick Up"))
        {
             other.gameObject.SetActive(false);
             count = count + 1;
             SetCountText();
             myAudio.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win!";
        }
    }

}
