using System;
using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Reflection;
using BepInEx.Logging;
using ValheimBiggerChests.Patches;

namespace ValheimBiggerChests
{
    public static class PluginInfo
    {
        public const string Name = "ValheimBiggerChests";
        public const string Guid = "Franzi." + Name;
        public const string Version = "0.0.1";
    }


    [BepInPlugin(PluginInfo.Guid, PluginInfo.Name, PluginInfo.Version)]
    public class Main : BaseUnityPlugin
    {
        public const string
            MODNAME = PluginInfo.Name,
            AUTHOR = "Franzi",
            GUID = AUTHOR + "_" + MODNAME,
            VERSION = PluginInfo.Version;
        internal readonly Assembly assembly;
        internal readonly Harmony harmony;
        public readonly string modFolder;
        public Main()
        {
            harmony = new Harmony("mod." + PluginInfo.Name);
            assembly = Assembly.GetExecutingAssembly();
            modFolder = Path.GetDirectoryName(assembly.Location);
        }
        void Awake()
        {
            Logger.LogInfo("Loaded " + PluginInfo.Name + " version " + PluginInfo.Version);
            harmony.PatchAll(assembly);
            Patches.ContainerPatches.personalChest = (Width: base.Config.Bind<uint>(MODNAME, "Personal Chest Width", Patches.ContainerPatches.personalChest.Width, "Width of personal chest.").Value,
                Height: base.Config.Bind<uint>(MODNAME, "Personal Chest Height", Patches.ContainerPatches.personalChest.Height, "Height of personal chest.").Value);
            Patches.ContainerPatches.standardChest = (Width: base.Config.Bind<uint>(MODNAME, "Standard Chest Width", Patches.ContainerPatches.standardChest.Width, "Width of standard chest.").Value,
                Height: base.Config.Bind<uint>(MODNAME, "Standard Chest Height", Patches.ContainerPatches.standardChest.Height, "Height of standard chest.").Value);
             Patches.ContainerPatches.reinforcedChest = (Width: base.Config.Bind<uint>(MODNAME, "Reinforced Chest Width", Patches.ContainerPatches.reinforcedChest.Width, "Width of reinforced chest.").Value,
                Height: base.Config.Bind<uint>(MODNAME, "Reinforced Chest Height", Patches.ContainerPatches.reinforcedChest.Height, "Height of reinforced chest.").Value);

        }

        private void OnDestroy()
        {
            harmony.UnpatchAll();
        }
    }

}