using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public GameObject playerPanel;
    private CameraManager cameraManager;
    GameObject[] players;
    private GameObject currPlayer;
    private bool wasSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraManager = camera.GetComponent<CameraManager>();
        players = GameObject.FindGameObjectsWithTag("PlayerOnMap");
        playerPanel.SetActive(false);

        wasSelected = false;
    }       

    // Update is called once per frame
    void Update()
    {
        foreach(var player in players){
            if (player.GetComponent<HouseMapManager>().isSelected())
            {
                cameraManager.setCameraMove(player.GetComponent<Transform>());
                playerPanel.SetActive(true);
                if (currPlayer)
                {
                    currPlayer.GetComponent<HouseMapManager>().planeText.SetActive(false);
                }
                currPlayer = player;
                currPlayer.GetComponent<HouseMapManager>().planeText.SetActive(true);
                wasSelected = true;
            }
        }
        
        if (Input.GetMouseButton(0)) 
        {
            if (!cameraManager.isCamMoving() && wasSelected)
            {
                playerPanel.SetActive(false);
                currPlayer.GetComponent<HouseMapManager>().planeText.SetActive(false);
                wasSelected = false;
            }   
        }
    }
}
