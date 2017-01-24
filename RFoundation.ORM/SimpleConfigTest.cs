using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFoundation.ORM.Database;

namespace RFoundation.ORM
{
    class SimpleConfigTest
    {
        static void Main(string[] args)
        {
            using (var db = new FileStorageDatabaseContext())
            {
                var ff = db.Friends.First(f => f.Id == 1);
                Console.WriteLine(ff.Id);
                //ProfileImageAndFolders(db);
                FriendsRequestsAndSharedFiles(db);
                //FriendReqOfferTarget(db);
            }
        }

        private static void FriendReqOfferTarget(FileStorageDatabaseContext db)
        {
            var user2 = db.Users.Find(2);
            Console.WriteLine("REQUESTS: \n");
            var friendReq = user2.FriendRequests.ToList();
            foreach (var friendRequest in friendReq)
            {
                Console.WriteLine(friendRequest.User.Id + " ID");
                Console.WriteLine(friendRequest.FromUserId + " FromID");
                Console.WriteLine(friendRequest.ToUserId + " To ID");
                Console.WriteLine(friendRequest.TargetUser.Id + " TARGET USER: ID");
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("OFFERS: \n");
            var friendOffers = user2.FriendOffers.ToList();

            foreach (var friendRequest in friendOffers)
            {
                Console.WriteLine(friendRequest.User.Id + " ID");
                Console.WriteLine(friendRequest.FromUserId + " FromID");
                Console.WriteLine(friendRequest.ToUserId + " To ID");
                Console.WriteLine(friendRequest.TargetUser.Id + " TARGET USER: ID");
            }
        }

        private static void ProfileImageAndFolders(FileStorageDatabaseContext db)
        {
            var user2 = db.Users.Find(2);

            var files = user2.Files;
            var profileImage = user2.ProfileImageFileId;
            Console.WriteLine(profileImage + " PFIID");
            var profileImageFile = user2.ProfileImageFile;
            Console.WriteLine(profileImageFile.Name + " PFI_NAME_ID");

            foreach (var user2File in user2.Files)
            {
                Console.WriteLine("FILE ID:" + user2File.Id);
                Console.WriteLine("Parent_FOlDer ID:" + user2File.ParentFileFolderId);

                if (user2File?.IsFolder == true)
                    foreach (var user2FileChildFile in user2File.ChildFiles)
                    {
                        Console.WriteLine("-----childOfChild ID:" + user2FileChildFile.Id);
                        Console.WriteLine("-----ParentOfChild ID:" + user2FileChildFile.ParentFileFolderId);
                        Console.WriteLine("-----ParentFile ID:" + user2FileChildFile.ParentFile.Id);

                        if (user2FileChildFile?.IsFolder == true)
                            foreach (var childFile in user2FileChildFile.ChildFiles)
                            {
                                Console.WriteLine("-------------childOfChild ID:" + childFile.Id);
                                Console.WriteLine("-------------ParentOfChild ID:" + childFile.ParentFileFolderId);
                                Console.WriteLine("-------------ParentFile ID:" + childFile.ParentFile.Id);
                            }
                    }
                Console.WriteLine("\n");
            }
        }

        private static void FriendsRequestsAndSharedFiles(FileStorageDatabaseContext db)
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
                
                Console.WriteLine("friend.USerID: " + friend.UserId);
                Console.WriteLine("friend.FriendID: " + friend.FriendId);
                Console.WriteLine("USERID: " + friend.User.Id);
                Console.WriteLine("friend.FriendUser.Id: " + friend.FriendUser.Id);
                //Console.WriteLine(friend.UserId); //friend id == if from friend table
            }
            Console.WriteLine($"friendsR{new string(" - ".ToCharArray()[1], 10)}");
            var friends1 = user2.FriendsReserved.ToList();
            foreach (var friend in friends1)
            {
                Console.WriteLine("friend.USerID: " + friend.UserId);
                Console.WriteLine("friend.FriendID: " + friend.FriendId);
                Console.WriteLine("USERID: " + friend.User.Id);
                Console.WriteLine("friend.FriendUser.Id: " + friend.FriendUser.Id);
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
                Console.WriteLine(sharedFile.OwnerUser.Id + " SF OWNER Id!!!");
                Console.WriteLine(sharedFile.RecipientUser.Id + " SF REcip Id!!!");
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

                Console.WriteLine(sharedFile.OwnerUser.Id + " SF OWNER Id!!!");
                Console.WriteLine(sharedFile.RecipientUser.Id + " SF Recipient Id!!!");
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