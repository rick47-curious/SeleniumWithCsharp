using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace E2ESeleniumDemo.Utilities
{
    class ExcelReaderUtil
    {
        public static Object[] GetTestData()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var Stream = File.Open("D:\\DotnetWorkspace\\E2ESeleniumDemo\\Resources\\TestData.xlsx", FileMode.Open, FileAccess.Read);

            var reader = ExcelReaderFactory.CreateReader(Stream);

            var results = reader.AsDataSet();

            var tables = results.Tables["Sheet1"];

            Object[] data = new object[tables.Rows.Count - 1];

            for (int i = 1; i < tables.Rows.Count; i++)
            {
                Dictionary<string, string> rowData = new Dictionary<string, string>();
                for (int j=0;j< tables.Columns.Count; j++)
                {
                    rowData.Add(tables.Rows[0][j].ToString(), tables.Rows[i][j].ToString());
                }
                data[i - 1] = rowData;
            }
            reader.Close();
            Stream.Close();
            
            return data;
        }
    }
}
