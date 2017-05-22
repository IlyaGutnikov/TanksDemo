using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Camera camera;

    private GameObject objectToFollow;
    private Vector3 cameraOffset;
    void Awake()
    {
        objectToFollow = this.gameObject;
        cameraOffset = camera.transform.position - objectToFollow.transform.position;
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    camera.transform.position = objectToFollow.transform.position + cameraOffset;
	}
}
