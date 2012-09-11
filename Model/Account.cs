using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ImagioMonads;

namespace Docs.Model
{

    public partial class Account: IDataErrorInfo
    {
        Dictionary<string, string> errorList = new Dictionary<string,string>();

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
                errorList.Remove(columnName);
                if (columnName == "UserName")
                {
                    if (this.UserName == null || this.With(w => w.UserName).If(w => w.Length <= 4).ReturnSuccess())
                        errorList.Add(columnName, "Имя пользователя должно превышать 4 символа");
                }
                OnPropertyChanged("Error");
                return errorList.ContainsKey(columnName) ? errorList[columnName] : null;
            }
        }
    }
}
