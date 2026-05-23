using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    private CameraManager cameraManager;
    GameObject[] players;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraManager = camera.GetComponent<CameraManager>();
        players = GameObject.FindGameObjectsWithTag("PlayerOnMap");
    }       

    // Update is called once per frame
    void Update()
    {
        foreach(var player in players)
            if (player.GetComponent<HouseMapManager>().isSelected())
            {
                
            }
        ;
    }
}
