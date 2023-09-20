using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace IconsGenerator;

[Generator(LanguageNames.CSharp)]
public class IconGenerator : ISourceGenerator
{
	public void Initialize(GeneratorInitializationContext context)
	{
		
	}

	private const string Path = "IconsGenerator.node_modules._tabler.icons.icons.";

	public void Execute(GeneratorExecutionContext context)
	{
		var assembly = Assembly.GetExecutingAssembly();
		var iconNames = assembly.GetManifestResourceNames()
								.Where(s => s.StartsWith(Path));

		var sb = new StringBuilder(81_920);
		sb.AppendLine("namespace TablerIconGenerator;");
		sb.AppendLine("public enum TablerIcon");
		sb.AppendLine("{");
		
		foreach (var iconName in iconNames)
		{
			var iconFormattedName = GetIconFilteredName(iconName);

			if (string.IsNullOrEmpty(iconFormattedName))
				continue;

			sb.Append(iconFormattedName);
			sb.Append(",\n");
		}

		sb.Remove(sb.Length - 2, 2);
		sb.AppendLine("}");

		var source = sb.ToString();

		context.AddSource("TablerIcon.g.cs", SourceText.From(source, Encoding.UTF8));
	}

	private static string GetIconFilteredName(string iconName)
	{
		var iconNameSpan = iconName.AsSpan();

		iconNameSpan = iconNameSpan.Slice(Path.Length);
		iconNameSpan = iconNameSpan.Slice(0, iconNameSpan.Length - 4);

		if (char.IsDigit(iconNameSpan[0]))
		{
			return string.Empty;
		}

		int newSize = 0;
		Span<int> minusIndexes = stackalloc int[5];

		int g = 0;
		for (int i = 0; i < iconNameSpan.Length; i++)
		{
			var c = iconNameSpan[i];

			if (c != '-')
			{
				newSize++;
				continue;
			}

			minusIndexes[g] = i;
			g++;
		}

		Span<char> span = stackalloc char[newSize];
		span[0] = char.ToUpper(span[0]);
		int j = 0;

		foreach (var c in iconNameSpan)
		{
			if (c == '-')
			{
				continue;
			}

			span[j] = c;
			j++;
		}

		try
		{
			foreach (var index in minusIndexes)
			{
				if (span.Length <= index)
					continue;

				span[index] = char.ToUpper(span[index]);
			}
		}
		catch (Exception e)
		{
			Debugger.Launch();
		}

		return span.ToString();
	}
}