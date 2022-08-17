using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Firebase.Storage;

namespace OnlineMall.FirebaseDB
{
    internal class StorageDB
    {
        Stream file;
        string usernameID;

        public FirebaseStorageTask AddStoreStream(string userConfigID, string name, Stream stream)
        {
           var s = userConfigID;

            return new FirebaseStorage("shitoryukarate-ea3d5.appspot.com")
                .Child("Compony")
                .Child(name)
                .PutAsync(stream);


        }
      

       
    }
}
