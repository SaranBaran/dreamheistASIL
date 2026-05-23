using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHouse", menuName = "Scriptable Objects/PlayerHouse")]
public class PlayerHouse : ScriptableObject
{
    public string playerName;
    public string playerPhrase;
    public Sprite houseSprite; 
    //belki her yeni hou\se icin sign
    public int currency;
    public int timeToRob;
}
