namespace AsyaLogic.Infrastructure.Helpers.FileParsing;

public static class FileParserFactory
{
    public static FileParser Create(string fileName)
    {
        string fileType = Path.GetExtension(fileName);
        switch (fileType.Substring(1).ToLower())
        {
            case "xlx":
            case "xlsx":
                return new ExcelFileParser { FilePath = fileName };
            case "json":
                return new JsonFileParser { FilePath = fileName };
            case "xml":
                return new XmlFileParser { FilePath = fileName };
            default:
                throw new ArgumentException($"Invalid File Parser type: {fileType}");
        }
    }
}
