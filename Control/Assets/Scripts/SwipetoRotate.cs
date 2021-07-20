using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipetoRotate : MonoBehaviour
{

	public Joystick joystick; 
	public float rotateHorizontal;
	public float rotateVertical;

	public Quaternion originalRotationValue; //reset the object position

	void Start(){
		originalRotationValue = transform.rotation;
	}

	public void FixedUpdate(){
		rotateHorizontal = joystick.Horizontal * 1; 
		rotateVertical = joystick.Vertical * 1;
		transform.Rotate(rotateVertical, rotateHorizontal, 0);
	}

	//bring the object to its starting position 
	public void ResetButton() {
		transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time);
	}

}
