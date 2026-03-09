using SocialMedia.SocialMedia.Lib.Models;
using SocialMedia.SocialMedia.Lib.Repositories;
using SocialMedia.SocialMedia.Lib.Services;

namespace SocialMedia.ConsoleApp;

class Program
{
    private static readonly UserRepository UserRepo = new();
    private static readonly PostRepository PostRepo = new();
    private static readonly FriendRequestRepository FriendRepo = new();

    private static readonly UserService UserService = new(UserRepo);
    private static readonly AuthService AuthService = new(UserRepo);
    private static readonly PostService PostService = new(PostRepo);
    private static readonly CommentService CommentService = new();
    private static readonly FriendService FriendService = new(FriendRepo);

    static void Main(string[] args)
    {
        UserRepo.add(new User("admin", "admin123", 30, UserRole.Admin));

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== ENTERPRISE SOCIAL PLATFORM ===");

            if (AuthService.CurrentUser == null)
            {
                ShowGuestMenu();
                string choice = Console.ReadLine() ?? "";
                running = HandleGuestInput(choice);
            }
            else
            {
                ShowUserMenu();
                string choice = Console.ReadLine() ?? "";
                running = HandleUserInput(choice);
            }
        }
    }

    #region Menus

    static void ShowGuestMenu()
    {
        Console.WriteLine("1. Register New Account");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");
        Console.Write("\nSelect an option: ");
    }

    static void ShowUserMenu()
    {
        var user = AuthService.CurrentUser!;
        Console.WriteLine($"Logged in as: {user.Username} ({user.Role})");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Create a New Post");
        Console.WriteLine("2. View News Feed (Like/Comment)");
        Console.WriteLine("3. Friends Management (Requests)");

        if (user.Role == UserRole.Admin)
        {
            Console.WriteLine("A. Admin Dashboard (View All Users)");
        }

        Console.WriteLine("L. Logout");
        Console.WriteLine("E. Exit");
        Console.Write("\nSelect an option: ");
    }

    #endregion

    #region Input Handlers

    static bool HandleGuestInput(string choice)
    {
        switch (choice)
        {
            case "1": Register(); return true;
            case "2": Login(); return true;
            case "3": return false;
            default: return true;
        }
    }

    static bool HandleUserInput(string choice)
    {
        switch (choice.ToUpper())
        {
            case "1": CreatePost(); return true;
            case "2": ViewFeed(); return true;
            case "3": ManageFriends(); return true;
            case "A":
                if (AuthService.CurrentUser?.Role == UserRole.Admin) ViewAllUsers();
                return true;
            case "L": AuthService.Logout(); return true;
            case "E": return false;
            default: return true;
        }
    }

    #endregion

    #region Actions

    static void Register()
    {
        Console.Clear();
        Console.WriteLine("--- Register ---");
        Console.Write("Username: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Password: ");
        string pass = Console.ReadLine() ?? "";
        Console.Write("Age: ");

        if (byte.TryParse(Console.ReadLine(), out byte age))
        {
            UserService.RegisterUser(name, pass, age);
        }
        else
        {
            Console.WriteLine("Invalid age. Registration failed.");
        }
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
        Console.ReadKey();
    }

    static void CreatePost()
    {
        Console.Clear();
        Console.Write("What's on your mind? ");
        string content = Console.ReadLine() ?? "";
        PostService.CreatePost(AuthService.CurrentUser!, content);
        Console.ReadKey();
    }

    static void ViewFeed()
    {
        Console.Clear();
        Console.WriteLine("--- News Feed ---");
        var posts = PostRepo.GetAll().ToList();

        if (!posts.Any())
        {
            Console.WriteLine("No posts yet.");
        }
        else
        {
            for (int i = 0; i < posts.Count; i++)
            {
                var p = posts[i];
                Console.WriteLine($"[{i + 1}] {p.authorId}: {p.Content}");
                Console.WriteLine($"    Likes: {p.LikedByUsers.Count} | Comments: {p.Comments.Count}");
                Console.WriteLine("    --------------------------");
            }

            Console.WriteLine("\nEnter Post Number to Interact (or 0 to back):");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= posts.Count)
            {
                InteractWithPost(posts[idx - 1]);
            }
        }
        Console.ReadKey();
    }

    static void InteractWithPost(Post post)
    {
        Console.Clear();
        Console.WriteLine($"Post by {post.authorId}: {post.Content}");
        Console.WriteLine("\n--- Comments ---");
        foreach (var c in post.Comments) Console.WriteLine($"- {c.authorId}: {c.Content}");

        Console.WriteLine("\n1. Like/Unlike | 2. Add Comment | 3. Back");
        string choice = Console.ReadLine();

        if (choice == "1")
            PostService.LikePost(post, AuthService.CurrentUser!.Username);
        else if (choice == "2")
        {
            Console.Write("Comment text: ");
            string text = Console.ReadLine() ?? "";
            CommentService.AddComment(post, AuthService.CurrentUser!, text);
        }
    }

    static void ManageFriends()
    {
        Console.Clear();
        Console.WriteLine("--- Friends Management ---");
        Console.WriteLine("1. Send Friend Request");
        Console.WriteLine("2. View Pending Requests");
        Console.WriteLine("3. View My Friends List"); // New Option
        Console.WriteLine("4. Back");

        string choice = Console.ReadLine();
        string currentUser = AuthService.CurrentUser.Username;

        if (choice == "1")
        {
            Console.Write("Enter Username to add: ");
            string target = Console.ReadLine() ?? "";
            FriendService.SendRequest(currentUser, target);
            Console.ReadKey();
        }
        else if (choice == "2")
        {
            var incoming = FriendRepo.GetIncomingRequests(currentUser).ToList();
            if (!incoming.Any())
            {
                Console.WriteLine("No pending requests.");
            }
            else
            {
                foreach (var r in incoming)
                {
                    Console.Write($"Request from {r.SenderUsername}. Accept? (y/n): ");
                    bool accept = Console.ReadLine()?.ToLower() == "y";
                    FriendService.RespondToRequest(r.Id, accept);
                }
            }
            Console.ReadKey();
        }
        else if (choice == "3") // Show Friends Logic
        {
            Console.WriteLine("\n--- My Friends ---");
            var friends = FriendService.GetFriendsList(currentUser);

            if (!friends.Any())
            {
                Console.WriteLine("You haven't added any friends yet.");
            }
            else
            {
                foreach (var friendName in friends)
                {
                    Console.WriteLine($"- {friendName}");
                }
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
    static void ViewAllUsers()
    {
        Console.Clear();
        Console.WriteLine("--- ADMIN DASHBOARD: REGISTERED USERS ---");
        foreach (var u in UserRepo.GetAll())
        {
            Console.WriteLine($"- ID: {u.Id} | Name: {u.Username} | Age: {u.Age} | Role: {u.Role}");
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    #endregion
}