using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	float moveSpeed = .04f;
	Transform cameraTrans;
	Vector3 forwards;
	Vector3 sideways;
	Rigidbody rb;
	public float jumpForce=50;
	public TextMesh text;
	public KeyCode jumpKey = KeyCode.Space;
	public Transform textTransform;
	float x;
	float y;
	// Use this for initialization
	void Start () {
		cameraTrans = Camera.main.transform;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		x+=Input.GetAxis ("Mouse X");
		y+=Input.GetAxis ("Mouse Y");
		forwards=cameraTrans.right * Input.GetAxis("Horizontal") * moveSpeed;
		sideways=cameraTrans.forward * Input.GetAxis("Vertical") * moveSpeed;

		if(Input.GetMouseButton(0)){
			forwards=cameraTrans.forward * 5 * moveSpeed;

		}

		forwards.y=0;
		sideways.y=0;
		text.text=""+Input.mousePosition;
		transform.position += forwards;
		transform.position += sideways;
		//textTransform.position=new Vector3(x/10,0,y/10);

		if(Input.GetButtonDown("TurnRight")){
			transform.localRotation*=Quaternion.Euler(new Vector3(0,35,0));
		}
		if(Input.GetButtonDown("TurnLeft")){
			transform.localRotation*=Quaternion.Euler(new Vector3(0,-35,0));
		}
	}
	void FixedUpdate(){
		if(Input.GetKeyDown(jumpKey)||Input.GetKeyDown(KeyCode.Escape))
		{
			rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
		}
	}
}
