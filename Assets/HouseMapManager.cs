using UnityEngine;

public class HouseMapManager : MonoBehaviour
{
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (Input.GetMouseButtonDown(0)) {
              Debug.Log("GameObject Clicked.");
        }
    }
}
