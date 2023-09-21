using System.Reflection;
using System.Text;
using System.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace IconsGenerator;

[Generator(LanguageNames.CSharp)]
public class IconGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		context.RegisterPostInitializationOutput(Generate);
	}

	private static void Generate(IncrementalGeneratorPostInitializationContext context)
	{
		try
		{
			var assembly = Assembly.GetExecutingAssembly();
			var iconAssemblyNames = assembly.GetManifestResourceNames()
											.Where(static s => s.StartsWith(Path));

			var enumSb = new StringBuilder(81_920);
			enumSb.AppendLine("namespace TablerIconGenerator;");
			enumSb.AppendLine("public enum TablerIcon");
			enumSb.AppendLine("{");

			var extensionsSb = new StringBuilder(81_920 * 6);
			extensionsSb.AppendLine("namespace TablerIconGenerator;");
			extensionsSb.AppendLine("public static class TablerIconExtensions");
			extensionsSb.AppendLine("{");

			var extensionsMethodSb = new StringBuilder(10_000);
			extensionsMethodSb.AppendLine("public static Microsoft.AspNetCore.Components.RenderFragment ToRenderFragment(this TablerIconGenerator.TablerIcon icon) => icon switch");
			extensionsMethodSb.AppendLine("{");

			foreach (var assemblyName in iconAssemblyNames)
			{
				context.CancellationToken.ThrowIfCancellationRequested();

				var iconFormattedName = GetIconFilteredName(assemblyName);

				if (string.IsNullOrEmpty(iconFormattedName))
					continue;

				enumSb.Append(iconFormattedName);
				enumSb.Append(",\n");

				extensionsSb.AppendLine(CreateRenderFragment(assembly, assemblyName, iconFormattedName));
				extensionsMethodSb.AppendLine($"TablerIconGenerator.TablerIcon.{iconFormattedName} => {iconFormattedName},");
			}

			enumSb.Remove(enumSb.Length - 2, 2);
			enumSb.AppendLine("}");

			var enumSource = enumSb.ToString();
			context.AddSource("TablerIcon.g.cs", SourceText.From(enumSource, Encoding.UTF8));

			extensionsMethodSb.AppendLine("};");
			extensionsSb.Append(extensionsMethodSb);

			extensionsSb.AppendLine("}");
			var extensionsSource = extensionsSb.ToString();

			context.AddSource("TablerIconExtensions.g.cs", SourceText.From(extensionsSource, Encoding.UTF8));
		}
		catch (OperationCanceledException ) { }
		catch (Exception e)
		{
			//
		}
	}

	private const string Path = "IconsGenerator.node_modules._tabler.icons.icons.";

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

		foreach (var index in minusIndexes)
		{
			if (span.Length <= index)
				continue;

			span[index] = char.ToUpper(span[index]);
		}

		return span.ToString();
	}

	private static string CreateRenderFragment(Assembly assembly, string iconAssemblyName, string iconName)
	{
		using var stream = assembly.GetManifestResourceStream(iconAssemblyName);
			
		var svg = new XmlDocument();
		svg.Load(stream);

		var content = svg.DocumentElement.InnerXml;
		var viewBox = svg.DocumentElement.GetAttribute("viewBox");
		var strokeWidth = svg.DocumentElement.GetAttribute("stroke-width");
		var strokeLineCap = svg.DocumentElement.GetAttribute("stroke-linecap");
		var strokeLineJoin = svg.DocumentElement.GetAttribute("stroke-linejoin");

		string str = $$""""
					   private static readonly Microsoft.AspNetCore.Components.RenderFragment {{iconName}} = builder =>
					   {
					       int seq = 0;
					       
					       builder.OpenElement(seq++, "svg");
					       
					       builder.AddAttribute(seq++, "style", "width: 1em;");
					       builder.AddAttribute(seq++, "focusable", false);
					       builder.AddAttribute(seq++, "viewBox", "{{viewBox}}");
					       builder.AddAttribute(seq++, "aria-hidden", true);
					       builder.AddAttribute(seq++, "fill", "none");
					       builder.AddAttribute(seq++, "stroke", "currentColor");
					       builder.AddAttribute(seq++, "stroke-width", "{{strokeWidth}}");
					       builder.AddAttribute(seq++, "stroke-linecap", "{{strokeLineCap}}");
					       builder.AddAttribute(seq++, "stroke-linejoin", "{{strokeLineJoin}}");
					       
					       builder.AddMarkupContent(seq++, """
					       {{content}}
					       """);
					       
					       builder.CloseElement();
					   };
					   """";

		return str;
	}
}