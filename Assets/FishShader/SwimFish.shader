﻿Shader "Custom/SwimFish"{
   Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white" {}
        _Wave("Wave",float) = 0.01
    }
 
    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100
 
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha 
 
        Pass {  
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fog

                
 
                #include "UnityCG.cginc"
 
                struct appdata_t {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                };
 
                struct v2f {
                    float4 vertex : SV_POSITION;
                    half2 texcoord : TEXCOORD0;
                    UNITY_FOG_COORDS(1)
                };

 
                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed4 _Color;
                float _Wave;
 
                v2f vert (appdata_t v){
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                    float amp = _Wave*sin(_Time * 100 + v.vertex.x * 1000);
					o.vertex.xyz = float3(o.vertex.x + amp, o.vertex.y, o.vertex.z);

                    UNITY_TRANSFER_FOG(o,o.vertex);
                    return o;
                }


 
                fixed4 frag (v2f i) : SV_Target {
                    fixed4 col = tex2D(_MainTex, i.texcoord) * _Color;
                    UNITY_APPLY_FOG(i.fogCoord, col);
                    return col;
                }

            ENDCG
        }
    }
}