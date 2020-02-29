// Code used for creation vec2 ".xyzw" and ".rgba" vectors from components for OpenTK Math

static int MaxVLen = 4;

static string[] ComponentsAlt = new string[] { "x", "y", "z", "w" };
//static string[] ComponentsAlt = new string[] { "r", "g", "b", "a" };
//static string[] ComponentsAlt = new string[] { "s", "t", "p", "q" };

static int PresitionIndex = 0;

static string Presition = new string[] { String.Empty, "d", "b", "i", "u", "h" } [PresitionIndex];
static string BaseType = new string[] { "float", "double", "bool", "int", "uint", "Half" } [PresitionIndex];

static string[] Components = new string[] { "x", "y", "z", "w" };
string[] ComponentsUpperCase = new string[] { "X", "Y", "Z", "W" };
int[] ComponentsCount = new int[] { (int)Math.Pow(MaxVLen, 1), (int)Math.Pow(MaxVLen, 2), (int)Math.Pow(MaxVLen, 3), (int)Math.Pow(MaxVLen, 4) };

string GetCoords(int size, int index, bool ReplaceCoords = false)
{
	var Coords = (ReplaceCoords ? ComponentsAlt : Components);
	
	switch (size)
	{
		case 1:
			return Coords[index % MaxVLen].ToString();
		case 2:
			return String.Format("{0}{1}",
				Coords[(index / MaxVLen) % MaxVLen],
				Coords[index % MaxVLen]);
		case 3:
			return String.Format("{0}{1}{2}",
				Coords[(index / MaxVLen / MaxVLen) % MaxVLen],
				Coords[(index / MaxVLen) % MaxVLen],
				Coords[index % MaxVLen]);
		case 4:
			return String.Format("{0}{1}{2}{3}",
				Coords[(index / MaxVLen / MaxVLen / MaxVLen) % MaxVLen],
				Coords[(index / MaxVLen / MaxVLen) % MaxVLen],
				Coords[(index / MaxVLen) % MaxVLen],
				Coords[index % MaxVLen]);
		default:
			return null;
	}
}

bool IsCanSets(string coords)
{
	return coords.Length <= 1 || coords.Distinct().ToArray().Count() >= coords.Length;
}

string FixVec1(string str)
{
	return str.Replace("new Vector1" + Presition, "").Replace("Vector1" + Presition, BaseType).
		Replace("(" + ComponentsUpperCase[0] + ")", ComponentsUpperCase[0]).
		Replace("(" + ComponentsUpperCase[1] + ")", ComponentsUpperCase[1]).
		Replace("(" + ComponentsUpperCase[2] + ")", ComponentsUpperCase[2]).
		Replace("(" + ComponentsUpperCase[3] + ")", ComponentsUpperCase[3]).
		Replace("value." + ComponentsUpperCase[0] + ";", "value;").
		Replace("value." + ComponentsUpperCase[1] + ";", "value;").
		Replace("value." + ComponentsUpperCase[2] + ";", "value;").
		Replace("value." + ComponentsUpperCase[3] + ";", "value;");
}

void Main()
{
	List<string> Records = new List<string>();
	string Template =
	@"		[XmlIgnore]
		public Vector{0} {1}
		{{
			get => new Vector{0}({2});{3}
		}}
		";

	string TemplateSet = @"
			set
			{{{0}
			}}";
	string SetCoordsTemplate = @"
				{0} = value.{1};";

	for (int c = 1; c <= 4; c++)
	{
		string VecType = c.ToString() + Presition;
		for (int i = 0; i < ComponentsCount[c - 1]; i++)
		{
			string Coords = GetCoords(c, i, true); // "xyz"
			string OpenTKCoords = GetCoords(c, i, false).ToUpperInvariant();
			string CoordsWithDivider = string.Join(String.Empty, OpenTKCoords.Select((str, index) => str + (index < Coords.Length - 1 ? ", " : String.Empty))); // "x, y, z"
			
			string SetsPart = String.Empty;
			if (IsCanSets(Coords))
			{
				string SetCoords = String.Empty;
				for (var j = 0; j < Coords.Length; j++)
					SetCoords += String.Format(SetCoordsTemplate, OpenTKCoords[j], ComponentsUpperCase[j]);
				
				SetsPart = String.Format(TemplateSet, SetCoords);
			}
			
			string Record = String.Format(Template, VecType, Coords, CoordsWithDivider, SetsPart);
			if (Coords.Length <= 1)
				Record = FixVec1(Record);
			Records.Add(Record);
		}
	}
	// To code: Records
}