using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [Range(0, 2)]
    [SerializeField] int difficulty;
    [SerializeField]float animationSpeed = 0.25f;
    // Start is called before the first frame update
    private void Awake()
    {
        if (difficulty==0)
        {
            animationSpeed = 0.25f;
        }
        else if (difficulty == 1)
        {
            animationSpeed = 0.35f;
        }
        else if (difficulty == 2)
        {
            animationSpeed = 0.5f;
        }
        meshRenderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed*Time.deltaTime,0);
    }
}
