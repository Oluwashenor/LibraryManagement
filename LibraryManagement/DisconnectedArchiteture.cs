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

        public DataTable GetBooks()
        {
            dataTable = new DataTable("Book");
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
    }
}
