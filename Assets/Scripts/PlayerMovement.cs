using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	public float jumpSpeed = 6f;


	Vector3 direction = Vector3.zero;

	float verticalVelocity = 0;

	CharacterController cc;
	Animator anim;

	private Camera m_Camera;
	private Vector3 m_OriginalCameraPosition;
	
	[SerializeField] private MouseLook m_MouseLook;


	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		anim = GetComponent <Animator>();
		m_Camera = GetComponentInChildren<Camera>();
		m_MouseLook.Init(transform , m_Camera.transform);
	}
	
	// Update is called once per frame
	void Update () {
		RotateView ();
		direction = transform.rotation * new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		if(direction.magnitude > 1f){
			direction = direction.normalized;
		}


		anim.SetFloat ("Speed", direction.magnitude);

		if (cc.isGrounded && Input.GetButton ("Jump")) {
			verticalVelocity = jumpSpeed;
		}
	}
	void FixedUpdate(){
		Vector3 dist = direction * speed * Time.deltaTime;
		if (cc.isGrounded && verticalVelocity < 0) {
			//anim.SetBool ("Jumping", false);
			verticalVelocity = Physics.gravity.y * Time.deltaTime;
		} else {
			if (Mathf.Abs(verticalVelocity) > jumpSpeed*0.75){
				//anim.SetBool ("Jumping", true);
			}
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		}
		dist.y = verticalVelocity;
		cc.Move (dist);
	
	}
	private void RotateView(){
		m_MouseLook.LookRotation (transform, m_Camera.transform);

	}

}
