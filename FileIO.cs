using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using ClosedXML.Excel;

namespace price
{
    /// <summary>
    /// ingoing file loader and result file writer
    /// </summary>
    class FileIO
    {
        /// <summary>
        /// read ingoing file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>array of lines</returns>
        public static string[] OpenFile(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string[] file = File.ReadAllLines(path, Encoding.GetEncoding("cp866"));
            return file;
        }

        /// <summary>
        /// write result file 
        /// </summary>
        /// <param name="path">out path + file name</param>
        /// <param name="lines">list of price positions</param>
        public static void WriteFile(string path, List<string[]> lines)
        {
            //create new excel workbook
            XLWorkbook workbook = new XLWorkbook();
            //add new list to the workbook
            IXLWorksheet worksheet = workbook.Worksheets.Add("price");
            //LINE 1
            //create named range of cells for search script
            worksheet.Range("A1:G1").AddToNamed("conditions");
            //LINE 2
            //create table column names
            worksheet.Cell("A2").Value = "№";
            worksheet.Cell("B2").Value = "Номер";
            worksheet.Cell("C2").Value = "НАИМЕНОВАНИЕ ПРОДУКЦИИ";
            worksheet.Cell("D2").Value = "Ед. изм.";
            worksheet.Cell("E2").Value = "Обьем изделия";
            worksheet.Cell("F2").Value = "ОТПУСКНАЯ ЦЕНА";
            worksheet.Cell("G2").Value = "Отпускная цена без НДС";
            //enable filter
            worksheet.Range("A2:G2").SetAutoFilter(true);
            //LINE 3
            //first line to write data
            int offset = 3;
            for (int i = offset; i < lines.Count + offset; i++)
            {
                worksheet.Cell(String.Format("A{0}", i)).Value = lines[i - offset][0]; //№
                worksheet.Cell(String.Format("B{0}", i)).Value = lines[i - offset][1]; //Номер
                worksheet.Cell(String.Format("C{0}", i)).Value = lines[i - offset][2]; //НАИМЕНОВАНИЕ ПРОДУКЦИИ
                worksheet.Cell(String.Format("D{0}", i)).Value = lines[i - offset][3]; //Ед. изм.
                worksheet.Cell(String.Format("E{0}", i)).Value = lines[i - offset][4]; //Обьем изделия
                worksheet.Cell(String.Format("E{0}", i)).DataType = XLDataType.Number; //set "Обьем изделия" value to numeric format
                worksheet.Cell(String.Format("F{0}", i)).Value = lines[i - offset][5]; //ОТПУСКНАЯ ЦЕНА
                worksheet.Cell(String.Format("F{0}", i)).DataType = XLDataType.Number; //set "ОТПУСКНАЯ ЦЕНА" value to numeric format
                worksheet.Cell(String.Format("G{0}", i)).Value = lines[i - offset][6]; //Отпускная цена без НДС
                worksheet.Cell(String.Format("G{0}", i)).DataType = XLDataType.Number; //set "Отпускная цена без НДС" value to numeric format
            }
            //save excel workbook to specified location
            workbook.SaveAs(path);

        }
    }
}
