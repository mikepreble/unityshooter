using UnityEngine;
using System.Collections;

public class inView : MonoBehaviour {

	public Component grenadeExplosion;
	private GameObject explosion;

	void Start ()
	{
		//grenadeExplosion = GameObject.GetComponent("ParticleSystem");
	
	}
	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name == "Floor") 
		{
			explosion = Instantiate (grenadeExplosion, transform.position,Quaternion.identity) as GameObject;
			gameObject.active = false;
		}


	}


}
