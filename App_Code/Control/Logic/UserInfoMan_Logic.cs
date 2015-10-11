using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace LogicLayer
{
    /// <summary>
    /// Summary description for UserInfoMan_Logic
    /// </summary>
    public class UserInfoMan_Logic
    {
        public List<User_cls> GetLanguageEditors()
        {
            User_cls user = new User_cls();
            DataTable dt = user.GetLanguageEditors();
            List<User_cls> usersList = User_cls.ConvertDTToUserList(dt);
            return usersList;
        }
        public Role GetRole(int userID)
        {
            SysClient sysClient = new SysClient();
            sysClient.UserID = userID;
            DataTable dt = sysClient.GetRol();
            Role role = Role.Convert(dt);
            return role;
        }
        public DBmessage EditUserImage(int id , byte[] image)
        {
            User_cls user = new User_cls();
            user.UserID = id;
            user.Image = image;
            return user.EditImage();
        }
        public FullUser GetUserFullInfo(int id)
        {
            bool author;
            bool referee;
            bool editor;
            FullUser fullUser = new FullUser();
            User_cls user = GetUserInfo(id, out author, out referee, out editor);
            fullUser.User = new User_cls();
            fullUser.User = user;
            if (author)
            {
                Author myauthor = new Author();
                myauthor.User = new User_cls();
                myauthor.User.UserID = id;
                DataTable authordt = myauthor.InfoGet();
                myauthor = Author.Convert(authordt);
                myauthor.User = user;
                fullUser.Author = myauthor;
            }
            if (referee)
            {
                Referee myreferee = new Referee();
                myreferee.User = new User_cls();
                myreferee.User.UserID = id;
                DataTable refereedt = myreferee.InfoGet();
                myreferee = Referee.Convert(refereedt);
                myreferee.User = user;
                fullUser.Referee = myreferee;
            }
            if (editor)
            {
                Editor myeditor = new Editor();
                myeditor.User = new User_cls();
                myeditor.User.UserID = id;
                DataTable refereedt = myeditor.InfoGet();
                myeditor = Editor.Convert(refereedt);
                myeditor.User = user;
                fullUser.Editor = myeditor;
            }
            return fullUser;
        }
        public DBmessage ChangePassword(int userId, string password)
        {
            User_cls user = new User_cls();
            user.UserID = userId;
            user.Password = password;
            DBmessage dbm = user.ChangePassword();
            return dbm;
        }
        public DBmessage ChangePassword(int userId, string oldPassword , string newPassword)
        {
            User_cls user = new User_cls();
            user.UserID = userId;
            user.Password = oldPassword;
            DBmessage dbm = user.ChangePassword(newPassword);
            return dbm;
        }
        public List<User_cls> GetRefereeList()
        {
            Referee refe = new Referee();
            DataTable dt = refe.Get();
            List<User_cls> Result = new List<User_cls>();
            foreach (DataRow item in dt.Rows)
            {
                Result.Add(new User_cls()
                {
                    UserID = Convert.ToInt32(item["RefereeUserId"]),
                    FullName = item["RefereeFullName"].ToString(),
                    Email = item["Email"].ToString()
                });

            }
            return Result;
        }
        /// <summary>
        /// sabte yek nevisande
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="title"></param>
        /// <param name="institu"></param>
        /// <param name="department"></param>
        /// <param name="prof"></param>
        /// <returns></returns>
        public DBmessage RegisterAuthor(int userId, string title, string institu, string department, string prof)
        {
            Author author = new Author
            {
                Title = title,
                Institu = institu,
                Department = department,
                Prof = prof
            };
            author.User = new User_cls();
            author.User.UserID = userId;
            return author.Register();
        }
        public DBmessage RegisterReferee(int userId)
        {
            Referee referee = new Referee();
            referee.User = new User_cls();
            referee.User.UserID = userId;
            return referee.Register();
        }
        public DBmessage RegisterRole(int userID, Role newRole, Role oldRole)
        {
            DBMessageType msgAuthorType = DBMessageType.Sucsess;
            DBMessageType msgEditorType = DBMessageType.Sucsess;
            DBMessageType msgRefereeType = DBMessageType.Sucsess;

            if (oldRole[RoleType.Author] && newRole[RoleType.Author])
            {
                msgAuthorType = DBMessageType.Sucsess;
            }
            else if(!oldRole[RoleType.Author] && newRole[RoleType.Author])
            {
                DBmessage resultAuthor = RegisterAuthor(userID, "", "", "", "");
                msgAuthorType = resultAuthor.Type;
            }
            else if (oldRole[RoleType.Author] && !newRole[RoleType.Author])
            {
                DBmessage resultAuthor = DeleteAuthor(userID);
                msgAuthorType = resultAuthor.Type;
            }
            //
            if (oldRole[RoleType.Editor] && newRole[RoleType.Editor])
            {
                msgEditorType = DBMessageType.Sucsess;
            }
            else if (!oldRole[RoleType.Editor] && newRole[RoleType.Editor])
            {
                DBmessage resultEditor = RegisterEditor(userID, "", "");
                msgAuthorType = resultEditor.Type;
            }
            else if (oldRole[RoleType.Editor] && !newRole[RoleType.Editor])
            {
                DBmessage resultEditor = DeleteEditor(userID);
                msgAuthorType = resultEditor.Type;
            }
            //
            if (oldRole[RoleType.Referee] && newRole[RoleType.Referee])
            {
                msgRefereeType = DBMessageType.Sucsess;
            }
            else if (!oldRole[RoleType.Referee] && newRole[RoleType.Referee])
            {
                DBmessage resultReferee = RegisterReferee(userID);
                msgRefereeType = resultReferee.Type;
            }
            else if (oldRole[RoleType.Editor] && !newRole[RoleType.Editor])
            {
                DBmessage resultReferee = DeleteReferee(userID);
                msgRefereeType = resultReferee.Type;
            }
            //
            if (msgAuthorType == DBMessageType.Sucsess && msgEditorType == DBMessageType.Sucsess && msgRefereeType == DBMessageType.Sucsess)
            {
                User_cls user = new User_cls();
                user.UserID = userID;
                user.Roles = newRole;
                return user.RegisterRole();
            }
            else
            {
                if (msgAuthorType == DBMessageType.Sucsess && newRole[RoleType.Author])
                {
                    DeleteAuthor(userID);
                }
                if (msgEditorType == DBMessageType.Sucsess && newRole[RoleType.Editor])
                {
                    DeleteEditor(userID);
                }
                if (msgRefereeType == DBMessageType.Sucsess && newRole[RoleType.Referee])
                {
                    DeleteReferee(userID);
                }
            }
            return new DBmessage(6102);
        }
        public DBmessage DeleteReferee(int userID)
        {
            Referee referee = new Referee();
            referee.User = new User_cls();
            referee.User.UserID = userID;
            return referee.Delete();
        }
        public DBmessage DeleteEditor(int userID)
        {
            Editor editor = new Editor();
            editor.User = new User_cls();
            editor.User.UserID = userID;
            return editor.Delete();
        }
        public DBmessage DeleteAuthor(int userID)
        {
            Author author = new Author();
            author.ID = 0;
            author.User = new User_cls();
            author.User.UserID = userID;
            return author.Delete();
        }
        /// <summary>
        /// sabte name chandin karbar ba ham , dar dar parametre avale return list userid ijad shode mojod ast
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public DBmessage RegisterUser(string username, string hash,PersianDateTime expirationDate, string firstname, string lastname, string affiliations, string phonenumber, string fax, string email, string nationnumber,
            string field, PersianDateTime birthdate, string education, Gender gender, out int id)
        {
            id = 0;
            User_cls user = new User_cls
            {
                Affiliations = affiliations,
                Username = username,
                Hash = hash,
                Fname = firstname,
                Lname = lastname,
                Phone = phonenumber,
                Fax = fax,
                Email = email,
                Melli = nationnumber,
                Fields = field,
                Birthdate = birthdate,
                Education = education,
                Sex = gender,
                ExpHash = expirationDate
            };
            DBmessage result = user.Register(SysProperty.SubSystemID);
            if (result.Type == DBMessageType.Sucsess)
            {
                id = user.UserID;
            }

            return result;

        }
        /// <summary>
        /// sabte name chandin karbar ba ham , dar dar parametre avale return list userid ijad shode mojod ast
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public DBmessage RegisterUsers(List<User_cls> users)
        {
            User_cls user = new User_cls();
            UserTable usrTable = UserTable.Convert(users);
            DBmessage dbm = user.Register(usrTable);
            return dbm;
        }
        public DBmessage RegisterEditor(int userId, string resume, string contacts)
        {
            Editor editor = new Editor
            {
                Resume = resume,
                Contacts = contacts
            };
            editor.User = new User_cls();
            editor.User.UserID = userId;
            return editor.Register();
        }
        /// <summary>
        /// daryaft etelaate user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="author"></param>
        /// <param name="referee"></param>
        /// <param name="editor"></param>
        /// <returns></returns>
        public User_cls GetUserInfo(int id, out bool author, out bool referee, out bool editor)
        {
            User_cls user = new User_cls();
            user.UserID = id;
            DataTable dt = user.InfoGet(out author, out referee, out editor);
            user = User_cls.ConvertDTToUser(dt.Rows[0]);
            return user;
        }
        /// <summary>
        /// daryaft etelaate user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User_cls GetUserInfo(int userID)
        {
            bool author;
            bool referee;
            bool editor;
            return GetUserInfo(userID, out author, out referee, out editor);
        }
        public List<User_cls> GetUsers(RoleType role)
        {
            List<User_cls> users = new List<User_cls>();

            if (role == RoleType.Editor)
                users.Add(GetEditor());
            else if (role == RoleType.Referee)
                users = GetRefereeList();
            else if (role == RoleType.Author)
                users = GetAuthorList();
            else if (role == RoleType.User)
                users = GetUserList();
            else if (role == RoleType.CheifEditor)
                users = GetChefEditorList();
            else if (role == RoleType.Admin)
                users = GetChefEditorList();
            return users;
        }
        public List<User_cls> GetUsersFullInfo(int userID, string affiliations, string fields, string firstname, string lastname,
            string melliNumber, string education, string email, Gender gender)
        {
            User_cls user = new User_cls()
            {
                UserID = userID,
                Affiliations = affiliations,
                Fields = fields,
                Fname = firstname,
                Lname = lastname,
                Melli = melliNumber,
                Education = education,
                Email = email,
                Sex = gender
            };
            DataTable dt = user.FullGet();
            List<User_cls> userList = User_cls.ConvertDTToUserList(dt);
            return userList;
        }
        public User_cls GetEditor()
        {
            Editor editor = new Editor();
            DataTable dt = editor.GetEditor();
            List<User_cls> userList = new List<User_cls>();
            int lastIndex = 0;
            foreach (DataRow item in dt.Rows)
            {
                userList.Add(new User_cls());
                //userList[lastIndex].id = Convert.ToInt32(item["ID"]);
                userList[lastIndex].UserID = Convert.ToInt32(item["UserId"]);
                userList[lastIndex].FullName = item["EditorFullName"].ToString();
                //userList[lastIndex].Contacts = item["Contacts"].ToString();
                //userList[lastIndex].Resume = item["Resume"].ToString();
                //userList[lastIndex].Active = Convert.ToBoolean(item["Active"]);
                //DateTime date = Convert.ToDateTime(item["Date"]);
                //userList[lastIndex].Date = new PersianDateTime(date);
                lastIndex = userList.Count;
            }
            if (userList.Count > 0)
                return userList[0];
            return null;
        }
        public List<User_cls> GetEditorList()
        {
            Editor editor = new Editor();
            DataTable dt = editor.Get();
            List<User_cls> Result = new List<User_cls>();
            foreach (DataRow item in dt.Rows)
            {
                Result.Add(new User_cls()
                {
                    UserID = Convert.ToInt32(item["EditorUserID"]),
                    FullName = item["EditorFullName"].ToString(),
                    Email = item["Email"].ToString()
                });

            }
            return Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="affiliations"></param>
        /// <param name="phone"></param>
        /// <param name="fax"></param>
        /// <param name="fields"></param>
        /// <param name="nationalcode"></param>
        /// <param name="birthdate"></param>
        /// <param name="education"></param>
        /// <param name="sex"></param>
        /// <param name="hash">bejaye password estefade mishad dar login agar password dade shode ba in meghdar barabar bashad va az exphash ham tarikh nagzashte bashad login movafaghiat amiz ast.dar sorat null dadan taghiri dar in field ijad nemishavad</param>
        /// <param name="exphash">tarikh enghezaye meghdar has, dar sorat null dadan taghiri dar in field ijad nemishavad</param>
        /// <returns></returns>
        public DBmessage EditUser(int id,string username,string email, string firstname, string lastname, string affiliations, string phone, string fax, string fields,
            string nationalcode, PersianDateTime birthdate, string education, Gender sex,string hash,PersianDateTime exphash )
        {
            User_cls user = new User_cls();
            //
            user.UserID = id;
            user.Fname = firstname;
            user.Lname = lastname;
            user.Affiliations = affiliations;
            user.Phone = phone;
            user.Fax = fax;
            user.Email = email;
            user.Fields = fields;
            user.Username = username;
            user.Melli = nationalcode;
            user.Birthdate = birthdate;
            user.Education = education;
            user.Sex = sex;
            user.Hash = hash;
            user.ExpHash = exphash;
            //
            DBmessage dbm = user.Edit();
            return dbm;
        }
        
        public List<User_cls> GetUserList()
        {
            User_cls usr = new User_cls();
            DataTable dt = usr.Get();
            List<User_cls> Result = new List<User_cls>();
            foreach (DataRow item in dt.Rows)
            {
                Result.Add(new User_cls()
                {
                    UserID = Convert.ToInt32(item["UserID"]),
                    FullName = item["FullName"].ToString()
                });
            }
            return Result;
        }
        public List<User_cls> GetAuthorList()
        {
            Author author = new Author();
            DataTable dt = author.Get();
            List<User_cls> Result = new List<User_cls>();
            foreach (DataRow item in dt.Rows)
            {
                Result.Add(new User_cls()
                {
                    UserID = Convert.ToInt32(item["AuthorUserID"]),
                    FullName = item["AuthorFullName"].ToString()
                });
            }
            return Result;
        }
        public List<User_cls> GetChefEditorList()
        {
            User_cls user = new User_cls();
            DataTable dt = user.Get();
            List<User_cls> Result = new List<User_cls>();
            foreach (DataRow item in dt.Rows)
            {
                Result.Add(new User_cls()
                {
                    UserID = Convert.ToInt32(item["UserID"]),
                    FullName = item["FullName"].ToString(),
                    Email = item["Email"].ToString()
                });
            }
            return Result;
        }
    }


}