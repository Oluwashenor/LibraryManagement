using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class DisconnectedArchiteture
    {
        DataTable? dataTable;
        DataColumn? dataColumn;
        DataRow? dataRow;
        DataSet? dataSet;

        public DataTable GetBooks()
        {
            dataTable = new DataTable("Book");
            
            dataColumn = new DataColumn("Id", typeof(int));  
            dataTable.Columns.Add(dataColumn);
            dataTable.PrimaryKey = new DataColumn[] { dataColumn };

            dataColumn = new DataColumn("Name", typeof(string));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("AuthorId", typeof(int));
            dataTable.Columns.Add(dataColumn);

            //Adding Row
            dataRow = dataTable.NewRow();
            dataRow[0] = 1; dataRow[1] = "Ogboju Ode";
            dataTable.Rows.Add(dataRow);
           // dataRow["Id"] = 1; dataRow["Name"] = "Ogboju Ode"; same as line above

            dataRow = dataTable.NewRow();
            dataRow[0] = 2; dataRow[1] = "Ireke Onibudo";
            dataTable.Rows.Add(dataRow);
            return dataTable;
        }

        public DataTable GetAuthors()
        {
            dataTable = new DataTable("Author");

            dataColumn = new DataColumn("Id", typeof(int));
            dataTable.Columns.Add(dataColumn);
            dataTable.PrimaryKey = new DataColumn[] { dataColumn };

            dataColumn = new DataColumn("Name", typeof(string));
            dataTable.Columns.Add(dataColumn);

            //Adding Row
            dataRow = dataTable.NewRow();
            dataRow[0] = 1; dataRow[1] = "Ogboju Ode";
            dataTable.Rows.Add(dataRow);
            // dataRow["Id"] = 1; dataRow["Name"] = "Ogboju Ode"; same as line above

            dataRow = dataTable.NewRow();
            dataRow[0] = 2; dataRow[1] = "Ireke Onibudo";
            dataTable.Rows.Add(dataRow);
            return dataTable;
        }

        public DataSet GenerateDataSet()
        {
            DataTable books = GetBooks();
            DataTable authors = GetAuthors();
            var dataSet = new DataSet("MyDataSet");
            dataSet.Tables.Add(books);  
            dataSet.Tables.Add(authors);
            //DataColumn col_pk = dataSet.Tables[0].Columns[1]; //same as below
            DataColumn? col_pk = dataSet.Tables["Author"]?.Columns["Id"];
            DataColumn? col_fk = dataSet.Tables["Book"]?.Columns["AuthorId"];
            DataRelation dre1 = new DataRelation("Book_Author_Rel",col_pk, col_fk);
            dataSet.Relations.Add(dre1);
            return dataSet;
        }
    
        public void WriteToJson()
        {
            DataTable dataTable = GetBooks();
            string json = JsonConvert.SerializeObject(dataTable);
            StreamWriter writer = File.CreateText(@"C:\data\data.json");
            writer.WriteLine(json);
            writer.Close();
        }
    }
}
