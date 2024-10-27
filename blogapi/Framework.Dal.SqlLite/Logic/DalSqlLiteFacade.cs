using Framework.App.Model;
using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Framework.Dal.SqlLite.Logic
{
    public class DalSqlLiteFacade(IBloggingContext db) : IDalFacade, IDefaultDataProvider
    {
        public DbContext dbUtil => (DbContext)db;

        public List<DataDto> GetList(EventArgs e)
        {
            databaseTest();

            var returnList = new List<DataDto>();

            // Add the string provided by BLL
            var args = e as DataEventArgs<string>;
            returnList.Add(new DataDto { Data = args.Data });

            // Add any data from the blog list
            var dataList = db.Blogs.ToList();
            foreach (var record in dataList)
            {
                var postData = "";
                foreach (var post in record.Posts)
                {
                    postData += $"{post.PostId}: {post.Title} |  {post.Content}";
                }
                returnList.Add(new DataDto { Data = $"{record.BlogId}: {record.Url} \r\n{postData}" });
            }

            return returnList;
        }

        private void databaseTest()
        {
            var blog = db.Blogs.OrderBy(b => b.BlogId).Last();

            // Create
            dbUtil.Add(new Blog { Url = $"{DateTime.Now}:: http://blogs.msdn.com/adonet" });
            dbUtil.SaveChanges();

            // Read
            blog = db.Blogs.OrderByDescending(o => o.BlogId).FirstOrDefault();

            blog.Posts.Add(
                new Post { BlogId = blog.BlogId, Title = $"{DateTime.Now}:: Hello World", Content = "I wrote an app using EF Core!" });

            dbUtil.SaveChanges();
        }
    }
}
