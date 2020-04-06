using System;
using System.Threading.Tasks;
using MyCouch;

namespace couchdb_api_inter
{
    /* Database object class 
     * Acts as an intermediary between the couchdb database being called
     * and the application calling it.    
     */   
    public class db
    {
        private string dbname;
        private Uri uri;

        // db constructor
        public db(Uri uri, string dbname)
        {
            this.dbname = dbname;
            this.uri = uri;
        }

        // db constructor
        public db(string uri, string dbname)
        {
            Uri s = new Uri(uri);
            this.dbname = dbname;
            this.uri = s;
        }

        // Add document to database
        public async Task AddDoc(string doc)
        {
            using (var client = new MyCouchStore(uri, dbname))
            {

                var response = await client.StoreAsync(doc);
                Console.WriteLine(response);
                client.Dispose();
            }
        }

        // search database by "_id" value, NOT "id" value and
        // return document
        public async Task<string> GetDocById(string id)
        {
            string result;
            using (var client = new MyCouchStore(uri, dbname))
            {
                result = await client.GetByIdAsync(id);
                client.Dispose();
            }

            return result;
        }

        // search database for documents with given key value
        /*
        public async Task<string> GetDocByKey(string key, ViewIdentity view)
        {

            string result;
            object[] keys = key.Split(',');
            using (var client = new MyCouchStore(uri, dbname))
            {
                result = await client.GetValueByKeysAsync(view, keys, onResult);
            }

            return result;
        }
        */
    }
}
