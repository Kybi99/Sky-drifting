﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes {NoType, Type1, Type2, Type3, Type4, Type5}; 
	public CollectibleTypes CollectibleType;
	public bool rotate; 
	public float rotationSpeed;
	public AudioClip collectSound;
	public GameObject collectEffect;
	public PointSystem pointSystem;

	void Start () {
		
	}
	
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

		if (CollectibleType == CollectibleTypes.NoType)
		{
			pointSystem.CollectedPoints();
		}
		
		Destroy (gameObject);
	}
}
