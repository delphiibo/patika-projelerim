using System;
using System.Collections.Generic;

namespace project1_phone_book
{
    public class PhoneBook
    {
        private List<PhoneBookModel> phoneBook;
        public PhoneBook()
        {
            phoneBook = new List<PhoneBookModel>();
        }

        public List<PhoneBookModel> List()
        {
            return phoneBook;
        }

        public void Add(string isim, string soyisim, string telefon)
        {
            PhoneBookModel phoneBookModel = new PhoneBookModel();
            phoneBookModel.Isim = isim;
            phoneBookModel.Soyisim = soyisim;
            phoneBookModel.Telefon = telefon;
            phoneBook.Add(phoneBookModel);
        }

        public void Delete(PhoneBookModel phoneBookModel)
        {
            phoneBook.Remove(phoneBookModel);
        }

        public List<PhoneBookModel> Find(string isim, string soyisim, string telefon)
        {
            List<PhoneBookModel> result = new List<PhoneBookModel>();
            foreach (var item in phoneBook)
            {
                if (item.Isim.ToLower() == isim.ToLower() || item.Soyisim.ToLower() == soyisim.ToLower() || item.Telefon == telefon)
                    result.Add(item);
            }
            return result;
        }

    }
}