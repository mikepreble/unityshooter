
using UnityEngine;
using System.Collections;

public class pickUps : MonoBehaviour {

	public int damagePerThrow = 60;
	public bool haveObject = false;
	public GameObject target;
	public GameObject thrownItem;
	public Vector3	difference;
	public Component targetPS;

	private GameObject currentItem;
	private float power = 8f;


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "pickUp" && haveObject == false) 
		{

			other.gameObject.SetActive (false);

			//Instantiate(grenadeEndPoint, new Vector3(2.589,-0.13,6.081),Quaternion.identity);
			target = GameObject.Find("grenadeEndPoint");


			thrownItem = Instantiate (other.gameObject, GameObject.Find ("magicSpawnPoint").transform.position, GameObject.Find ("magicSpawnPoint").transform.rotation) as GameObject;
			thrownItem.transform.parent = GameObject.Find ("magicSpawnPoint").transform;
			transform.parent = GameObject.Find ("magicSpawnPoint").transform;
			thrownItem.transform.localScale = new Vector3 (.18f, .1f, .1f);
			thrownItem.gameObject.SetActive (true);

			targetPS = target.gameObject.GetComponent("ParticleSystem");
			targetPS.particleSystem.loop = true;
			targetPS.particleSystem.Play(true);


			haveObject = true;


			difference = target.transform.position - thrownItem.transform.position;
			Rigidbody thrownItemRB = thrownItem.AddComponent("Rigidbody") as Rigidbody;
			thrownItem.rigidbody.isKinematic = true;


		}


	}



	void FixedUpdate()
	{


		if (Input.GetMouseButtonDown(1) && haveObject == true)
		{

			//thrownItem.transform.Translate(target.transform.position,Space.World);
			thrownItem.rigidbody.isKinematic = false;
			thrownItem.rigidbody.AddRelativeForce(50,90,50 * power);




			//GameObject thrownItem = GameObject.FindGameObjectWithTag("pickUp");
			/*
			if(thrownItem.rigidbody == null)
			{
				Rigidbody thrownItemRB = thrownItem.AddComponent("Rigidbody") as Rigidbody;
			
			} 
			*/



	


			//Destroy(currentItem);

			haveObject = false;

			Debug.Log ("you pressed the right mouse key aka fire 2");
		}
	}
}
