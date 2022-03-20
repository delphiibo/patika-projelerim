using System;
using System.Collections.Generic;

namespace project2_todo_list
{
    static class TeamUsers
    {
        static List<TeamUserModel> teamUsers;
        static TeamUsers() {
            teamUsers = new List<TeamUserModel>();
        }
        public static List<TeamUserModel> List()
        {
            return teamUsers;
        }
        public static void Add(int id,string KullaniciAdi) 
        {
            TeamUserModel teamUserModel = new TeamUserModel();
            teamUserModel.Id = id;
            teamUserModel.KullaniciAdi = KullaniciAdi;
            teamUsers.Add(teamUserModel);
        }

        public static TeamUserModel Find(string KullaniciAdi)
        {
            TeamUserModel teamUserModel = new TeamUserModel();
            teamUserModel.Id=0;
            teamUserModel.KullaniciAdi ="";
            foreach (var item in teamUsers)
            {
                if (item.KullaniciAdi==KullaniciAdi) {
                    teamUserModel = item;
                }
            }
            return teamUserModel;
        }

        public static TeamUserModel Find(int id)
        {
            TeamUserModel teamUserModel = new TeamUserModel();
            teamUserModel.Id=0;
            teamUserModel.KullaniciAdi ="";
            foreach (var item in teamUsers)
            {
                if (item.Id==id) {
                    teamUserModel = item;
                }
            }
            return teamUserModel;
        }

    }
}