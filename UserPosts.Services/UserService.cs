namespace UserPosts.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;

        public UserService(IUserRepository userRepository, IPostRepository postRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
        }

        public UserActiveRespose GetUserActiveRespose(int id)
        {
            var response = new UserActiveRespose();

            var user = this.userRepository.GetById(id);

            response.Email = user.Email;

            var posts = this.postRepository.GetPostsByUserId(id);

            var numberOfPosts = posts.Count;

            if(numberOfPosts < 5)
            {
                response.Status = UserPostsStatus.Inactive;
            }
            else
            {
                if (numberOfPosts > 5 && numberOfPosts < 10)
                {
                    response.Status = UserPostsStatus.Active;
                }
                else
                {
                    if (numberOfPosts >= 10)
                    {
                        response.Status = UserPostsStatus.Superactive;
                    }
                }
            }
           
            return response;
        }
    }

    public class UserActiveRespose
    {
        public string Email { get; set; }

        public UserPostsStatus Status { get; set; }
    }

    public enum UserPostsStatus
    {
        Inactive,
        Active, 
        Superactive
    }
}
