using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	Transform cameraTrans;
	public GameObject projectile;
	GameObject instan;
	public float bulletForce=10;
	public float distance = 1;


	// Use this for initialization
	void Start () {
	
		cameraTrans = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown("r")||Input.GetMouseButtonDown(0)){
			Rigidbody rigBod = ((GameObject)Instantiate(projectile,transform.position+transform.forward*distance,Quaternion.identity)).GetComponent<Rigidbody>();
			rigBod.AddForce(cameraTrans.transform.forward*bulletForce, ForceMode.Impulse);
		}
	}
}
