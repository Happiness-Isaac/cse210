using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Learn C# in 10 Minutes", "CodeWithMike", 600);
        video1.AddComment(new Comment("Alice", "This helped me so much!"));
        video1.AddComment(new Comment("Bob", "Clear and concise explanation."));
        video1.AddComment(new Comment("Carol", "Please make a follow-up on classes."));

        Video video2 = new Video("Abstraction Explained Simply", "DevDaily", 420);
        video2.AddComment(new Comment("Dan", "Best explanation I've seen."));
        video2.AddComment(new Comment("Eve", "I finally get abstraction."));
        video2.AddComment(new Comment("Frank", "Can you cover inheritance next?"));

        Video video3 = new Video("Building Your First Console App", "LearnToCode", 780);
        video3.AddComment(new Comment("Grace", "Super beginner friendly."));
        video3.AddComment(new Comment("Hank", "Loved the examples."));
        video3.AddComment(new Comment("Ivy", "Subscribed!"));

        Video video4 = new Video("Understanding Polymorphism", "CodeMaster", 540);
        video4.AddComment(new Comment("Jack", "Polymorphism finally makes sense."));
        video4.AddComment(new Comment("Kathy", "Thanks for the clear examples."));
        video4.AddComment(new Comment("Liam", "Looking forward to the next video!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}