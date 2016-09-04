using UnityEngine;
using System.Collections;

namespace com.playspal.core.utils.helpers
{
    public class UnityMeshHelper
    {
        public static Mesh CreatePlane(float width = 1.0f, float height = 1.0f)
        {
            Vector3 center = new Vector3(width * 0.5f, height * 0.5f);

            Vector3[] vertices = new Vector3[]
            {
                new Vector3(0, 0) - center,
                new Vector3(width, 0) - center,
                new Vector3(0, height) - center,
                new Vector3(width, height) - center
            };

            Vector2[] uv = new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

            int[] triangles = new int[] { 2, 1, 0, 1, 3, 2 };

            Mesh mesh = new Mesh();

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}
