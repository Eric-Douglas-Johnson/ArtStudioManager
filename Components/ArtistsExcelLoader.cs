
using Microsoft.Office.Interop.Excel;

namespace ArtStudioManager.Components
{
    public class ArtistsExcelLoader : IDataLoader<ICollection<Artist>>
    {
        public Task Load(ICollection<Artist> artists)
        {
            Application xlApp = new();
            Workbook xlWorkBook = xlApp.Workbooks.Open("testartists.xlsx");
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.UsedRange;

            foreach (var colVal in range["C"].Values)
            {
                artists.Add(colVal.ToString() ?? "");
            }

            return Task.CompletedTask;
        }
    }
}
