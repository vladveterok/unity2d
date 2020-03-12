using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthScreen : MonoBehaviour
{
    Player player;
    TextMeshProUGUI healthScreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        healthScreen = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.GetPlayersHealth() < 0)
        {
            healthScreen.text = "0";
        } else
        {
            healthScreen.text = player.GetPlayersHealth().ToString();
        }
    }
}
