using UnityEngine;

public class MainCam : MonoBehaviour {

	public Transform playerPos;
	//Set offset in editor	
	public Vector3 offset;

	// Update is called once per frame
	void Update () {
		transform.position = playerPos.position + offset;
	}
}
