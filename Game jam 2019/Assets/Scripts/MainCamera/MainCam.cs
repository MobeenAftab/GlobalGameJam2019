using UnityEngine;

public class MainCam : MonoBehaviour {

	public Transform playerPos;
	//Set offset in editor	
	public Vector3 offset;

	// Update is called once per frame
	void Update () {
        transform.forward = -1 * playerPos.right;
        transform.position = playerPos.position + playerPos.right * 5.0f + playerPos.up * 3.0f;
    }
}
