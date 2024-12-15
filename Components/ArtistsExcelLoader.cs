
using Microsoft.Office.Interop.Excel;

namespace ArtStudioManager.Components
{
    public class ArtistsExcelLoader : IEntityLoader<ICollection<Artist>>
    {
        // replace with config value at some point
        private string _fileName = @"C:\Users\e_d_j\OneDrive\Desktop\ArtistData.xlsx";

        public Task Load(ICollection<Artist> artists)
        {
            if (!File.Exists(_fileName)) { throw new InvalidOperationException("ExcelFilePath is not a valid file."); }

            Application xlApp = new();
            Workbook xlWorkBook = xlApp.Workbooks.Open(_fileName);
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.UsedRange;

            int emailColumnIndex = 0;
            string tempColumnName = "";

            for (int i = 1; i < range.Columns.Count; i++)
            {
                tempColumnName = range.Rows[1].Cells[i].Value;

                if (tempColumnName == "Email")
                {
                    emailColumnIndex = i;
                }
            }

            for (int i = 2; i <= range.Rows.Count; i++)
            {
                artists.Add(new Member { Email = range.Cells[i, emailColumnIndex].Value.ToString() } );
            }

            xlWorkBook.Close();
            return Task.CompletedTask;
        }
    }
}
