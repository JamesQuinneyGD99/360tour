using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Student Name: Nicholas Easterby
//Student Number: EAS12337350
public class FlipNormals : MonoBehaviour
{
    Mesh mesh;//Variable that holds the 3d object
    // Use this for initialization
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;//Takes the 3d object the script is attached to
        // Flipping the triangles
        int[] triangles = mesh.triangles;//Stores the mesh triangles in an array of integers
        for (int i = 0; i < triangles.Length; i += 3)//Loops through the triangles, in jumps of three
        {
            int t = triangles[i];//Sets t with the value of triangle i
            triangles[i] = triangles[i + 2];//For the set of three values, this replaces the first with the last
            triangles[i + 2] = t;//Restores the first value in the last position
        }

        Vector3[] normals = mesh.normals;//Stores the normals of the mesh in an array of Vectors
        //Reversing the normal
        for (int i = 0; i < normals.Length; i ++)//Loops through every normal
        {
            normals[i] = -normals[i];// Sets the value of each normal to its negative
        }

        mesh.normals = normals;//Resets the 3d objects normals
        mesh.triangles = triangles;//Resets the 3d objects triangles
    }
}
