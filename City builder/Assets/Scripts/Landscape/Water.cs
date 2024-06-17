using TMPro;
using UnityEngine;

namespace CityBuilder.Terrains.C01
{
    public class Water : Landscape
    {
        public override void Generate()
        {
            GameObject water = GameObject.CreatePrimitive(PrimitiveType.Plane);

            water.transform.position = new Vector3(0, 250, 0);
            water.transform.localScale = new Vector3(Size.x, 0, Size.y);

            water.GetComponent<MeshRenderer>().SetMaterials(Materials);
        }
    }
}