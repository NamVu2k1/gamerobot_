using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Card", menuName = "New Card")]
public class Card : ScriptableObject
{
    // Start is called before the first frame update
    public string NameCard;
    public string Description;
    public Sprite CardIcon;
    public int attack;
    public int health;
    public int manaCost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
