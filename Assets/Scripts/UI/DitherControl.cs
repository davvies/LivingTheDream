using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

/// <summary> Class <c>DitherControl</c> Functionality using the post processing shader </summary>
/// **NOTE** - Post processing library used from https://github.com/keijiro/Kino
public class DitherControl : MonoBehaviour
{
    public Binary shader; //on occasion events require access to the shader
	
	//references to title screens
    [SerializeField] Canvas preDay = default;
    [SerializeField] Canvas postDay = default;
    [SerializeField] Canvas endDay = default;
	
	//different colours used for blending on certain screens
    public Color black = new Color(0.42f, 0.42f, 0.42f);
    public Color gray = new Color(0.45f, 0.44f, 0.44f);
    public Color darkBlack = new Color(0.16f, 0.16f, 0.16f);
	
    Color secondary; //cached standard colour

    void Start()
    {
        secondary = shader.color1;
		
        shader.color0 = gray; //default color of shader 
    }

    void Update()
    {
        if (!endDay.isActiveAndEnabled) 
        {
            if (preDay.isActiveAndEnabled || postDay.isActiveAndEnabled && shader.color0 != black)
				
                shader.color0 = black; //change to dark given the pre day is active
			
			shader.color1 = shader.color1 == gray ? secondary : gray; //secondary colour update
			
        } else if(shader.color0 != darkBlack) 
        {
            shader.color0 = darkBlack; //primary shader colour is dark
        }
    }

}
