using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the texture scrolling of multilevel backgrounds
public class BackgroundScroller : MonoBehaviour
{
    //List of all backgrounds from lower to higher
    public List<MeshRenderer> backgrounds;

    //How much more transparent every other layer is
    [Range(0.1f, 0.9f)]
    public float alphaFactor = 0.8f;

    //How much slower every other layer moves
    [Range(0, 10)]
    public int parallaxFactor = 0;

    //Scroll all textures
    void ScrollAll()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            Scroll(backgrounds[i].material, Mathf.FloorToInt(Mathf.Pow(2, backgrounds.Count - i + parallaxFactor)));
        }
    }

    //Scroll one texture depending on our parents position
    void Scroll(Material mat, int parallax)
    {
        mat.mainTextureOffset = transform.position / parallax * 0.1f;
    }

    //Set background alphas and render positions
    void SetAlphas()
    {
        for(int i = 0; i < backgrounds.Count; i++)
        {
            if (backgrounds[i] == null)
                continue;
            backgrounds[i].transform.position = new Vector3(transform.position.x, transform.position.y, backgrounds.Count - i);
            Material mat = backgrounds[i].sharedMaterial;
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, Mathf.Pow(alphaFactor, i));
        }
    }

    void Update()
    {
        ScrollAll();
    }

    private void Awake()
    {
        SetAlphas();
    }

    private void OnValidate()
    {
        SetAlphas();
    }
}
