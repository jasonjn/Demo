using Dapper;
using ORMDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDemo
{
   public class DapperService
    {
        private const string connStr = "Data Source=.;Initial Catalog=Demo;Integrated Security=True";

        #region Method01.读取MSSQL单张表
        // 2.7s
      public  static void DapperReadPosts()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                var postList = connection.Query<Post>("select * from Posts");
                foreach (var item in postList)
                {
                    Console.WriteLine("ID:{0},Title:{1}", item.Id, item.Title);
                }
            }
        }
        #endregion

        #region Method02.读取MSSQL连接查询
        // 2.6s
        public static void DapperReadJoin()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // 这里查询结果是动态语言类型
                var postList = connection.Query("select Id,Title,GETDATE() as PostDate from Posts");
                foreach (var item in postList)
                {
                    Console.WriteLine("ID:{0},PostDate:{1}", item.Id, item.PostDate);
                }
            }
        }
        #endregion

        #region Method03.读取MSSQL多个结果集
        // 2.8s
        public static void DapperReadMultiResultSet()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (var reader = connection.QueryMultiple("select * from Posts;select 1000 as Number;"))
                {
                    var postList = reader.Read<Post>();
                    foreach (var item in postList)
                    {
                        Console.WriteLine("ID:{0},Title:{1}", item.Id, item.Title);
                    }
                }
            }
        }
        #endregion

        #region Method04.插入MSSQL新记录
        // 0.37s
        public static void InsertPostRecord()
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // 多次插入单条记录
                int count = connection.Execute("insert into Posts values(@CategoryId, @Slug, @Title, @Published, @Excerpt, @Content);", new { CategoryId = 10, Slug = "BOOK", Title = "大话设计模式", Published = DateTime.Now.AddDays(1), Excerpt = "ChengJie", Content = "Design Patterns" });
                Console.WriteLine("受影响行数:{0}", count);

                count = connection.Execute("insert into Posts values(@CategoryId, @Slug, @Title, @Published, @Excerpt, @Content);", new Post() { CategoryId = 10, Slug = "BOOK", Title = "大话数据结构", Published = DateTime.Now.AddDays(1), Excerpt = "ChengJie", Content = "Data Structure" });

                Console.WriteLine("受影响行数:{0}", count);

                // 一次插入多条记录
                IList<Post> postRecords = new List<Post>();
                postRecords.Add(new Post() { CategoryId = 10, Slug = "BOOK", Title = "构建之法-现代软件工程", Published = DateTime.Now.AddDays(1), Excerpt = "ZouXin", Content = "Software Engineering" });
                postRecords.Add(new Post() { CategoryId = 10, Slug = "BOOK", Title = "编程之美", Published = DateTime.Now.AddDays(1), Excerpt = "ZouXin", Content = "I Love Coding" });
                count = connection.Execute("insert into Posts values(@CategoryId, @Slug, @Title, @Published, @Excerpt, @Content);", postRecords);

                Console.WriteLine("受影响行数:{0}", count);
            }
        }
        #endregion
    }
}
