using System.Collections.Generic;
using System.IO;
using OpenTK;

namespace NprProject
{
    public class Obj
    {
        public List<float> Vertices { get; set; }
        public List<float> Normals { get; set; }
        public List<uint> VertexIndices { get; set; }
        public List<uint> NormalIndices { get; set; }
        public int VertexLength { get; set; }
        public int NormalLength { get; set; }

        public Obj(List<float> vertices, List<float> normals, List<uint> vertexIndices, List<uint> normalIndices)
        {
            Vertices = vertices;
            Normals = normals;
            VertexIndices = vertexIndices;
            NormalIndices = normalIndices;
            VertexLength = vertices.Count;
            NormalLength = normals.Count;
        }

        ~Obj()
        {

        }
    }
}