using UnityEngine;
using System.Collections;

public class MoveIn : MonoBehaviour {

    public float speed = .001f;
    Transform parent;

    // Use this for initialization
    void Start() {
        parent = transform.parent.transform;
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.Translate(new Vector3(0, speed, 0));
        parent.Rotate(0, 0, 5);

    }

    void OnTriggerEnter(Collider col)     
    {
        if (col.tag == "MainCamera") {
            col.GetComponent<EnemySpawner>().TakeDamage();
            Destroy(transform.parent.gameObject);
        }
    }
}
