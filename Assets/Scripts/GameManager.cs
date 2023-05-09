using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Color> KeyCards = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        GiveBlueKeyCard();
    }
    
    public void GiveBlueKeyCard()
    {
        KeyCards.Add(Color.blue);
    }

    public void GiveYellowKeyCard()
    {
        KeyCards.Add(Color.yellow);
    }

    public void GiveRedKeyCard()
    {
        KeyCards.Add(Color.red);
    }

    public void GiveGreenKeyCard()
    {
        KeyCards.Add(Color.green);
    }

    public bool HasColorCard(Color color)
    {
        if (KeyCards.Contains(color))
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
