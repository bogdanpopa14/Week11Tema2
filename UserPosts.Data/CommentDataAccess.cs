using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserPosts.Domain;
using UserPosts.Services;
using UserPosts.Data;
using System.Threading.Tasks;

namespace UserPosts.Data
{
    public class CommentDataAccess : BaseDataAccess<Comment>, ICommentRepository
    {
        public IList<Comment> GetCommentsByUserId(int id)
        {
            PostDataAccess postsl = new PostDataAccess();
            var post= postsl.GetPostsByUserId(id);
            var list = this.GetAll();
            var result = from x in list
                         join y in post on x.PostId equals y.Id
                         select x;
            return result.ToList();
                        

           
        }

        protected override string GetFile()
        {
            return @"..\..\..\UserPosts.Data\Files\comments.json";
        }
    }
}
