using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisonEnter(Collision col){
		if(col.gameObject.tag=="enemy"){
			col.gameObject.transform.localPosition=new Vector3(0,0,1);
			col.gameObject.transform.parent.transform.rotation=
				Quaternion.Euler(new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)));
			Destroy(gameObject);
		}

	}
}
