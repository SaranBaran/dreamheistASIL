using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class HouseMapManager : MonoBehaviour
{
    public GameObject planeText;
    public GameObject panel;
    public Camera camera;
    private bool textOpened = false;

    void Start()
    {
        planeText.SetActive(false);
        panel.SetActive(false);
        textOpened = false;
    }

    void Update()
    {
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
              Vector3 velocity = new Vector3(1f, 1f, 1.1f);
              camera.transform.position = Vector3.SmoothDamp(camera.transform.position, transform.position, ref velocity, 1f);
        }
        
    }
}
