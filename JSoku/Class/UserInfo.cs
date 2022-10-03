using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MySql.Data;

namespace JSoku
{
    class UserInfo
    {
        public int SID;
        public string UserId;
        public string UserName;
        public string UserPassword;
        Boolean IsValid;

        Hashtable AuthList = new Hashtable();
        Hashtable EigyoCdList = new Hashtable();

        public void Login()
        {
            this.IsValid = false;
            this.AuthList.Clear();

            var query = string.Format(" select * from m_user where userid={0} and userps={1} ", DB.Escape(this.UserId), DB.Escape(this.UserPassword));
            var rs = DB.GetReader(query);

            while (rs.Read())
            {
                this.UserName = rs["SIMEI"].ToString();
                this.IsValid = true;
            }

        }

        private static UserInfo _Current;
        public static UserInfo Current
        {
            get
            {
                if(_Current == null)
                {
                    var _Current = new UserInfo();
                }
                return _Current;
            }
        }

    }
}
