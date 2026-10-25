using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(offset == Vector3.zero && player != null)
        {
            offset = transform.position - player.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = player.position + offset;
        }
        
    }
}
