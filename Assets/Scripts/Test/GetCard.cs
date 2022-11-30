using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCard : MonoBehaviour
{
    // Start is called before the first frame update
    public Button resetbtn;
    public Card card;

    public Text nameText;
    public Text DescriptionText;
    public Image CardImg;
    public Text atkText;
    public Text hpText;
    public Text manaCostText;

    void Start()
    {
       resetbtn.GetComponent<Button>().onClick.AddListener(delegate {
           card.attack = Random.Range(1, 5);
           card.health = Random.Range(1, 5);
           card.manaCost = Random.Range(1, 5);
       });
    }

    // Update is called once per frame
    void Update()
    {
        CardImg.sprite = card.CardIcon;
        nameText.text = card.NameCard;
        DescriptionText.text = card.Description;
        atkText.text = card.attack.ToString();
        hpText.text = card.health.ToString();
        manaCostText.text = card.manaCost.ToString();

    }
}
