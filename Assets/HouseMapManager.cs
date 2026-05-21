using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class HouseMapManager : MonoBehaviour
{
    public GameObject planeText;
    public GameObject panel;
    public Camera camera;
    private bool textOpened = false;
    public float dragSpeed = 2;
    private bool camMoving = false;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);


    void Start()
    {
        planeText.SetActive(false);
        panel.SetActive(false);
        textOpened = false;
    }

    void Update()
    {
        if (camMoving)
        {
            moveCamera();
        }
        if (Input.GetMouseButton(0))
        {
            if (!textOpened)
            {
                planeText.SetActive(false);
                panel.SetActive(false);
            }
        }
    }
    void OnMouseExit()
    {
        textOpened = false;
    }
    void OnMouseOver()
    {
        //startcolor = renderer.material.color;
        //renderer.material.color = Color.green;
        
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (Input.GetMouseButtonDown(0)) {
              planeText.SetActive(true);
              panel.SetActive(true);
              textOpened = true;
              Debug.Log("BASSS");
              //TIKLANINCA OLANLAR BURAYA KONULUR
              camMoving = true;
        }
        
    }
    void moveCamera()
    {
        //Vector3 target = new Vector3(transform.position.x + 30, camera.transform.position.y, 
        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, transform.position, ref velocity, 1f);
        if (Vector3.Distance(camera.transform.position, transform.position) < 0.01f)
        {
            camera.transform.position = transform.position;
            velocity = Vector3.zero;
            camMoving = false;
        }
    }
}