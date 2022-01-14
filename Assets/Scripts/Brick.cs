using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;

    private int m_PointValue;
    public int PointValue
    {
        get { return m_PointValue; }
        set
        {
            m_PointValue = m_PointValue < 1 ? 1 : value;
            var renderer = GetComponentInChildren<Renderer>();
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            switch (value)
            {
                case 1:
                    block.SetColor("_Color", Color.green);
                    break;
                case 2:
                    block.SetColor("_Color", Color.yellow);
                    break;
                case 5:
                    block.SetColor("_Color", Color.blue);
                    break;
                default:
                    block.SetColor("_Color", Color.red);
                    break;
            }
            renderer.SetPropertyBlock(block);
        }
    }

    protected MainManager mainManager;

    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        mainManager.bricksLeft--;

        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
