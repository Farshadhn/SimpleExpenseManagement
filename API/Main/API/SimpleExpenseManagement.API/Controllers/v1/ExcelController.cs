//using SimpleExpenseManagement.Core.Infrastructure.Operations;
//using SimpleExpenseManagement.Core.Models.Operations;
//using Lookif.Layers.WebFramework.Api;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using System.Globalization;
//using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;
//namespace SimpleExpenseManagement.API.Controllers.v1
//{
//    [ApiVersion("1")]
//    public class ExcelController : BaseController
//    {
//        private readonly IOperationService _operationService;

//        public ExcelController(IOperationService operationService)
//        {
//            _operationService = operationService;
//        }
//        [AllowAnonymous]
//        [HttpGet]
//        public async Task Calculate(CancellationToken cancellationToken)
//        {
//            Excel.Application xlApp = new Excel.Application();
//            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\Excels\Mellat\1400\1400_Farvardin.csv");
//            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
//            Excel.Range xlRange = xlWorksheet.UsedRange;
//            try
//            {
//                //Create COM Objects. Create a COM object for everything that is referenced

//                int rowCount = xlRange.Rows.Count;
//                int colCount = xlRange.Columns.Count;

//                //iterate over the rows and columns and print to the console as it appears in the file
//                //excel is not zero based!!

//                for (int i = 2; i <= rowCount; i++)
//                {
//                    var timeInExcel = xlRange.Cells[i, 10].Value2.ToString();
//                    double timeIdDouble = double.Parse(timeInExcel);
//                    DateTime conv = DateTime.FromOADate(timeIdDouble);
//                    var DateInExcel = xlRange.Cells[i, 11].Value2.ToString();
//                    DateTime dateTime = DateTime.Parse(DateInExcel + " " + conv.ToShortTimeString());
//                    //PersianCalendar persianCalendar = new PersianCalendar();
//                    //var x = new DateTime(DateInExcel,Date);
//                    //persianCalendar.
//                    Operation operation = new()
//                    {
//                        FromId = Guid.Parse("5ca3ac43-5d04-ed11-9cb8-7824afca0a0a"),
//                        LastEditedUserId = Guid.Parse("5ca3ac43-5d04-ed11-9cb8-7824afca0a0f"),
//                        Amount =
//                        (xlRange.Cells[i, 2].Value2.ToString() == "0") ?
//                        -1 * decimal.Parse(xlRange.Cells[i, 3].Value2.ToString()) :
//                        decimal.Parse(xlRange.Cells[i, 2].Value2.ToString()),
//                        Definition = xlRange.Cells[i, 4].Value2?.ToString() + " - " + xlRange.Cells[i, 5].Value2?.ToString(),
//                        DateTime = dateTime
//                    };
//                    await _operationService.AddAsync(operation, cancellationToken);
//                }
//            }
//            catch (Exception e)
//            {
                 
//            }
//            finally
//            {


//                //cleanup
//                GC.Collect();
//                GC.WaitForPendingFinalizers();

//                //rule of thumb for releasing com objects:
//                //  never use two dots, all COM objects must be referenced and released individually
//                //  ex: [somthing].[something].[something] is bad

//                //release com objects to fully kill excel process from running in the background
//                Marshal.ReleaseComObject(xlRange);
//                Marshal.ReleaseComObject(xlWorksheet);

//                //close and release
//                xlWorkbook.Close();
//                Marshal.ReleaseComObject(xlWorkbook);

//                //quit and release
//                xlApp.Quit();
//                Marshal.ReleaseComObject(xlApp);
//            }
//        }
//    }
//}
