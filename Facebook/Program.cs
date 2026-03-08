using SocialMedia.SocialMedia.Lib.Repositories;
using SocialMedia.SocialMedia.Lib.Services;


namespace SocialMedia.ConsoleApp;

class Program
{
    // Dependencies (Static so they are accessible by all methods)
    private static readonly UserRepository UserRepo = new();
    private static readonly PostRepository PostRepo = new();
    private static readonly UserService UserService = new(UserRepo);
    private static readonly AuthService AuthService = new(UserRepo);
    private static readonly PostService PostService = new(PostRepo);

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== SOCIAL PLATFORM CLONE ===");

            if (AuthService.CurrentUser == null)
            {
                ShowGuestMenu();
            }
            else
            {
                ShowUserMenu();
            }

            string choice = Console.ReadLine() ?? "";
            running = HandleInput(choice);
        }
    }

    static void ShowGuestMenu()
    {
        Console.WriteLine("1. Register New Account");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");
        Console.Write("\nSelect an option: ");
    }

    static void ShowUserMenu()
    {
        Console.WriteLine($"Welcome back, {AuthService.CurrentUser!.Username}!");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Create a New Post");
        Console.WriteLine("2. View Feed (Like/Comment)");
        Console.WriteLine("3. Logout");
        Console.WriteLine("4. Exit");
        Console.Write("\nSelect an option: ");
    }

    static bool HandleInput(string choice)
    {
        if (AuthService.CurrentUser == null)
        {
            switch (choice)
            {
                case "1": Register(); return true;
                case "2": Login(); return true;
                case "3": return false;
                default: return true;
            }
        }
        else
        {
            switch (choice)
            {
                case "1": CreatePost(); return true;
                case "2": ViewFeed(); return true;
                case "3": AuthService.Logout(); return true;
                case "4": return false;
                default: return true;
            }
        }
    }

    #region Actions

    static void Register()
    {
        Console.Clear();
        Console.WriteLine("--- Register ---");
        Console.Write("Enter Username: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter Password: ");
        string pass = Console.ReadLine() ?? "";
        Console.Write("Enter Age: ");

        if (byte.TryParse(Console.ReadLine(), out byte age))
        {
            UserService.RegisterUser(name, pass, age);
        }
        else
        {
            Console.WriteLine("Invalid age. Registration failed.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void Login()
    {
        Console.Clear();
        Console.WriteLine("--- Login ---");
        Console.Write("Username: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string pass = Console.ReadLine() ?? "";

        AuthService.Login(name, pass);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void CreatePost()
    {
        Console.Clear();
        Console.WriteLine("--- Create Post ---");
        Console.Write("What's on your mind? ");
        string content = Console.ReadLine() ?? "";

        PostService.CreatePost(AuthService.CurrentUser!, content);

        Console.WriteLine("\nPost shared! Press any key...");
        Console.ReadKey();
    }

    static void ViewFeed()
    {
        Console.Clear();
        Console.WriteLine("--- News Feed ---");
        var posts = PostRepo.GetAll().ToList();

        if (!posts.Any())
        {
            Console.WriteLine("No posts yet. Be the first to post!");
        }
        else
        {
            for (int i = 0; i < posts.Count; i++)
            {
                var post = posts[i];
                Console.WriteLine($"[{i + 1}] {post.authorId}: {post.Content}");
                Console.WriteLine($"    Likes: {post.LikeCount} | Created: {post.CreatedAt}");
                Console.WriteLine("    --------------------------");
            }

            Console.WriteLine("\nEnter Post Number to Like, or '0' to go back:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= posts.Count)
            {
                posts[index - 1].Like();
                Console.WriteLine("You liked this post!");
            }
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    #endregion
}