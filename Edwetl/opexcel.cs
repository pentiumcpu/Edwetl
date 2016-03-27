using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Data;
using System.Runtime.InteropServices;
namespace Edwetl
{
    class opexcel
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        // 结束 Excel 进程
        public static void KillExcel(Application excel)
        {
            IntPtr t = new IntPtr(excel.Hwnd);
            int k = 0;
            GetWindowThreadProcessId(t, out k);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            p.Kill();
        }
        private static string str_filename = "";
        private Application app;
        private ApplicationClass excel;
        public  opexcel(string str)
        {

            str_filename = str;
        }
        public _Workbook open()
        {

            app = new Application();
            app.Visible = false;
            Workbooks wbks = app.Workbooks;
            _Workbook _wbk = wbks.Add(str_filename);
            object oMissiong = System.Reflection.Missing.Value;
            wbks.Open(str_filename, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
            return _wbk;
        }
        public Workbook open2()
        {

            excel = new ApplicationClass();
            excel.Visible = false;
            object oMissiong = System.Reflection.Missing.Value;
            Workbook wb = excel.Workbooks.Open(str_filename, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
            //excel.Quit();
            //excel = null;
            return wb;
        }
        public void opensafe2()
        {
            //第一种方式
            //app = new Application();
            //app.Visible = false;
            //Workbooks wbks = app.Workbooks;
            //_Workbook _wbk = wbks.Add(str_filename);
            //object oMissiong = System.Reflection.Missing.Value;
            //wbks.Open(str_filename, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
            //_wbk.Save();
            //_wbk.Close();
            //第二种方式
            excel = new ApplicationClass();
            //excel.Visible = false;
            object oMissiong = System.Reflection.Missing.Value;
            Workbook wb = excel.Workbooks.Open(str_filename, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
            //Workbook wb = excel.Workbooks.Open(str_filename);
            //System.Data.DataTable dt = getdatatable(wb);
            //wb = null;
            wb.Save();
            wb.Close();
            //excel.Quit();
            //excel.Quit();
            //KillExcel(excel);
            //excel = null;
            close2();
        }
        //public void opensafe2()
        //{
        //    excel = new ApplicationClass();
        //    //excel.Visible = false;
        //    //object oMissiong = System.Reflection.Missing.Value;
        //    //Workbook wb = excel.Workbooks.Open(str_filename, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
        //    Workbook wb = excel.Workbooks.Open(str_filename);
        //    //System.Data.DataTable dt = getdatatable(wb);
        //    //wb = null;
        //    wb.Save();
        //    wb.Close();
        //    //excel.Quit();
        //    close2();
        //}
       public void save(_Workbook wb, string path)
        {
            //wb.SaveAs(path);
            if (path.Substring(path.Length - 4, 4).ToLower() == "xlsx")
            {
                wb.SaveAs(path, 51);
            }
            else if (path.Substring(path.Length - 3, 3).ToLower() == "xls")
            {
                wb.SaveAs(path, 56);
            }
        }
       public void save(Workbook wb,string path)
       {
           //wb.SaveAs(path);
           if (path.Substring(path.Length - 4, 4).ToLower() == "xlsx")
           {
               wb.SaveAs(path,51);
           }
           else if (path.Substring(path.Length - 3, 3).ToLower() == "xls")
           {
               wb.SaveAs(path, 56);
           }
       }
        public void close()
        {
            
            app.Workbooks.Close();
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
        public void close2()
        {
            excel.Workbooks.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            excel = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public string find_str(_Workbook wbk, string str_sheetname, int r, int c)
        {

            Sheets shs = wbk.Sheets;
            _Worksheet wsh = (_Worksheet)shs.get_Item(str_sheetname);
            return (string)(wsh.Cells[r, c].ToString());
        }
        public System.Data.DataTable getdatatable(Workbook workbook, string sheetname)
        {
            Sheets sheets = workbook.Worksheets;
            System.Data.DataTable dt = new System.Data.DataTable();
            foreach (Worksheet worksheet  in sheets)
            {
                if (worksheet.Name == sheetname)
                {
                    string cellContent;
                    int iRowCount = worksheet.UsedRange.Rows.Count;
                    int iColCount = worksheet.UsedRange.Columns.Count;
                    Range range;
                    for (int iRow = 1; iRow <= iRowCount; iRow++)
                    {
                        DataRow dr = dt.NewRow();

                        for (int iCol = 1; iCol <= iColCount; iCol++)
                        {
                            range = (Range)worksheet.Cells[iRow, iCol];

                            cellContent = (range.Value2 == null) ? "" : range.Text.ToString();

                            if (iRow == 1)
                            {
                                dt.Columns.Add(cellContent);
                            }
                            else
                            {
                                dr[iCol - 1] = cellContent;
                            }
                        }

                        if (iRow != 1)
                            dt.Rows.Add(dr);
                    }

                }
             }
            return dt;
        }
        public System.Data.DataTable getdatatable(Workbook workbook)
        {
            Sheets sheets = workbook.Worksheets;
            System.Data.DataTable dt = new System.Data.DataTable();
            int iRow = 2;
            dt.Columns.Add("TABLE_NAME");
            foreach (Worksheet worksheet in sheets)
            {
                string cellContent;
                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                //Range range;
                
                DataRow dr = dt.NewRow();
                cellContent = (worksheet.Name == null) ? "" : worksheet.Name.ToString();
                if (iRow == 1)
                {
                    dt.Columns.Add(cellContent);
                }
                else
                {
                    dr[0] = cellContent;
                }
                if (iRow != 1)
                    dt.Rows.Add(dr);
                iRow++;
            }
            return dt;
        }
    }
}
