using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue : MonoBehaviour
{

    public Collider2D player,cursewhite1,ifpaqiang,ifheidong;
    public GameObject tishi,heidong,paqiang,initial;//获取刚体
    void FixedUpdate()
    {
        if(player.IsTouching(cursewhite1))
        {
            tishi.SetActive(true);
            initial.SetActive(false);
            paqiang.SetActive(false);
            heidong.SetActive(false);
        }
        if(player.IsTouching(ifheidong))
        {
            heidong.SetActive(true);
            tishi.SetActive(false);
            paqiang.SetActive(false);
            initial.SetActive(false);
        }
        if(player.IsTouching(ifpaqiang))
        {
            paqiang.SetActive(true);
            tishi.SetActive(false);
            heidong.SetActive(false);
            initial.SetActive(false);
        }
    }
}
