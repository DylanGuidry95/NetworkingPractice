using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour
{
    GUIStyle healthStyle;
    GUIStyle backStyle;
    Combat combat;

    /// <summary>
    /// Sets combat equal to the current object this script is attached to if it has the Combat script also attached to it.
    /// </summary>
    void Awake()
    {
        combat = GetComponent<Combat>();
    }

    /// <summary>
    /// Calls in the InitStyles function and places the  GUIStyles at designated positions. 
    /// In this case they are placed over the player objects so the user can clearly see their remaining health.
    /// </summary>
    void OnGUI()
    {
        InitStyles();
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        GUI.color = Color.grey;
        GUI.backgroundColor = Color.grey;
        GUI.Box(new Rect(pos.x - 26, Screen.height - pos.y + 21, Combat.maxHP / 2, 5), ".", backStyle);

        GUI.color = Color.green;
        GUI.backgroundColor = Color.green;
        GUI.Box(new Rect(pos.x - 25, Screen.height - pos.y + 21, combat.HP / 2, 5), ".", healthStyle);
    }

    /// <summary>
    /// Assigns values to the healthStyle and backStyle. 
    /// Then when the function is called in through the OnGUI function they are placed in the world.
    /// </summary>
    void InitStyles()
    {
        if(healthStyle == null)
        {
            healthStyle = new GUIStyle(GUI.skin.box);
            healthStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 1.0f));
        }

        if (backStyle == null)
        {
            backStyle = new GUIStyle(GUI.skin.box);
            backStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 1.0f));
        }
    }

    /// <summary>
    /// Called in the InitStyles function to give a texture to a GUIStyle.
    /// </summary>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    Texture2D MakeTex(int w, int h, Color col)
    {
        Color[] pix = new Color[w * h];
        for(int i = 0; i < pix.Length; i++)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(w, h);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
