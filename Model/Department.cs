using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Docs.Model
{
    public partial class Department: IDataErrorInfo
    {

        Dictionary<string, string> errorList = new Dictionary<string, string>();

        public string Error
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in errorList)
                    sb.AppendFormat("{0}\n", error.Value);
                return sb.Length > 0 ? sb.ToString() : null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                OnPropertyChanged("Error");
                return errorList.ContainsKey(columnName) ? errorList[columnName] : null;
            }
        }
    }
}
