using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;

namespace ModTest
{
    // ID(他のMODと重複不可), 名前(自由), バージョン番号(自由)
    [BepInPlugin("org.phantasmagolia.modtest","DenD MOD Test","1.0.0.0")]
    public class MainClass : BaseUnityPlugin
    {
        void Awake()
        {
            Logger.LogInfo("MOD Test Ver.1.0.0.0");
            Harmony harmony = new Harmony("org.phantasmagolia.modtest");
            MethodInfo original = AccessTools.Method(typeof(UVBody), "ChangeForTex");
            MethodInfo patch = AccessTools.Method(typeof(MainClass), "ChangeForTex_Patch");
            harmony.Patch(original, new HarmonyMethod(patch));
            
        }
        public static void ChangeForTex_Patch(int no)
        {
            // Logger.LogInfo("UVBody.ChangeForTex Injected!");
            UnityEngine.Debug.Log("UVBody.ChangeForTex Injected!");
        }
    }
}