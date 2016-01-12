using System.Collections.Generic;
using Console.Tests.Entity;

namespace Console.Tests
{
    using ServiceStack.Text;
    using ServiceStack.Redis;
    using System;

    class Program
    {
        static RedisClient client = new RedisClient("127.0.0.1", 6370);

        static void Main(string[] args)
        {
            //ServiceStack.Licensing.RegisterLicense(@"1001-e1JlZjoxMDAxLE5hbWU6VGVzdCBCdXNpbmVzcyxUeXBlOkJ1c2luZXNzLEhhc2g6UHVNTVRPclhvT2ZIbjQ5MG5LZE1mUTd5RUMzQnBucTFEbTE3TDczVEF4QUNMT1FhNXJMOWkzVjFGL2ZkVTE3Q2pDNENqTkQyUktRWmhvUVBhYTBiekJGUUZ3ZE5aZHFDYm9hL3lydGlwUHI5K1JsaTBYbzNsUC85cjVJNHE5QVhldDN6QkE4aTlvdldrdTgyTk1relY2eis2dFFqTThYN2lmc0JveHgycFdjPSxFeHBpcnk6MjAxMy0wMS0wMX0=");
            //var appHost = new AppHost();
            //appHost.Init();

            Console.WriteLine("1. 显示所有KEYS\r\n2. 添加测试数据\r\n3. 删除所有KEYS\r\n4. 添加列表");
            Console.Write("输入选择：");
            int command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 1:
                    Redis_GetAllKeys_Test();
                    break;
                case 2:
                    RedisClient_Test();
                    break;
                case 3:
                    Redis_DeleteAll_Test();
                    break;
                case 4:
                    Redis_AddList_Test();
                    break;
                default: break;
            }

            try
            {
                var redisUsers = client.As<User>();
                redisUsers.Store(new User { Id = redisUsers.GetNextSequence(), Name = "mengluo" });
                redisUsers.Store(new User { Id = redisUsers.GetNextSequence(), Name = "tianming" });

                var allUsers = redisUsers.GetAll();
                Console.WriteLine(allUsers.Dump());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        static void Redis_GetAllKeys_Test()
        {
            Console.WriteLine("显示所有KEYS，共" + client.GetAllKeys().Count + "条");
            client.GetAllKeys().ForEach(x => Console.WriteLine("-->" + x.ToString() + "  "));
            if (client.ContainsKey("Person"))
            {
                Console.WriteLine("包含Key：Person");
            }
        }

        static void RedisClient_Test()
        {
            //if (client.Set<Person>("person", new Person { Id = 0001, Name = "tangxueli", Phone = "13352336966" }))
            //{
            //    Console.WriteLine("录入实体成功");
            //}
            //else return;

            //var person = client.Get<Person>("person");
            //Console.WriteLine(string.Format("Id:{0}\r\nName:{1}\r\nPhone:{2}", person.Id, person.Name, person.Phone));

            List<Person> list = new List<Person>() {
                new Person { Id = 0001, Name = "tangxueli", Phone = "13352336966" },
                new Person{Id=0002, Name="tanglala", Phone="13132002536"},
                new Person{Id=0003, Name="xuweiyi", Phone="13132002536"},
                new Person{Id=0004, Name="xiaokeai", Phone="13535336966"},
                new Person{Id=0005, Name="xuyiting", Phone="13266335553"},
                new Person{Id=0006, Name="liuzaishi", Phone="13225886956"}
            };
            client.StoreAll(list);
            foreach (var item in client.GetAll<Person>())
            {
                Console.WriteLine(string.Format("Id:{0}\r\nName:{1}\r\nPhone:{2}", item.Id, item.Name, item.Phone));
            }
        }

        static void Redis_DeleteAll_Test()
        {
            client.FlushDb();
            Console.WriteLine("执行成功!");
        }

        static void Redis_AddList_Test()
        {
            var list = new List<Person>{ 
                            new Person{Id=2001,Name="tangxueli", Phone="12345689963"},
                            new Person{Id=2002,Name="tangyifeng", Phone="12345689963"},
                            new Person{Id=2003,Name="xietianhua", Phone="12345689963"},
                            new Person{Id=2004,Name="shenjunru", Phone="12345689963"}
            };
            if (client.Add<List<Person>>("Person", list))
            {
                Console.WriteLine("添加数据：");
                client.GetAllKeys().ForEach(x => Console.WriteLine(x));
            }

        }

        static void Show_list_of_blogs()
        {
            var redisUsers = client.As<User>();
            var redisBlogs = client.As<Blog>();
            var mythz = new User { Id = redisUsers.GetNextSequence(), Name = "Demis Bellot" };

            var mythzBlogs = new List<Blog> { 
                    new Blog
                    {
                        Id = redisBlogs.GetNextSequence(),
                        UserId = mythz.Id,
                        UserName = mythz.Name,
                        Tags = new List<string> { "Architecture", ".NET", "Redis" },
                    },
                    new Blog
                    {
                        Id = redisBlogs.GetNextSequence(),
                        UserId = mythz.Id,
                        UserName = mythz.Name,
                        Tags = new List<string> { "Music", "Twitter", "Life" },
                    }
            };

            mythzBlogs.ForEach(x => mythz.BlogIds.Add(x.Id));

            redisUsers.Store(mythz);
            redisBlogs.StoreAll(mythzBlogs);

            //retrieve all blogs
            var blogs = redisBlogs.GetAll();

            Console.WriteLine(blogs.Dump());
        }
    }

}
