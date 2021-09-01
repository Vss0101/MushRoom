// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|emission-7231-OUT;n:type:ShaderForge.SFN_Tex2d,id:7818,x:32365,y:32943,ptovrint:False,ptlb:texture,ptin:_texture,varname:node_7818,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-1173-OUT;n:type:ShaderForge.SFN_Color,id:7144,x:32424,y:32712,ptovrint:False,ptlb:color,ptin:_color,varname:node_7144,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_VertexColor,id:2534,x:32617,y:33146,varname:node_2534,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8005,x:32868,y:32861,varname:node_8005,prsc:2|A-7144-RGB,B-7818-RGB,C-2534-RGB,D-6194-RGB;n:type:ShaderForge.SFN_Tex2d,id:6194,x:32554,y:32498,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_6194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:7901,x:31853,y:33201,varname:node_7901,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:2300,x:31390,y:32934,varname:node_2300,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:2743,x:31429,y:32844,ptovrint:False,ptlb:U_move,ptin:_U_move,varname:node_2743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:3163,x:31409,y:33111,ptovrint:False,ptlb:V_move,ptin:_V_move,varname:_U_move_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:9464,x:31622,y:32882,varname:node_9464,prsc:2|A-2743-OUT,B-2300-T;n:type:ShaderForge.SFN_Multiply,id:2659,x:31622,y:33039,varname:node_2659,prsc:2|A-2300-T,B-3163-OUT;n:type:ShaderForge.SFN_Append,id:1116,x:31873,y:32859,varname:node_1116,prsc:2|A-9464-OUT,B-2659-OUT;n:type:ShaderForge.SFN_Add,id:1173,x:32049,y:33020,varname:node_1173,prsc:2|A-1116-OUT,B-7901-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5623,x:32865,y:33051,varname:node_5623,prsc:2|A-7818-A,B-2534-A,C-7144-A,D-6194-A;n:type:ShaderForge.SFN_Multiply,id:7231,x:33012,y:32941,varname:node_7231,prsc:2|A-8005-OUT,B-5623-OUT;proporder:7818-7144-6194-2743-3163;pass:END;sub:END;*/

Shader "FN/Masked Move Add" {
    Properties {
        _texture ("texture", 2D) = "white" {}
        [HDR]_color ("color", Color) = (0.5,0.5,0.5,1)
        _mask ("mask", 2D) = "white" {}
        _U_move ("U_move", Float ) = 0
        _V_move ("V_move", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _color)
                UNITY_DEFINE_INSTANCED_PROP( float, _U_move)
                UNITY_DEFINE_INSTANCED_PROP( float, _V_move)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _color );
                float _U_move_var = UNITY_ACCESS_INSTANCED_PROP( Props, _U_move );
                float4 node_2300 = _Time;
                float _V_move_var = UNITY_ACCESS_INSTANCED_PROP( Props, _V_move );
                float2 node_1173 = (float2((_U_move_var*node_2300.g),(node_2300.g*_V_move_var))+i.uv0);
                float4 _texture_var = tex2D(_texture,TRANSFORM_TEX(node_1173, _texture));
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float3 emissive = ((_color_var.rgb*_texture_var.rgb*i.vertexColor.rgb*_mask_var.rgb)*(_texture_var.a*i.vertexColor.a*_color_var.a*_mask_var.a));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
