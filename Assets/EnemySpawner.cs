using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	//public List<Transform> allEnemiesParents;
	//public List<Transform> allEnemies;
	public GameObject enemy;
	public int startingAmount;
	public float speed = .001f;
    public float startingTime = 1f;
    public float reduceTime = .01f;
    public float minTime = .25f;
    public static int score = 0;
    public static int health = 3;
    public GameObject[] hearts;
    public GameObject gameOver;
    public GameObject damageSphere;
    public Material dSphereMat;
    public static bool Over = false;
	//Transform tempEnemy;
	// Use this for initialization
	void Start () {
        //allEnemies=new List<Transform>();
        //allEnemiesParents=new List<Transform>();
        Instantiate(enemy, Vector3.zero, Quaternion.Euler(Vector3.zero));

        for (int i=0;i<startingAmount;i++){
            Vector3 orientation = new Vector3(Random.Range(30, -30),Random.Range(0, 360), Random.Range(0, 360));
            Instantiate(enemy, Vector3.zero, Quaternion.Euler(orientation));
        }
		StartCoroutine("Spawn");

        dSphereMat = damageSphere.GetComponent<Renderer>().material;
	}

	void Update(){
		//for(int i=0;i<allEnemies.Count;i++){

			/*if(allEnemies[i].localPosition.z<0){
                Destroy(allEnemies[i]);
            }
				//allEnemies[i].gameObject
				Invoke("Delay",Random.Range(0f,3f));
				tempEnemy=	allEnemies[i];
			//	allEnemiesParents[i].rotation=
				//	Quaternion.Euler(new Vector3(Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)));
				
				
			}*/
			//allEnemies[i].Translate(new Vector3(0,0,speed));
		//}
	}
	
	// Update is called once per frame
	IEnumerator Spawn () {
        while (true) {
            Vector3 orientation = new Vector3(Random.Range(30, -30), Random.Range(0, 360), Random.Range(0, 360));
            Instantiate(enemy, Vector3.zero, Quaternion.Euler(orientation));
            yield return new WaitForSeconds(startingTime);
            startingTime -= reduceTime;
            if (startingTime < minTime)
                startingTime = minTime;
        }
        //allEnemiesParents.Add(((GameObject)Instantiate(enemy, Vector3.zero, Quaternion.Euler(orientation))).transform);
        //Debug.Log(allEnemies.Count+" "+allEnemies[allEnemies.Count-1].parent.transform);

        //allEnemies.Add(allEnemiesParents[allEnemiesParents.Count-1].GetChild(0));
    }

    public void TakeDamage() {
        StartCoroutine("FlashRed");
        health--;
        if (health == 2)
            hearts[2].SetActive(false);
        else if (health == 1)
            hearts[1].SetActive(false);
        else {
            hearts[0].SetActive(false);
            gameOver.SetActive(true);
            Over = true;
        }
    }

    IEnumerator FlashRed() {
        for (float i = 0; i <= 1; i += .1f) {
            dSphereMat.SetColor("_Color", new Color(1, 0, 0, i));
            //dSphereMat.color.a = i;//(new Color(1, 0, 0, i));// = i;
            yield return null;
        }
        for(float i = 1; i > -.1; i -= .1f) {
            dSphereMat.SetColor("_Color", new Color(1, 0, 0, i));
            //dSphereMat.color.a = i;
            yield return null;
        }
    }
    void Delay(){
	//tempEnemy.localPosition=new Vector3(0,0,1);
	}
}
