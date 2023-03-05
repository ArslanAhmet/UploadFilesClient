using AsyaLogic.Core.Entities;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace AsyaLogic.Infrastructure.Helpers.FileParsing;

public class ExcelFileParser : FileParser
{
    public override List<EventRecord> Parse()
    {
        FileInfo fileInfo = new FileInfo(FilePath);
        var eventRecords = new List<EventRecord>();
        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;
            for (int row = 2; row <= rowCount; row++)
            {
                EventRecord eventRecord = new EventRecord();

                object value = worksheet.Cells[row, 1].Value;
                if (value == null)
                {
                    break;
                }

                eventRecord.EventID = int.Parse( worksheet.Cells[row, 1].Value.ToString());
                eventRecord.EventType =  worksheet.Cells[row, 2].Value.ToString() ;
                eventRecord.Country = worksheet.Cells[row, 3].Value.ToString();
                eventRecord.League = worksheet.Cells[row, 4].Value.ToString();
                eventRecord.HomeTeam = worksheet.Cells[row, 5].Value.ToString();
                eventRecord.AwayTeam = worksheet.Cells[row, 6].Value.ToString();
                eventRecord.EventTime = DateTime.Parse( worksheet.Cells[row, 7].Value.ToString());
                eventRecords.Add(eventRecord);
            }
        }

        return eventRecords;
    }
}
