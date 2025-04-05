sampler uImage0 : register(s0);
sampler uImage1 : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float uOpacity;
float uSaturation;
float uRotation;
float uTime;
float4 uSourceRect;
float2 uWorldPosition;
float uDirection;
float3 uLightSource;
float2 uImageSize0;
float2 uImageSize1;
float2 uTargetPosition;
float4 uLegacyArmorSourceRect;
float2 uLegacyArmorSheetSize;
float2 uScreenResolution;
float2 uScreenPosition;

float4 Rotate(sampler Tex, float2 UV, float2 Center, float Angle)
{
    float ang = Angle * 3.14 * 2;

    float2 angle1 = float2(sin(ang), cos(ang));
    float2 angle2 = float2(cos(ang), -sin(ang));
    //I had the UV as a single number var by accident**

    float2 preDot = -Center + UV;

    float dot1 = dot(preDot, angle2);
    float dot2 = dot(preDot, angle1);

    float2 preRot = float2(dot1, dot2);
    float2 rot = Center + preRot;
    
    return tex2D(Tex, rot);
}

float4 FilterMyShader(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
    float2 UV = coords;
    float2 Center = (uTargetPosition - uScreenPosition) / uScreenResolution;
    UV.x *= uScreenResolution.x / uScreenResolution.y;
    Center.x *= uScreenResolution.x / uScreenResolution.y;
    float power = 0.7; //between 0.1 - 10.0 def 1.2
    float radius = 0.6; //between 0.1 - 1.0 def 9.3

    float dist = distance(Center, UV);
    float warp = clamp(0.25 - pow(dist / radius, 5.0), 0, 1.0);
    //float warp = pow(dist / radius, 5.0);
    float zoom = pow(warp, 1.0 / power);
    
    
    //float theintensity = abs(sin(uTime)); // * 1.5 + 0.5
    float pie = 3.14159265358979323846264338327950;
    float theta = (uTime * 0.02) % (pie * 2);
    float2 wave = float2(0, 0);
    float2 rotUV = float2(0, 0);
    if (dist < radius)
    {
        //adding will bulge, subtracting will shrink
        coords -= zoom * (Center - UV);
        //wave = float2(sin(uTime + coords.y * 22) * 0.025 * (radius - dist), 0);
        
        rotUV = Rotate(uImage2, coords, Center, theta);
        //rotUV.x *= uScreenResolution.x / uScreenResolution.y;
        float4 Swirl = (tex2D(uImage1, rotUV) / 5) + tex2D(uImage2, rotUV);
        wave = (Center - rotUV) * 2 * (Swirl.r - 0.25);
    }
    
    
    float4 color = tex2D(uImage0, coords - wave * abs(0.9 - 1.6 * distance(rotUV, Center)));
    if (coords.x > uTargetPosition.x)
        color *= float4(0.6, 0.5, 0.8, 1.0);
    return color * float4(uColor, dist + 0.2) + tex2D(uImage2, rotUV) * 0.2;
}



technique Technique1
{
    pass Fard
    {
        PixelShader = compile ps_2_0 FilterMyShader();
    }
}
