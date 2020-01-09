using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserPosts.Domain;
using System.Threading.Tasks;

namespace UserPosts.Services
{
    public interface ICommentRepository:IBaseRepository<Comment>
    {
        IList<Comment> GetCommentsByUserId(int id);
    }
}
