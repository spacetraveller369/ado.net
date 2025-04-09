using Dapper;
using dapper_hw.Models;
using dapper_hw.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Z.Dapper.Plus;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Reflection;

namespace dapper_hw
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // TASK 1
            string connectionString = "Server=localhost;Database=Store;Trusted_Connection=True;TrustServerCertificate=True;";

            string filePath = "D:\\development\\itStep\\ado.net\\ado.net_classes\\dapper_hw\\dapper_hw\\test.json";

            var records = ReadJson(filePath);

            var modelType = CreateDynamicModel(records);

            var dataList = MapDataToModel(records, modelType);

            string tableName = "TestTable2"; // название таблицы

            CreateTableInDatabase(tableName, modelType, connectionString); // создание таблицы

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DapperPlusManager.Entity(modelType).Table(tableName);
                connection.BulkInsert(dataList);
                //connection.BulkInsert(dataList); // массовая вставка данных с использованием dapper plus
                Console.WriteLine("Данные успешно вставлены в таблицу.");
            }

            // TASK 2 dapper plus
            string connectionString = "Server=localhost;Database=TestProject;Trusted_Connection=True;TrustServerCertificate=True;";

            var people = new List<User>
                {
                new User { Name = "John Doe", Age = 30 },
                new User { Name = "Jane Smith", Age = 25 },
                new User { Name = "James Brown", Age = 40 },
                new User { Name = "Emily White", Age = 34 },
                new User { Name = "Michael Johnson", Age = 50 },
                new User { Name = "Sarah Davis", Age = 45 },
                new User { Name = "David Miller", Age = 60 },
                new User { Name = "Laura Garcia", Age = 55 },
                new User { Name = "William Martinez", Age = 65 },
                new User { Name = "Olivia Wilson", Age = 28 }
                };

            // new users list for merge
            var newPeople = new List<User>
            {
                new User { Name = "Alice Brown", Age = 26 },
                new User { Name = "Bob Green", Age = 33 },
                new User { Name = "Charlie Blue", Age = 28 },
                new User { Id=14, Name = "David Black", Age = 50 },
                new User { Id=15, Name = "Ella White", Age = 35 },
                new User { Id=16, Name = "Frank Red", Age = 40 },
                new User { Id=17, Name = "Grace Purple", Age = 22 },
                new User { Id=18, Name = "Henry Pink", Age = 29 },
                new User { Id=19, Name = "Ivy Orange", Age = 37 },
                new User { Id=20, Name = "Jack Yellow", Age = 48 }
            };

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                BulkInsertData(connection, people);
                PrintAllPeople(connection);

                BulkUpdateData(connection, people.GetRange(0, 5));
                PrintAllPeople(connection);

                BulkDeleteData(connection, people);
                PrintAllPeople(connection);

                BulkMergeData(connection, newPeople);
                PrintAllPeople(connection);


               // TASK 3 dapper
               var userRepository = new UserRepository(connectionString);
               // create new user
               var newUser = new User { Name = "Billie", Age = 30 };

               // add new user
               userRepository.CreateUser(newUser);

               // get all users
               var users = userRepository.GetAllUsers();

                Console.WriteLine("All Users:");

                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}");
                }

                // get user by id
                var singleUser = userRepository.GetUserById(1);

                if (singleUser != null)
                {
                    Console.WriteLine($"User with ID 1: {singleUser.Name}, Age: {singleUser.Age}");
                }
                else
                {
                    Console.WriteLine("User with ID 1 not found.");
                }

                userRepository.DeleteUser(1);
            }          
        }

        // for task 2
        static void BulkInsertData(SqlConnection connection, List<User> people)
        {
            connection.BulkInsert(people);
            Console.WriteLine("Data inserted into table successfully.");
        }

        static void BulkUpdateData(SqlConnection connection, List<User> people)
        {
            for (int i = 0; i < people.Count; i++)
            {
                people[i].Name = "UPDATED " + people[i].Name;
            }

            connection.BulkUpdate(people);
            Console.WriteLine("Data inserted into table successfully.");
        }

        static void BulkDeleteData(SqlConnection connection, List<User> people)
        {
            // delete user where age > 40
            var usersToDelete = people.Where(x => x.Age > 40).ToList();

            connection.BulkDelete(usersToDelete);

            Console.WriteLine("Data deleted from table successfully.");
        }

        static void BulkMergeData(SqlConnection connection, List<User> newPeople)
        {
            connection.BulkMerge(newPeople);
            Console.WriteLine("Data merged into table successfully.");
        }

        static void PrintAllPeople(SqlConnection connection)
        {
            var allPeople = connection.Query<User>("SELECT * FROM dbo.Users").ToList();

            Console.WriteLine("All users:");

            foreach (var person in allPeople)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");
            }
        }

        // for task 1
        // read from JSON
        static List<Dictionary<string, string>> ReadJson(string filePath)
        {
            var records = new List<Dictionary<string, string>>();

            var jsonData = File.ReadAllText(filePath);
            var jsonArray = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonData);

            foreach (var record in jsonArray)
            {
                var row = new Dictionary<string, string>();
                foreach (var kvp in record)
                {
                    row[kvp.Key] = kvp.Value.ToString();
                 }
                records.Add(row);
            }

            return records;
        }

        // create model dynamic JSON
        static Type CreateDynamicModel(List<Dictionary<string, string>> records)
        {
            var columns = new List<string>();

            if (records.Count > 0)
            {
                var firstRecord = records[0];

                columns = firstRecord.Keys.ToList();
            }

            if (columns.Count == 0)
            {
                throw new Exception("JSON не содержит данных!");
            }

            Console.WriteLine("Заголовки JSON: " + string.Join(", ", columns));

            // creating a dynamic model
            var assemblyName = new AssemblyName("DynamicModelAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            var typeBuilder = moduleBuilder.DefineType("DynamicModel", TypeAttributes.Public | TypeAttributes.Class);

            // create properties based on JSON columns
            foreach (var column in columns)
            {
                var fieldBuilder = typeBuilder.DefineField("_" + column, typeof(string), FieldAttributes.Private);
                var propertyBuilder = typeBuilder.DefineProperty(column, PropertyAttributes.HasDefault, typeof(string), null);

                var getterMethodBuilder = typeBuilder.DefineMethod("get_" + column, MethodAttributes.Public, typeof(string), Type.EmptyTypes);
                var getterIl = getterMethodBuilder.GetILGenerator();
                getterIl.Emit(OpCodes.Ldarg_0);
                getterIl.Emit(OpCodes.Ldfld, fieldBuilder);
                getterIl.Emit(OpCodes.Ret);

                var setterMethodBuilder = typeBuilder.DefineMethod("set_" + column, MethodAttributes.Public, null, new[] { typeof(string) });
                var setterIl = setterMethodBuilder.GetILGenerator();
                setterIl.Emit(OpCodes.Ldarg_0);
                setterIl.Emit(OpCodes.Ldarg_1);
                setterIl.Emit(OpCodes.Stfld, fieldBuilder);
                setterIl.Emit(OpCodes.Ret);

                propertyBuilder.SetGetMethod(getterMethodBuilder);
                propertyBuilder.SetSetMethod(setterMethodBuilder);
            }

            return typeBuilder.CreateType();
        }

        // transforming data into a model
        static List<object> MapDataToModel(List<Dictionary<string, string>> records, Type modelType)
        {
            var dataList = new List<object>();

            foreach (var row in records)
            {
                if (row == null || row.Count == 0) continue;

                var instance = Activator.CreateInstance(modelType);

                foreach (var kvp in row)
                {
                    var property = modelType.GetProperty(kvp.Key);
                    if (property != null)
                    {
                        property.SetValue(instance, kvp.Value);
                    }
                }
                dataList.Add(instance);
            }

            return dataList;
        }

        // creating a table in a database based on a dynamic model
        static void CreateTableInDatabase(string tableName, Type modelType, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var columns = modelType.GetProperties()
                    .Select(prop => $"[{prop.Name}] NVARCHAR(MAX)") // все колонки - строки (nvarchar(max))
                    .ToList();

                string createTableQuery = $@"
                    IF OBJECT_ID('{tableName}', 'U') IS NULL
                    CREATE TABLE {tableName} (
                        {string.Join(", ", columns)}
                    )";

                using (var command = new SqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
