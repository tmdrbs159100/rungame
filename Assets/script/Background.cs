using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float ScrollSpeed;
    [SerializeField] Material Element;
    [SerializeField] Vector2 vec;
    private void Start() 
    {
        vec = new Vector2(0,0);
    }
    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        vec.x += ScrollSpeed * Time.deltaTime;
        vec.y = 0;
        Element.mainTextureOffset = vec;
    }
}
