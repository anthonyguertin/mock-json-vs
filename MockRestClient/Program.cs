using System.Threading.Tasks;
using EdgeJs;
using System;
using System.Collections.Generic;

namespace MockRestClient
{
    public class MockRestEndpoint
    {
        public static string Endpoint { get; set; }
        public static Method EndpointMethod { get; set; }
        public enum Method { GET = 1, POST, PUT, DELETE };

        public MockRestEndpoint(string endpointName, Method method)
        {
            Endpoint = endpointName;
            EndpointMethod = method;
        }

        public static string UpdateUserJs(string id, string first, string last)
        {
            return @"

                var options = {
                  url: 'http://localhost:3000/users/" + id + @"',
                  headers: {
                    'Content-Type': 'application/json'
                  },
                  form: { 'firstName' : 'josh', 'lastName' : 'shell' }
                };
                return function (data, cb) {
                    
                    var request = require('request');
                    request.put(options, function (e, res, bod) {
                        if (e) { console.log(e); }
                        cb(e, JSON.parse(res));
                    });
                }";
        }
    }

                //return @"
                //return function (data, cb) {
                    
                //    var request = require('request')
                //    request.put('http://localhost:3000/users/" + id + @"',{ firstName:" + @"'" + first + @"'" + @", lastName:" + @"'" + last + @"'" + @"'shell' }, function(e, res, bod) {
                //        if (e) { console.log(e) }
                        
                //        console.log(res)
                //    })
                //";

    public class User
    {
        private static int Id { get; set; }
        private static string FirstName { get; set; }
        private static string LastName { get; set; }

        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
    class Program
    {
        public static async Task<object> InitializeMockRestServiceAsync()
        {
            var f = Edge.Func(MockRestEndpoint.UpdateUserJs("4", "josh", "shell"));

            Console.WriteLine();

            return await f(".NET");
        }
           
        public static void Main(string[] args)
        {
            InitializeMockRestServiceAsync().Wait();
            Console.ReadLine();
        }
    }
}
