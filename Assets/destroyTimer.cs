using UnityEngine;
using System.Collections;

public class destroyTimer : MonoBehaviour {
	public float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time-=Time.deltaTime;
		if(time<=0){
			Destroy(gameObject);
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag=="world"){
			Destroy(gameObject);
		}
	}

}
