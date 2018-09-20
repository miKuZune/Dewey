using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public GameObject player;

    public float offsetX;
    public float offsetY;

    Vector3 offset;
    // Use this for initialization
    void Start ()
    {
		if(player == null){player = GameObject.FindGameObjectWithTag("Player");}

        offset = Vector3.zero;
        if (offsetX == 0) { offset.x = -5; } else { offset.x = offsetX; }
        if (offsetY == 0) { offset.y = 5; } else { offset.y = offsetY; }

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
	}
}
