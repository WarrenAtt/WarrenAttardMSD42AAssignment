using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.4f;

    // The Material from the texture
    Material myMaterial;

    // Movement offset
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        //get the Material of the background from Renderer component
        myMaterial = GetComponent<Renderer>().material;

        //move in the y-axis at the given speed
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //move the texture of the Material by the offset every frame
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
