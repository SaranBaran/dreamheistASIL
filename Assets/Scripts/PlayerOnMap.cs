using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class HouseMapManager : MonoBehaviour
{
    public GameObject planeText;
    public float dragSpeed = 2;
    private PlayerDataManager playerDataManager;
    private bool selected;


    void Start()
    {
        playerDataManager = GetComponent<PlayerDataManager>();
        planeText.SetActive(false);
    }

    void Update()
    {

    }
    void OnMouseExit()
    {
        selected = false;
    }
    void OnMouseOver()
    {
        //startcolor = renderer.material.color;
        //renderer.material.color = Color.green;
        
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (Input.GetMouseButtonDown(0)) {
              selected = true;
              //TIKLANINCA OLANLAR BURAYA KONULUR
              playerDataManager.updateCanvas();
        }
        
    }

    public bool isSelected()
    {
        return selected;
    }
}