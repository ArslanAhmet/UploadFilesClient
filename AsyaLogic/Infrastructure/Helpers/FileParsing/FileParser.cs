using AsyaLogic.Core.Entities;

namespace AsyaLogic.Infrastructure.Helpers.FileParsing;

public abstract class FileParser
{
    public string FilePath { get; set; }

    public abstract List<EventRecord> Parse();
}
