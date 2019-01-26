using UnityEngine;

public class MainCam : MonoBehaviour {

	public Transform playerPos;
	//Set offset in editor	
	public Vector3 offset;
    public float offsetRight = 10;
    public float offsetUp = 5;


	// Update is called once per frame
	void Update () {
        transform.forward = -1 * playerPos.right;
        transform.position = playerPos.position + playerPos.right * offsetRight + playerPos.up * offsetUp;
        transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 30.0f);
    }
}
