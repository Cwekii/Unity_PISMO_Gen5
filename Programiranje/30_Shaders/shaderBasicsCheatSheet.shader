// *****************
// Types of Shaders:

// * Surface Shader: 
//     lit shaders that affect lighting of an object

// * Unlit Shader:
//     vertex and fragment shader, control vertex properties

// * Image Effect Shader:
//     full screen effects, post-processing effects, bloom, night vision, rain, etc.

// * Compute Shader
//     arbitrary computing tasks running outside of the rendering pipeline; could be used for 
//     rendering but mostly used for massively parallel GPGPU algorithms not related to rendering


// ****************
// Shader Structure

Shader "MenuGroup/NameOfShader"
{
	Properties 
	{
		// properties are accessible via Unity inspector or script
	}
  
	SubShader
	{
		// shader code (CG syntax)
    
		Pass 
		{
			CGPROGRAM

			ENDCG
		}
	}
  
	SubShader
	{
		// can have multiple sub-shaders, one for mobile, or for lower performance machines, etc.
	}
  
	// can fallback to another shader
	Fallback "Diffuse" 
}


// *****************
// Shader Properties

// color property (red, green, blue, alpha)
// _Color("Color Tint", Color) = (1, 1, 1, 1)

// texture property
// _Texture("My Texture", 2D) = "white" {}

// normal map property
// _NormalMap("My Normal", 2D) = "bump" {}

// distance property
// _Distance("My Distance", Range(0, 1)) = 1

// distortion property
// _Distortion("My Distortion", Float) = 3

// vector property
// _PositionVector("My Position", Vector) = (0,0,0,0)


// *************
// Packed arrays

// * Swizzling
//     allows re-arranging values 
//       Float4 vec1 = (1, 2, 3, 4);
//       Float2 vec2 = vec1.zy; // 3, 2
//       Float3 vec3 = vec1.xxy; // 1, 1, 2
//       Float scalar = vec1.y; // 2

// * Smearing
//     allows setting a single value to all positions in the array
//       Float3 vec3 = 1; // (1, 1, 1)

// * Masking
//     allows replacing values in packed arrays
//       Float2 vec1 = (1, 2);
//       Float4 vec2 = (5, 6, 3, 4);
//       vec2.xy = vec1; // 1, 2, 3, 4  


// *************
// Numeric Types

// * Float
//     32bit precision
//       - world space positions
//       - texture coordinates
//       - scalar computations

// * Fixed
//     16bit precision
//       - short vectors
//       - directions
//       - object space positions
//       - high dynamic range colors

// * Half
//     11bit precision (-2, 2)
//       - regular colors
//       - simple operations

// * Integer
//     not supported on Direct 3D 9, OpenGL ES 2.0 
//       - loops
//       - array indices


// ***********
// Shader Tags

// * Queue
//     determines when an object should be rendered (0-5000)
//       - background (1000)
//       - geometry (2000)
//       - alpha test (2450), used for grass or cutout textures
//       - transparent (3000), used for glass or particle effects
//       - overlay (4000), used for lens flares, etc.

// * Render Type 
//     used with replacement shaders to specify specific shaders to be replaced by a tag


// *********************************
// Surface Shader Example w/ Texture

Shader "SurfaceShaderExample" 
{	
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert

		struct Input 
		{
			float2 uv_MainTex;				
		};

		sampler2D _MainTex;

		void surf (Input IN, inout SurfaceOutput o)
		{
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;				
		}

		ENDCG
	}
}


// *****************************
// Unlit Shader Example w/ Color

Shader "UnlitShaderExample"
{
	Properties 
	{
		_Color("My Color", Color) = (1, 1, 1, 1)
	}

	Subshader 
	{
		Pass 
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct vertInput
			{
				float4 pos : POSITION;
			};

			struct vertOutput 
			{
				float4 pos : SV_POSITION;
			};

			half4 _Color; 

			vertOutput vert (vertInput i)
			{
				vertOutput o;
				// convert object space to screen space
				o.pos = UnityObjectToClipPos(i.pos);
				return o;
			}

			half4 frag (vertOutput o) : COLOR
			{
				//return half4(1, 0, 0, 1);
				return _Color;
			}

			ENDCG
		}
	}
}


// *********************************
// Image Effect Shader Example
// 	blends two textures together

Shader "ImageEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BlendTex("Blend Texture", 2D) = "white" {}
		_Blend("Blend Amount", Range(0,1)) = 0.5
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"			
			
			sampler2D _MainTex;
			sampler2D _BlendTex;
			fixed _Blend;

			fixed4 frag (v2f_img i) : COLOR
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				fixed4 blendTex = tex2D(_BlendTex, i.uv);

				// linear interpolation
				fixed4 finalTex = lerp(renderTex, blendTex, _Blend);
				return finalTex;
			}
			ENDCG
		}
	}
}


// *****************************************************************
// Image Effect Shader Script to Tie Shader to Unity's Camera System

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFX : MonoBehaviour 
{
	public Material material;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, material);
	}
}


// **********
// References

// * Unity ShaderLab syntax:
//      https://docs.unity3d.com/Manual/SL-Shader.html

// * HLSL 
//     https://en.wikipedia.org/wiki/High-Level_Shading_Language

// * GLSL
//     https://en.wikipedia.org/wiki/OpenGL_Shading_Language

// * CG syntax
//     https://developer.nvidia.com/cg-toolkit

// * Unity Shader tutorials 
//     https://www.cgcookie.com/

// * Unity Shader Graph
//     https://blogs.unity3d.com/2018/02/27/introduction-to-shader-graph-build-your-shaders-with-a-visual-editor/