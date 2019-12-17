using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace video_store_library_system_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        video Obj_vid = new video();
      
        private void Loaded_cust(object sender, RoutedEventArgs e)
        {
            Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;//this loades the data grid of customer
        }

        private void loaded_movies(object sender, RoutedEventArgs e)
        {
            Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this loades the data grid of movies
        }

        private void loaded_rent(object sender, RoutedEventArgs e)
        {
            Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;//this loades the data grid of rent
        }

        private void rent_to_text(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Rented_data.SelectedItems[0];//this copies the rent data to text box
            rentmovie_text .Text = Convert.ToString(row["MovieIDFK"]);
            rentcust_text.Text = Convert.ToString(row["CustIDFK"]);
            Rent_text.Text = Convert.ToString(row["RMID"]);
            Dateissue_text.Text = Convert.ToString(row["DateRented"]);
            datereturned_text.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;

        }

        private void movies_to_text(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Movie_data.SelectedItems[0];//this copies the movie data to text box
            movies_text .Text = Convert.ToString(row["Title"]);
            plot_text.Text = Convert.ToString(row["Plot"]);
            genre_text.Text = Convert.ToString(row["Genre"]);
            year_text.Text = Convert.ToString(row["Year"]);
            rating_text.Text = Convert.ToString(row["Rateing"]);
            rentmovie_text.Text = Convert.ToString(row["MovieID"]);
            copies_text.Text = Convert.ToString(row["copies"]);

            Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;
        }

        private void cust_to_text(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Cust_data.SelectedItems[0];//this copies the customer data to text box
            rentcust_text.Text = Convert.ToString(row["CustID"]);
            firstname_text.Text = Convert.ToString(row["FirstName"]);
            lastname_text .Text = Convert.ToString(row["Lastname"]);
            address_text .Text = Convert.ToString(row["Address"]);
            phone_text .Text = Convert.ToString(row["Phone"]);

            Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;
        }

        private void Cust_addbtn_Click(object sender, RoutedEventArgs e)//this add the coustomer to database
        {
            if (firstname_text.Text != "" && lastname_text.Text != "" && address_text.Text != "" && phone_text.Text != "")
            {
                Obj_vid.Cust_Add(firstname_text.Text, lastname_text.Text, address_text.Text, phone_text.Text);

               

             
                rating_text.Text = "";
                movies_text.Text = "";
                year_text.Text = "";
                plot_text.Text = "";
                genre_text.Text = "";
                Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
                Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
                Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

                firstname_text.Text = "";//this code Resets the textbox
                lastname_text.Text = "";
                address_text.Text = "";
                phone_text.Text = "";
                Rent_text.Text = "";
                rentmovie_text.Text = "";
                rentcust_text.Text = "";
                copies_text.Text = "";

            }
            else
            {

                MessageBox.Show("fill all the customer text box");

            }
        }

        private void Cust_deletebtn_Click(object sender, RoutedEventArgs e)//this delete the customer form databse
        {
            int ID = Convert.ToInt32(rentcust_text.Text);
            Obj_vid.Cust_del(ID);


         

            rating_text.Text = "";
            movies_text.Text = "";
            year_text.Text = "";
            plot_text.Text = "";
            genre_text.Text = "";
            Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
            Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
            Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

            firstname_text.Text = "";//this code Resets the textbox
            lastname_text.Text = "";
            address_text.Text = "";
            phone_text.Text = "";
            Rent_text.Text = "";
            rentmovie_text.Text = "";
            rentcust_text.Text = "";
            copies_text.Text = "";

        }

        private void Cust_updatebtn_Click(object sender, RoutedEventArgs e)
        {
           
            int CustID = Convert.ToInt32(rentcust_text.Text);
            Obj_vid.Cust_up(CustID, firstname_text.Text, lastname_text.Text, address_text.Text, phone_text.Text);
           
            rating_text.Text = "";
            movies_text.Text = "";
            year_text.Text = "";
            plot_text.Text = "";
            genre_text.Text = "";
            Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
            Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
            Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

            firstname_text.Text = "";//this code Resets the textbox
            lastname_text.Text = "";
            address_text.Text = "";
            phone_text.Text = "";
            Rent_text.Text = "";
            rentmovie_text.Text = "";
            rentcust_text.Text = "";
            copies_text.Text = "";
        }

        private void Movie_addbtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (rating_text.Text != "" && movies_text.Text != "" && year_text.Text != "" && plot_text.Text != "" && genre_text.Text != "" && copies_text.Text != "")
            {
                int vid_year = Convert.ToInt32(year_text.Text);
                int copies = Convert.ToInt32(copies_text.Text);
                string rent;
                if (2019 - vid_year > 5)
                {
                    rent = "2";

                }
                else
                {
                    rent = "5";
                }

                Obj_vid.Vid_add(rating_text.Text, movies_text.Text, year_text.Text, rent, plot_text.Text, genre_text.Text, copies);

               

                rating_text.Text = "";
                movies_text.Text = "";
                year_text.Text = "";
                plot_text.Text = "";
                genre_text.Text = "";
                Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
                Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
                Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

                firstname_text.Text = "";//this code Resets the textbox
                lastname_text.Text = "";
                address_text.Text = "";
                phone_text.Text = "";
                Rent_text.Text = "";
                rentmovie_text.Text = "";
                rentcust_text.Text = "";
                copies_text.Text = "";

            }
            else
            {

                MessageBox.Show("fill all the text box in movie");

            }
        }

        private void Movie_deletebtn_Click(object sender, RoutedEventArgs e)//this is to delete movie
        {
            int movie = Convert.ToInt32(rentmovie_text.Text);
            Obj_vid.Vid_del(movie);

          
           
            rating_text.Text = "";
            movies_text.Text = "";
            year_text.Text = "";
            plot_text.Text = "";
            genre_text.Text = "";
            Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
            Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
            Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

            firstname_text.Text = "";//this code Resets the textbox
            lastname_text.Text = "";
            address_text.Text = "";
            phone_text.Text = "";
            Rent_text.Text = "";
            rentmovie_text.Text = "";
            rentcust_text.Text = "";
            copies_text.Text = "";
        }

        private void Movie_updatebtn_Click(object sender, RoutedEventArgs e)//this code updates the movie
        {
            int VidID = Convert.ToInt32(rentmovie_text.Text);
            int copies = Convert.ToInt32(copies_text.Text);


            
            int Year = Convert.ToInt32(year_text.Text);
            Obj_vid.Vid_up(VidID, rating_text.Text, movies_text.Text, Year, plot_text.Text, genre_text.Text, copies);

            
            rating_text.Text = "";
            movies_text.Text = "";
            year_text.Text = "";
            plot_text.Text = "";
            genre_text.Text = "";
            Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
            Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
            Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

            firstname_text.Text = "";//this code Resets the textbox
            lastname_text.Text = "";
            address_text.Text = "";
            phone_text.Text = "";
            Rent_text.Text = "";
            rentmovie_text.Text = "";
            rentcust_text.Text = "";
            copies_text.Text = "";
        }

        private void Issue_btn_Click(object sender, RoutedEventArgs e)//this is to issue movie
        {
            if (copies_text.Text != "0")

            {
                int Customerid = Convert.ToInt32(rentcust_text.Text);
                int vid_id = Convert.ToInt32(rentmovie_text.Text);
               
                Dateissue_text.Text = DateTime.Today.ToString("dd-MM-yyyy");
                int copies = Convert.ToInt32(copies_text.Text);
                
                Obj_vid.issue_add(vid_id, Customerid, DateTime.Now, copies);


             
                
                rating_text.Text = "";
                movies_text.Text = "";
                year_text.Text = "";
                plot_text.Text = "";
                genre_text.Text = "";
                Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
                Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
                Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

                firstname_text.Text = "";//this code Resets the textbox
                lastname_text.Text = "";
                address_text.Text = "";
                phone_text.Text = "";
                Rent_text.Text = "";
                rentmovie_text.Text = "";
                rentcust_text.Text = "";
                copies_text.Text = "";

            }


            else
            {
                MessageBox.Show("no more copies");
            }

        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)//this is to return movie
        {
            if (Rent_text.Text != "")
            {
                int RMID = Convert.ToInt32(Rent_text.Text);
                datereturned_text.Text = DateTime.Today.ToString("dd-MM-yyyy");
                int MovieID = Convert.ToInt32(rentmovie_text .Text);


                
                Obj_vid.returned(RMID, MovieID, Convert.ToDateTime(Dateissue_text.Text), DateTime.Now);
                
                rating_text.Text = "";
                movies_text.Text = "";
                year_text.Text = "";
                plot_text.Text = "";
                genre_text.Text = "";
                Movie_data.ItemsSource = Obj_vid.DataVid().DefaultView;//this code refresh the data gird
                Rented_data.ItemsSource = Obj_vid.Dataissue().DefaultView;
                Cust_data.ItemsSource = Obj_vid.DataCust().DefaultView;

                firstname_text.Text = "";//this code Resets the textbox
                lastname_text.Text = "";
                address_text.Text = "";
                phone_text.Text = "";
                Rent_text.Text = "";
                rentmovie_text.Text = "";
                rentcust_text.Text = "";
                copies_text.Text = "";
            }
            else
            {
                MessageBox.Show("First Select from rent");
            }
        }

        private void Topcust_btn_Click(object sender, RoutedEventArgs e)//this for th top cust
        {
            Obj_vid.Cust_top();
        }

        private void Topmovie_btn_Click(object sender, RoutedEventArgs e)//this is for the top movie

        {
            Obj_vid.Vid_top();
        }
    }
    
}
