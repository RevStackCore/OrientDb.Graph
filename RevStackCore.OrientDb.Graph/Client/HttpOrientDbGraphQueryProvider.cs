﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RevStackCore.OrientDb.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public class HttpOrientDbGraphQueryProvider : Graph.OrientDbGraphQueryProvider
    {
        OrientDbConnection _connection;

        public HttpOrientDbGraphQueryProvider(OrientDbConnection connection)
        {
            _connection = connection;
        }

        public override object Execute(string query, Type elementType)
        {
            int top = -1;
            string fetch = "*:-1";
            
            query = System.Net.WebUtility.UrlDecode(query).Replace("http:/", "http://");
            query = query.Replace("https:/", "https://");
            query = query.Replace("?", "\\u003F");
            query = query.Replace("#", "");

            string url = string.Format("{0}/query/{1}/sql/{2}/{3}", _connection.Server, _connection.Database, System.Net.WebUtility.UrlEncode(query), top);

            if (!string.IsNullOrEmpty(fetch))
            {
                url += "/" + fetch;
            }
            var response = Task.Run(() => HttpClient.SendRequest(url, "GET", string.Empty, _connection.Username, _connection.Password, _connection.SessionId)).Result;

            if (response.StatusCode != 200)
            {
                throw new RestException
                {
                    StatusCode = response.StatusCode,
                    Body = response.Body,
                    StatusMessage = response.StatusString,
                    Url = url
                };
            }

            string body = response.Body;
            //body = body.Replace("out_", "");
            //body = body.Replace("in_", "");

            //orientdb meta
            body = body.Replace("@rid", "_rid");
            body = body.Replace("@class", "_class");
            body = body.Replace("@version", "_version");

            //DEPRICATED
            //body = body.Replace("@type", "_type");
            //body = body.Replace("@created", "_created");
            //body = body.Replace("@modified", "_modified");

            var jRoot = JObject.Parse(body);
            var jResults = jRoot.Value<JArray>("result");

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            object results = JsonConvert.DeserializeObject(jResults.ToString(), typeof(IEnumerable<>).MakeGenericType(elementType), settings);
            return results;
        }
    }
}
