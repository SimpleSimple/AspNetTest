using System.Collections.Generic;
using System.Linq;
using Console.Tests.Entity;

namespace Console.Tests
{
    using ServiceStack.Text;
    using ServiceStack.Redis;
    using System;

    class Program
    {
        static RedisClient client = new RedisClient("172.16.41.237", 6379);

        static void Main(string[] args)
        {
            Console.WriteLine("1. 显示所有KEYS");
            Console.WriteLine("2. 添加测试数据");
            Console.WriteLine("3. 删除所有KEYS");
            Console.WriteLine("4. 添加列表");
            Console.WriteLine("5. 显示Blog列表");

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
                case 5:
                    Show_list_of_blogs();
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

        #region Private Static Methods

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
            var list = new List<Person>{
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

        static void Redis_AddTestData()
        {
            client.FlushAll();
            InsertTestData();
        }
        static void InsertTestData()
        {
            var redisUsers = client.As<User>();
            var redisBlogs = client.As<Blog>();
            var redisBlogPosts = client.As<BlogPost>();

            var yangUser = new User { Id = redisUsers.GetNextSequence(), Name = "Eric Yang" };

            var yangBlog = new Blog
            {
                Id = redisBlogs.GetNextSequence(),
                UserId = yangUser.Id,
                UserName = yangUser.Name,
                Tags = new List<string> { "Architecture", ".NET", "Databases" }
            };

            var blogPosts = new List<BlogPost> 
            {
                new BlogPost
                {
                    Id = redisBlogPosts.GetNextSequence(),
                    BlogId = yangBlog.Id,
                    Title = "Memcache",
                    Categories = new List<string>{"NoSQL", "DocumentDB"},
                    Tags = new List<string>{"Memcache","NoSQL","JSON",".NET"},
                    Comments = new List<BlogPostComment>{
                        new BlogPostComment{Content="First Comment!",CreatedDate=DateTime.UtcNow},
                        new BlogPostComment{Content="Second Comment!",CreatedDate=DateTime.UtcNow}
                    }
                },
                new BlogPost
                {
                    Id = redisBlogPosts.GetNextSequence(),
                    BlogId = yangBlog.Id,
                    Title = "Cassandra",
                    Categories = new List<string> { "NoSQL", "Cluster" },
                    Tags = new List<string> {"Cassandra", "NoSQL", "Scalability", "Hashing"},
                    Comments = new List<BlogPostComment>
                    {
                        new BlogPostComment { Content = "First Comment!", CreatedDate = DateTime.UtcNow,}
                    }
                },
            };

            yangUser.BlogIds.Add(yangBlog.Id);
            yangBlog.BlogPostIds.AddRange(blogPosts.Where(x => x.BlogId == yangBlog.Id).Select(x => x.Id));

            redisUsers.Store(yangUser);
            redisBlogs.StoreAll(new[] { yangBlog });
            redisBlogPosts.StoreAll(blogPosts);

            //var mythzBlogs = new List<Blog> { 
            //        new Blog
            //        {
            //            Id = redisBlogs.GetNextSequence(),
            //            UserId = mythz.Id,
            //            UserName = mythz.Name,
            //            Tags = new List<string> { "Architecture", ".NET", "Redis" },
            //        },
            //        new Blog
            //        {
            //            Id = redisBlogs.GetNextSequence(),
            //            UserId = mythz.Id,
            //            UserName = mythz.Name,
            //            Tags = new List<string> { "Music", "Twitter", "Life" },
            //        }
            //};

            //mythzBlogs.ForEach(x => mythz.BlogIds.Add(x.Id));

            //redisUsers.Store(mythz);
            //redisBlogs.StoreAll(mythzBlogs);

            //retrieve all blogs
            //var blogs = redisBlogs.GetAll();

            //Console.WriteLine(blogs.Dump());
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

        #region 显示文章及其所有评论
        static void Show_post_and_all_comments()
        {
            int postId = 1;
            var redisBlogPosts = client.As<BlogPost>();
            var blogPost = redisBlogPosts.GetById(postId);
            Console.Write(blogPost.Dump());
        }
        #endregion

        #endregion
    }

}
