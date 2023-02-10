using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer laserLine;
    public float MainTextureLength = 1f;
    public float NoiseTextureLength = 1f;
    private Vector4 Length = new Vector4(1, 1, 1, 1);

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        laserLine.material.SetTextureScale("_MainTex", new Vector2(Length[0], Length[1]));
        laserLine.material.SetTextureScale("_Noise", new Vector2(Length[2], Length[3]));
    }

    public void Tile(float distance)
    {
        Length[0] = MainTextureLength * distance;
        Length[2] = NoiseTextureLength * distance;
    }
}
