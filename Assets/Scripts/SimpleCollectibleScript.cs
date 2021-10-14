﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Type1, Type2, Type3, Type4, Type5}; 
	public CollectibleTypes CollectibleType;
	public bool rotate; 
	public float rotationSpeed;
	public AudioClip collectSound;
	public GameObject collectEffect;
	public PointSystem pointSystem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType)
		{
			Destroy(this);
			pointSystem.CollectedPoints();
			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type1) 
		{
			//Add in code here;
			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type2) 
		{
			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type3) 
		{
			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type4) 
		{
			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type5)
		{
			//Add in code here;

			Debug.Log ("Do NoType Command");
		}

		Destroy (gameObject);
	}
}