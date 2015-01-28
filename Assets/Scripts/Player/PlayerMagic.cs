using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 70f;


    float timer;
    Ray magicRay;
    RaycastHit magicHit;
    Ray freezeRay;
    RaycastHit freezeHit;
    int magicableMask;
    
    public ParticleSystem magicParticles;
	public ParticleSystem iceParticles;
    AudioSource magicAudio;

    Light magicLight;
    float effectsDisplayTime = 0.2f;
    
    public bool regularGun = true;


    void Awake ()
    {
        magicableMask = LayerMask.GetMask ("Shootable");
        magicAudio = GetComponent<AudioSource> ();
        magicLight = GetComponent<Light> ();
    }
    

    void FixedUpdate ()
    {
    	
		if(Input.GetButtonUp ("Fire3"))
    	{
    		regularGun = !regularGun;
    		Debug.Log (regularGun);
    	}
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
       magicLight.enabled = false;
    }


    void shoot ()
    {
		timer = 0f;
		
		magicAudio.Play ();
		
		magicLight.enabled = true;
		
		magicRay.origin = transform.position;
		magicRay.direction = transform.forward;
    
    
	
		magicParticles.Stop();
		magicParticles.Play ();


		
		if(Physics.Raycast (magicRay, out magicHit, range, magicableMask))
		{
			Debug.Log(magicHit.collider.gameObject.name);
			EnemyHealth enemyHealth = magicHit.collider.GetComponent <EnemyHealth> ();


			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerShot, magicHit.point);
			}
				
		if(regularGun)
		{	}
			
    	}else{

			iceParticles.Stop();
			iceParticles.Play ();
			
			if(Physics.Raycast (magicRay, out magicHit, range, magicableMask))
			{
				EnemyHealth enemyHealth = magicHit.collider.GetComponent <EnemyHealth> ();
				if(enemyHealth != null)
				{
					Debug.Log("freeze");
					enemyHealth.TakeDamage (damagePerShot, magicHit.point);
				}
			}
       	}
    }
    
}
