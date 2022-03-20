using System;
using System.Collections.Generic;

namespace project2_todo_list
{
    static class Boards
    {
        public static Dictionary<string,List<CartModel>> Board = new Dictionary<string,List<CartModel>>();
        public static List<CartModel> TodoLine = new List<CartModel>();
        public static List<CartModel> InProgressLine = new List<CartModel>();
        public static List<CartModel> DoneLine = new List<CartModel>();
        
        public static List<CartModel> Find(List<CartModel> list,string baslik)
        {
            List<CartModel> tempList = new List<CartModel>();
            foreach (var item in list)
            {
                if (item.Baslik==baslik)
                    tempList.Add(item);
            }
            return tempList;
        }
    }
}