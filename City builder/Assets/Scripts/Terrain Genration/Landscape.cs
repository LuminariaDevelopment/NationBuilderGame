using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

namespace CityBuilder.Terrains.C01
{
    public abstract class Landscape : LandscapeData
    {
        public abstract void Generate();
    }
}
