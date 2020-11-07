using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charCont : MonoBehaviour
{


    [SerializeField]
    float moveSpeed = 18f;
    Vector3 forward, right;
    Animator chr_anim;

    // Start is called before the first frame update
    void Start()
    {
        
        chr_anim = gameObject.GetComponent<Animator>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

            
            
            }

    // Update is called once per frame
    void Update()
    {
        chr_anim.SetFloat("vertical", 0);


        if (Input.anyKey)
        {
            Move();
        }
        
        void Move()
        {
            Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
            Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
            Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");


            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            transform.forward = heading;
            transform.position += rightMovement;
            transform.position += upMovement;
            chr_anim.SetFloat("vertical", 2);

        }
    }
}
