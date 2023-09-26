using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    Transform cam;

    [SerializeField]
    float speed;

    Vector3 mov;

    // Start is called before the first frame update
    void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.z = Input.GetAxisRaw("Vertical");

        this.transform.Translate(mov * Time.deltaTime * speed);

        transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X");
        cam.eulerAngles += Vector3.left * Input.GetAxis("Mouse Y");
    }
}
