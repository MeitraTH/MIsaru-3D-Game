using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinner : MonoBehaviour
{
    public Camera defaultCamera;
    public Camera winnerCamera;
    public bool isWinner = false;

    public Transform target;
    public float smoothSpeed = 1.0f;

    public static CheckWinner instance;

    public Transform playerRotaion;

  

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
    defaultCamera.enabled = true;
    winnerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWinner)
        {
            defaultCamera.enabled = false;
            winnerCamera.enabled = true;
        }
    }

    private void LateUpdate()
    {
        if (target != null && isWinner)
        {
            Vector3 desiredPosition = new Vector3(target.position.x - 3.0f , target.position.y, target.position.z);

            Vector3 smoothedPosition = Vector3.Lerp(winnerCamera.transform.position,desiredPosition
                ,smoothSpeed * Time.deltaTime);
            winnerCamera.transform.position = smoothedPosition;

          //  playerRotaion.LookAt(new Vector3(Lookat.transform.position.x, Lookat.transform.position.y,
            // Lookat.transform.position.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerController.instance.groundPlayer)
        {
            isWinner = true;       
        }
    }
}
