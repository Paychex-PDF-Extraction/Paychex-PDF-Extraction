using System;
using MyCouch;
using System.Net.Http;
using System.Threading.Tasks;

namespace couchdb_api_inter
{
    class MainClass
    {
        public static async Task Main(string[] args)
        {
            Uri uri = new Uri("http://<username>:<password>@127.0.0.1:5984");
            String database = "/albums";

            db dbase = new db(uri, database);

            //string docString = "{\"id\": \"002\", \"title\": \"interstellar\", " +
            //	"\"artist\": \"Incubus\"}";

            var result = await dbase.GetDocById("66a1eac43aa362a96194ec1828000e8b");
            //var result = await dbase.GetDocByKey("title");
            Console.WriteLine(result);

            // To Do: functions for reading from and writing documents
            //      1. return document by key value
            //      2. add document
            //      3. update document
            //      4. delete document
        }
    }
}
