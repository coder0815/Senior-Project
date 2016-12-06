using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;
	public GameObject impactEffect;

	public void Seek(Transform _target)
	{
		target = _target;
	}


	// Update is called once per frame
	void Update () 
	{
		if (target == null)
		{
			Destroy (gameObject);
			return;
		}

        Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);

        // Rotate towards the target
        Vector3 targetDir = target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1f, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

	void HitTarget()
	{
		//GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		//Destroy (effectIns, 2f);
		Destroy (gameObject);
	}
}
