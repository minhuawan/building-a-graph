﻿input.type =  ;
input.nickname =  ;
input.text =  ;
input.price = =  ;
input.uid =  ;
input.anchor_id =  ;
input.event_time =  ;
input.event_send_time =  ;
input.gift =  ;
input.avatar =  ;
input.md5 =  ;



using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float Function(float x, float z, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple
    };

    private static Function[] functions = { Wave, MultiWave, Ripple };

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    public static float Wave(float x, float z, float t)
    {
        return Sin(PI * (x + z + t));
    }

    public static float MultiWave(float x, float z, float t)
    {
        float y = Sin(PI * (x + 0.5f * t));
        y += Sin(2f * PI * (z + t)) * 0.5f;
        y += Sin(PI * (x + z + 0.25f * t));
        return y * (1f / 2.5f);
    }

    public static float Ripple(float x, float z, float t)
    {
        float d = Sqrt(x * x + z * z);
        float y = Sin(4f * PI * d - t);
        return y / (1f + 10f * d);
    }
}