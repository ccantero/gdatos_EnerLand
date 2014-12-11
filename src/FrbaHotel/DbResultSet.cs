using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace FrbaHotel
{
    public class DbResultSet
    {
        public DataTable dataTable;
        public int intValue;
        public double doubleValue;
        public String strValue;
        public DateTime dateValue;
        public int[] intArrayValue ;
        public int operationState;
        

        public DbResultSet()
        {
            this.dataTable = new DataTable();
            this.intValue = 0;
            this.strValue = string.Empty;
            this.doubleValue = 0.0;
            this.dateValue = DateTime.Now;
            this.operationState = 0;
        }
    }
}
