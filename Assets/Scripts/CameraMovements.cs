using UnityEngine;

public class CameraMovements : MonoBehaviour {

    public Transform QueenPosition;
    public QueenController _QueenController;
  
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float cameraSpeed = (Time.deltaTime) * _QueenController.Speed / 2;
        transform.position = Vector2.Lerp(transform.position, QueenPosition.position, cameraSpeed);
        transform.position += Vector3.forward * -10;
	}
}
