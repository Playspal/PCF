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

            int[] triangles = new int[] { 2, 1, 0, 2, 3, 1 };

            Mesh mesh = new Mesh();

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.uv = uv;

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }

        public static Mesh CreateCircle(float radius = 1.0f, int items = 18)
        {
            Vector3[] vertices = new Vector3[360 / items + 2];
            int verticesLength = 0;

            int[] triangles = new int[vertices.Length * 3 + 3];
            int trianglesLength = 0;

            float angle;
            int i;

            vertices[verticesLength] = new Vector3(0, 0, 0);
            verticesLength++;

            for (i = 0; i < 360; i += items)
            {
                angle = (float)i / 180 * Mathf.PI;
                vertices[verticesLength] = new Vector3
                (
                    Mathf.Cos(angle) * radius,
                    Mathf.Sin(angle) * radius,
                    0
                );

                verticesLength++;
            }

            for (i = 0; i < verticesLength - 1; i++)
            {
                triangles[trianglesLength + 2] = 0;
                triangles[trianglesLength + 1] = i;
                triangles[trianglesLength + 0] = i + 1;

                trianglesLength += 3;
            }

            triangles[trianglesLength + 2] = 0;
            triangles[trianglesLength + 1] = verticesLength - 1;
            triangles[trianglesLength + 0] = 1;

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = triangles;

            return mesh;
        }

        public static Mesh CreateCircleAdvanced(float radiusOuter = 1.0f, float radiusInner = 0.5f, int items = 18)
        {
            Vector3[] vertices = new Vector3[360 / items * 2];
            int verticesLength = 0;

            int[] triangles = new int[vertices.Length * 3 + 3];
            int trianglesLength = 0;

            int i;
            float angle;

            for (i = 0; i < 360; i += items)
            {
                angle = (float)i / 180 * Mathf.PI;

                vertices[verticesLength] = new Vector3
                (
                    Mathf.Cos(angle) * radiusOuter,
                    Mathf.Sin(angle) * radiusOuter,
                    0
                );

                vertices[verticesLength + 1] = new Vector3
                (
                    Mathf.Cos(angle) * radiusInner,
                    Mathf.Sin(angle) * radiusInner,
                    0
                );

                verticesLength += 2;
            }

            for (i = 0; i < verticesLength - 2; i += 2)
            {
                triangles[trianglesLength + 0] = i;
                triangles[trianglesLength + 1] = i + 1;
                triangles[trianglesLength + 2] = i + 2;
                triangles[trianglesLength + 5] = i + 1;
                triangles[trianglesLength + 4] = i + 2;
                triangles[trianglesLength + 3] = i + 3;

                trianglesLength += 6;
            }

            triangles[trianglesLength + 0] = verticesLength - 2;
            triangles[trianglesLength + 1] = verticesLength - 1;
            triangles[trianglesLength + 2] = 0;
            triangles[trianglesLength + 5] = verticesLength - 1;
            triangles[trianglesLength + 4] = 0;
            triangles[trianglesLength + 3] = 1;

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = triangles;

            return mesh;
        }
    }
}
