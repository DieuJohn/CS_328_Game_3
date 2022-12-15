using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    public GameObject Player;
    public float fixedRotation = 0;

    void Update()
    {
        this.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 2);
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, fixedRotation);
    }
}
