using System.Globalization;

namespace NprProject
{
	public static class ObjLoader
	{
		public static Obj Load(string path)
		{
			List<float> _vertices = new List<float>();
			List<float> _normals = new List<float>();
			List<uint> _vertexIndices = new List<uint>();
			List<uint> _normalIndices = new List<uint>();

			if (!File.Exists(path))
			{
				throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
			}

			using(StreamReader streamReader = new StreamReader(path))
			{
				while(!streamReader.EndOfStream)
				{
					List<string> words = new List<string>(streamReader.ReadLine()!.ToLower().Split(' '));

					words.RemoveAll(s => s == string.Empty);

					if(words.Count == 0)
						continue;
					
					string type = words[0];
					words.RemoveAt(0);

					switch(type)
					{
						// vertex
						case "v":
							words.ForEach(vertex => _vertices.Add(float.Parse(vertex, CultureInfo.InvariantCulture)));
							break;

						case "vn":
							words.ForEach(normal => _normals.Add(float.Parse(normal, CultureInfo.InvariantCulture)));
							break;

						// case "vt":
						// 	textureVertices.Add(new Vector3(float.Parse(words[0]), float.Parse(words[1]), words.Count < 3 ? 0 : float.Parse(words[2])));
						// 	break;
						
						// face
						case "f":
							foreach(string word in words)
							{
								if(word.Length == 0)
									continue;
								
								string[] comps = word.Split('/');

								// Diminui 1: pq começo a contar de 1
								_vertexIndices.Add(uint.Parse(comps[0]) - 1);
								
								// FACES DAS TEXTURAS
								// if(comps.Length > 1 && comps[1].Length != 0)
								// 	textureIndices.Add(uint.Parse(comps[1]) - 1);
								
								if(comps.Length > 2)
									_normalIndices.Add(uint.Parse(comps[2]) - 1);
							}
							break;

						default:
							break;
					}
				}
			}

			return new Obj(_vertices, _normals, _vertexIndices, _normalIndices);
		}
	}
}
