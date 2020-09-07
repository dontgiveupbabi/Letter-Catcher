using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
 
    private Vector3 initialPos;
    private Vector3 targetPos;
    float offsetz;
    private float offsety;
    public float smoothnessFactor;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        offsetz = player.transform.position.z - transform.position.z;
        offsety = player.transform.position.y - transform.position.y;
    }
    
    
    // Update is called once per frame
    void Update()
    {
       targetPos = new Vector3(initialPos.x,player.transform.position.y-offsety,
            player.transform.position.z-offsetz);
        
        transform.position = Vector3.Lerp(transform.position,targetPos,Time.deltaTime*smoothnessFactor);
       // transform.position=new Vector3(initialPos.x, player.transform.position.y-offsety,player.transform.position.z-offsetz);
    }
}
