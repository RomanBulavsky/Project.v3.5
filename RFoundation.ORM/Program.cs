using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFoundation.ORM.Database;

namespace RFoundation.ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new FileStorageDatabaseContext())
            {
                var user2 = db.Users.Find(2);


                //user2.SharedFiles.Add(new SharedFile()
                //{
                //    FileId = 11,
                //    OwnerId = user2.Id,
                //    RecipientId = 3
                //});
                //db.SaveChanges();


                Console.WriteLine($"friends{new string(" - ".ToCharArray()[1], 10)}");
                var friends = user2.Friends.ToList();
                foreach (var friend in friends)
                {
                    Console.WriteLine(friend.UserId); //friend id == if from friend table
                }
                Console.WriteLine($"friendsR{new string(" - ".ToCharArray()[1], 10)}");
                var friends1 = user2.FriendsReserved.ToList();
                foreach (var friend in friends1)
                {
                    Console.WriteLine(friend.UserId);
                    //Console.WriteLine("fRIENDID");
                    //Console.WriteLine(friend.FriendId);
                }
                Console.WriteLine($"FriendReq{new string(" - ".ToCharArray()[1], 10)}");
                var friendReq = user2.FriendRequests.ToList();
                foreach (var friendRequest in friendReq)
                {
                    Console.WriteLine("from");
                    Console.WriteLine(friendRequest.FromUserId);
                    Console.WriteLine("to");
                    Console.WriteLine(friendRequest.ToUserId);
                }
                Console.WriteLine($"FriendReq1{new string(" - ".ToCharArray()[1], 10)}");
                var friendReq1 = user2.FriendOffers.ToList();
                foreach (var friendRequest in friendReq1)
                {
                    Console.WriteLine("from");
                    Console.WriteLine(friendRequest.FromUserId);
                    Console.WriteLine("to");
                    Console.WriteLine(friendRequest.ToUserId);
                }
                Console.WriteLine($"SharedFiles{new string(" - ".ToCharArray()[1], 10)}");


                var sFiles = user2.SharedFiles.ToList();
                foreach (var sharedFile in sFiles)
                {
                    Console.WriteLine("ownerId");
                    Console.WriteLine(sharedFile.OwnerId);
                    Console.WriteLine("recepientId");
                    Console.WriteLine(sharedFile.RecipientId);
                    Console.WriteLine("fileID");
                    Console.WriteLine(sharedFile.FileId);
                }
                Console.WriteLine($"SharedFiles1{new string(" - ".ToCharArray()[1], 10)}");
                var sFiles1 = user2.ReceivedFiles.ToList();
                foreach (var sharedFile in sFiles1)
                {
                    Console.WriteLine("ownerId");
                    Console.WriteLine(sharedFile.OwnerId);
                    Console.WriteLine("recepientId");
                    Console.WriteLine(sharedFile.RecipientId);
                    Console.WriteLine("fileID");
                    Console.WriteLine(sharedFile.FileId);
                }
            }
        }
    }
}