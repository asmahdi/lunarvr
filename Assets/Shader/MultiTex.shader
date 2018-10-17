Shader "Olik/4-Part MultiTexture" {  
    Properties {  
        _MainTex0 ("Base (RGB)", 2D) = "white" {}  
        //Added three more textures slots, one for each image  
        _MainTex1 ("Base (RGB)", 2D) = "white" {}  
        _MainTex2 ("Base (RGB)", 2D) = "white" {}  
        _MainTex3 ("Base (RGB)", 2D) = "white" {}  
        _MainTex4 ("Base (RGB)", 2D) = "white" {}  
        _MainTex5 ("Base (RGB)", 2D) = "white" {}  
        _MainTex6 ("Base (RGB)", 2D) = "white" {}  
        _MainTex7 ("Base (RGB)", 2D) = "white" {}  

    }  
    SubShader {  
        Tags { "RenderType"="Opaque" }  
        LOD 200  
  
        CGPROGRAM  
        #pragma surface surf Lambert  
  
        sampler2D _MainTex0;  
        sampler2D _MainTex1;  
        sampler2D _MainTex2;  
        sampler2D _MainTex3;  
        sampler2D _MainTex4; 
        sampler2D _MainTex5; 
        sampler2D _MainTex6; 
        sampler2D _MainTex7; 

  
        struct Input {  
            float2 uv_MainTex0;  
        };  
  
        //this variable stores the current texture coordinates multiplied by 2  
        float2 dbldbl_uv_MainTex0;  
  
        void surf (Input IN, inout SurfaceOutput o) {  
  
            //multiply the current vertex texture coordinate by two  
            dbldbl_uv_MainTex0 = IN.uv_MainTex0*4;  
  
            //add an offset to the texture coordinates for each of the input textures  

            half4 c0 = tex2D (_MainTex0, dbldbl_uv_MainTex0 - float2(0.0, 1.0));  
            half4 c1 = tex2D (_MainTex1, dbldbl_uv_MainTex0 - float2(1.0, 1.0));  
            half4 c2 = tex2D (_MainTex2, dbldbl_uv_MainTex0- float2(2.0, 1.0));    
            half4 c3 = tex2D (_MainTex3, dbldbl_uv_MainTex0 - float2(3.0, 1.0));  

            half4 c4 = tex2D (_MainTex4, dbldbl_uv_MainTex0 - float2(0.0, 0.0));  
            half4 c5 = tex2D (_MainTex5, dbldbl_uv_MainTex0 - float2(1.0, 0.0));  
            half4 c6 = tex2D (_MainTex6, dbldbl_uv_MainTex0- float2(2.0, 0.0));    
            half4 c7 = tex2D (_MainTex7, dbldbl_uv_MainTex0 - float2(3.0, 0.0));
  
            //this if statement assures that the input textures won't overlap  
            if(IN.uv_MainTex0.x >= 0.5)  
            {  
                if(IN.uv_MainTex0.y <= 0.5)  
                {  
                    c0.rgb = c1.rgb = c2.rgb = 0;  
                }  
                else  
                {  
                    c0.rgb = c2.rgb = c3.rgb = 0;  
                }  
            }  
            else  
            {  
                if(IN.uv_MainTex0.y <= 0.5)  
                {  
                    c0.rgb = c1.rgb = c3.rgb = 0;  
                }  
                else  
                {  
                    c1.rgb = c2.rgb = c3.rgb = 0;  
                }  
            }  
  
            //sum the colors and the alpha, passing them to the Output Surface 'o'  
            o.Albedo = c0.rgb + c1.rgb + c2.rgb + c3.rgb+ c4.rgb + c5.rgb + c6.rgb + c7.rgb; 
            o.Alpha = c0.a + c1.a + c2.a + c3.a ;  
        }  
        ENDCG  
    }  
    FallBack "Diffuse" 
}