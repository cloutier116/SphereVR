using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	public List<Transform> allEnemiesParents;
	public List<Transform> allEnemies;
	public GameObject enemy;
	public int startingAmount;
	public float speed = .01f;
	Transform tempEnemy;
	// Use this for initialization
	void Start () {
		allEnemies=new List<Transform>();
		allEnemiesParents=new List<Transform>();

		for(int i=0;i<startingAmount;i++){
			Spawn();
		}
	//	InvokeRepeating("Spawn", 1, .5f);
	}

	void Update(){
		for(int i=0;i<allEnemies.Count;i++){

			if(allEnemies[i].localPosition.z<0){
				allEnemies[i].gameObject
				Invoke("Delay",Random.Range(0f,3f));
				tempEnemy=	allEnemies[i];
			//	allEnemiesParents[i].rotation=
				//	Quaternion.Euler(new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)));
				
				
			}
			allEnemies[i].Translate(new Vector3(0,0,speed));
		}
	}
	
	// Update is called once per frame
	void Spawn () {
		Vector3 orientation = new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360));
		allEnemiesParents.Add(((GameObject)Instantiate(enemy, Vector3.zero, Quaternion.Euler(orientation))).transform);
		//Debug.Log(allEnemies.Count+" "+allEnemies[allEnemies.Count-1].parent.transform);

		allEnemies.Add(allEnemiesParents[allEnemiesParents.Count-1].GetChild(0));
	}

	 void Delay(){
	tempEnemy.localPosition=new Vector3(0,0,1);
	}
}
