using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButttonScript : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if(PlayerJumpScript.instance!=null)
        {
            PlayerJumpScript.instance.SetPower(true);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PlayerJumpScript.instance != null)
        {
            PlayerJumpScript.instance.SetPower(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
