using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

    public GameObject points;

	// Use this for initialization
	void Start () {
        points = GameObject.FindGameObjectWithTag("Points");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="enemy"){
            //col.gameObject.transform.localPosition=new Vector3(0,0,1);
            //col.gameObject.transform.parent.transform.rotation=
            //	Quaternion.Euler(new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)));
            Destroy(col.transform.parent.gameObject);
            
            EnemySpawner.score += 10;
            points.GetComponent<TextMesh>().text = "" + EnemySpawner.score;
      
            Destroy(gameObject);
		}

	}

    void OnTriggerExit(Collider col) {
        if(col.tag == "world") {
            Destroy(gameObject);
        }
    }
}
