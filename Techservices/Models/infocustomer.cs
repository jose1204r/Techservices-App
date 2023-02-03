namespace Techservices.Models
{     public  class infocustomer
    {
       
        public  int idcustomers { get; set; }

        public   string  name { get; set; }


        public    string  lastname { get; set; }

        public  string  address { get; set; }


        public   int phone { get; set; }

        public    DateTime servicedate { get; set; }

        public   string  device { get; set; }

        public   string comments { get; set; }



        public IEnumerable<Createcustomer> Clients { get; set; }






    }
}
