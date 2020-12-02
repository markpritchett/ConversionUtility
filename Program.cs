using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

var conversionOptions = JsonSerializer.Deserialize<ConversionOption>(File.ReadAllText(args[0]));

foreach (var extensionGrouping in conversionOptions.Options.GroupBy(x => x.Extension))
{
    foreach (var file in Directory.EnumerateFiles(conversionOptions.SourceDir, $"*{extensionGrouping.Key}", SearchOption.AllDirectories))
    {
        foreach (var option in extensionGrouping)
        {
            var contents = File.ReadAllText(file, Encoding.UTF8);

            if (option.IsRegex)
            {
                contents = Regex.Replace(contents, option.Find, option.ReplaceWith);
            }
            else
            {
                contents = contents.Replace(option.Find, option.ReplaceWith);
            }

            File.WriteAllText(file, contents, Encoding.UTF8);
        }
    }
}

record ConversionOption(string SourceDir, Option[] Options);
record Option(string Find, string ReplaceWith, string Extension, bool IsRegex);