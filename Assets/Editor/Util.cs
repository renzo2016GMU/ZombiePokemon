using UnityEngine;
using UnityEditor;
using System.Collections;

public static class Util
{
    [MenuItem("My Menu/FlipNormals")]
    public static void FlipNormals() {
        Mesh mesh = Selection.activeObject as Mesh;
        if (mesh == null) {
            Debug.LogError("Not a mesh");
            return;
        }
            Debug.Log(mesh);
        
        int[] tris = mesh.triangles.Clone() as int[];
        for (int i = 0; i < tris.Length; i += 3) {
            int tmp = tris[i];
            tris[i] = tris[i + 1];
            tris[i + 1] = tmp;
        }
        mesh.triangles = tris;
        Mesh m = new Mesh();
        m.vertices = mesh.vertices;
        m.normals = mesh.normals;
        m.uv = mesh.uv;
        m.triangles = tris;
        m.tangents = mesh.tangents;
        AssetDatabase.CreateAsset(m, "Assets/" + mesh.name + "flipped.asset");
        Debug.Log(m);
    }
}
