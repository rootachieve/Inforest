using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public RectTransform healthbar;//Health bar represented by UI in canvas
    public PlayerState PS;//Player State;
    private void FixedUpdate()//Change the scale of the square to show Player health  (Scale Max == 1.0f)
    {
        if (healthbar.localScale.x > ((float)PS.health / (float)PS.maxHealth))//If the scale of the square is greater than (now Health / max Health)  
        {
            healthbar.localScale = new Vector3(healthbar.localScale.x - 0.01f, healthbar.localScale.y, healthbar.localScale.z);//Slowly decreasing
        }
        else
        {
            healthbar.localScale = new Vector3(((float)PS.health / (float)PS.maxHealth), healthbar.localScale.y, healthbar.localScale.z);//The increase in health is immediately reflected
        }
    }
}
