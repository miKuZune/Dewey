using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public GameObject player;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    Vector3 offset;
    // Use this for initialization
    void Start ()
    {
		if(player == null){player = GameObject.FindGameObjectWithTag("Player");}

        offset = Vector3.zero;
        offset.x = offsetX;
        offset.y = offsetY;
        offset.z = offsetZ;

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
	}
}
