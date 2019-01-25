using UnityEngine;

public class ProCam : MonoBehaviour {

	public Transform pos;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void FixedUpdate() {
		
		Vector3 desiredPos = pos.position + offset;
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed*Time.deltaTime);
		transform.position = smoothedPos;

		transform.LookAt (pos);
	}
}
