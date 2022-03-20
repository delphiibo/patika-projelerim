namespace project2_todo_list
{
    
    class CartModel {
        
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public TeamUserModel AtananKisi { get; set; }
        public CartSize.Buyukluk Buyukluk { get; set; }

        public CartModel(string baslik,string icerik,TeamUserModel atananKisi,CartSize.Buyukluk buyukluk)
        {
            this.Baslik = baslik;
            this.Icerik = icerik;
            this.AtananKisi = atananKisi;
            this.Buyukluk = buyukluk;
        }
    }
}