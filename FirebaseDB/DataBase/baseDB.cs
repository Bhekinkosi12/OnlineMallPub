using System;
using System.Collections.Generic;
using System.Text;
using OnlineMall.Models.Shops;

namespace OnlineMall.FirebaseDB.DataBase
{
    public class BaseDB
    {
        private string firebaseDatabaseID = "https://mzansigopro-f8d36-default-rtdb.firebaseio.com/";
        protected string FirebaseDatabaseID { get => firebaseDatabaseID; }

    }
}
