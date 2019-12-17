using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace video_store_library_system_
{
    class video
    {
        SqlConnection Connection_video = new SqlConnection(@"Data Source=LAPTOP-RAKIOMBV\SQLEXPRESS;Initial Catalog=VideoStore;Integrated Security=True");
        //this code connects the the databs

        SqlCommand cmd_video = new SqlCommand();


        SqlDataReader Read_video;

        String Query;

        public IEnumerable DefaultView { get; internal set; }

        internal object CustomerDG()
        {
            throw new NotImplementedException();
        }


        public DataTable DataCust()
        {//this code shows the data in data grida
            DataTable dt = new DataTable();
            try
            {
                cmd_video.Connection = Connection_video;
                Query = "Select * from Coustmer";//this query selects all row and coulum from coustomer

                cmd_video.CommandText = Query;
                Connection_video.Open();

                Read_video = cmd_video.ExecuteReader();

                if (Read_video.HasRows)
                {
                    dt.Load(Read_video);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (Read_video != null)
                {
                    Read_video.Close();
                }

                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }

        }



        public void Cust_Add(string FirstName, string LastName, string Address, string Phone)//this is to add to customer
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;



                Query = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";//this query add to coustomer


                cmd_video.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_video.Parameters.AddWithValue("@LastName", LastName);
                cmd_video.Parameters.AddWithValue("@Address", Address);
                cmd_video.Parameters.AddWithValue("@Phone", Phone);

                cmd_video.CommandText = Query;


                Connection_video.Open();


                cmd_video.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {

                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }
        }

        public void Cust_del(Int32 CustID)//this is to delete customer
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = this.Connection_video;


                String del = "";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                cmd_video.Parameters.Add(parameterArray[0]);

                cmd_video.CommandText = del;
                Connection_video.Open();

                del = "Delete from Coustmer where CustID like @CustID";
                cmd_video.CommandText = del;
                cmd_video.ExecuteNonQuery();
                MessageBox.Show("User Deleted");


            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Connection_video != null)
                {
                    this.Connection_video.Close();
                }
            }
        }



        public void Cust_up(int CustID, string FirstName, string LastName, string Address, string Phone)//this is to update customer
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;
                Query = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                cmd_video.Parameters.AddWithValue("@CustID", CustID);
                cmd_video.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_video.Parameters.AddWithValue("@LastName", LastName);
                cmd_video.Parameters.AddWithValue("@Address", Address);
                cmd_video.Parameters.AddWithValue("@Phone", Phone);

                cmd_video.CommandText = Query;


                Connection_video.Open();


                cmd_video.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {

                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }
        }

        public DataTable DataVid()
        {
            DataTable dt = new DataTable();//this loades the data in data grid
            try
            {
                cmd_video.Connection = Connection_video;
                Query = "Select * from Movies";

                cmd_video.CommandText = Query;

                Connection_video.Open();


                Read_video = cmd_video.ExecuteReader();

                if (Read_video.HasRows)
                {
                    dt.Load(Read_video);
                }
                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {

                if (Read_video != null)
                {
                    Read_video.Close();
                }


                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }

        }



        public void Vid_add(string Rateing, string Title, string Year, string RentalCost, string Plot, string Genre, int copies)//this is add video
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;



                Query = "Insert into Movies(Rateing, Title, Year, RentalCost, Plot, Genre, copies) Values( @Rateing, @Title, @Year, @RentalCost, @Plot, @Genre, @copies)";


                cmd_video.Parameters.AddWithValue("@Rateing", Rateing);
                cmd_video.Parameters.AddWithValue("@Title", Title);
                cmd_video.Parameters.AddWithValue("@Year", Year);
                cmd_video.Parameters.AddWithValue("@RentalCost", RentalCost);
                cmd_video.Parameters.AddWithValue("@Plot", Plot);
                cmd_video.Parameters.AddWithValue("@Genre", Genre);
                cmd_video.Parameters.AddWithValue("@copies", copies);

                cmd_video.CommandText = Query;


                Connection_video.Open();


                cmd_video.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {

                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }
        }

        public void Vid_del(int MovieID)//this is to delete vid
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = this.Connection_video;


                String del = "";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                cmd_video.Parameters.Add(parameterArray[0]);

                cmd_video.CommandText = del;
                Connection_video.Open();

                del = "Delete from Movies where MovieID like @MovieID";
                cmd_video.CommandText = del;
                cmd_video.ExecuteNonQuery();
                MessageBox.Show("Video Deleted");



            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Connection_video != null)
                {
                    this.Connection_video.Close();
                }

            }
        }



        public void Vid_up(int MovieID, string Rateing, string Title, int Year, string Plot, string Genre, int copies)//this is to update movie
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;
                Query = "Update Movies Set Rateing = @Rateing, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MovieID like @MovieID";


                cmd_video.Parameters.AddWithValue("@MovieID", MovieID);
                cmd_video.Parameters.AddWithValue("@Rateing", Rateing);
                cmd_video.Parameters.AddWithValue("@Title", Title);
                cmd_video.Parameters.AddWithValue("@Year", Year);
                cmd_video.Parameters.AddWithValue("@Plot", Plot);
                cmd_video.Parameters.AddWithValue("@Genre", Genre);
                cmd_video.Parameters.AddWithValue("@copies", copies);


                cmd_video.CommandText = Query;

                Connection_video.Open();


                cmd_video.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {

                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }
        }
        public DataTable Dataissue()
        {
            DataTable dt = new DataTable();//this loades the data to rented data grid
            try
            {
                cmd_video.Connection = Connection_video;
                Query = "Select * from RentedMovies";

                cmd_video.CommandText = Query;

                Connection_video.Open();


                Read_video = cmd_video.ExecuteReader();

                if (Read_video.HasRows)
                {
                    dt.Load(Read_video);
                }
                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {

                if (Read_video != null)
                {
                    Read_video.Close();
                }


                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }

        }



        public void issue_add(int MovieIDFK, int CustIDFK, DateTime DateRented, int copies)//this issue the movie
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;



                Query = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented) Values( @MovieIDFk, @CustIDFK, @DateRented)";

                cmd_video.Parameters.AddWithValue("@MovieIDFK", MovieIDFK);
                cmd_video.Parameters.AddWithValue("@CustIDFK", CustIDFK);
                cmd_video.Parameters.AddWithValue("@DateRented", DateRented);

                cmd_video.Parameters.AddWithValue("@copies", copies);


                cmd_video.CommandText = Query;

                Connection_video.Open();


                cmd_video.ExecuteNonQuery();

                Query = "Update Movies set copies = copies-1 where MovieID = @MovieIDFK";
                cmd_video.CommandText = Query;
                cmd_video.ExecuteNonQuery();



            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {

                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }
        }


        public void returned(int RMID, int MovieID, DateTime DateRent, DateTime DateReturned)//this retured the movie
        {
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;
                int money = 0, rent = 0;
                double days = (DateReturned - DateRent).TotalDays;

                string returned = "Select RentalCost from Movies where MovieID = @MovieIDFK";
                cmd_video.Parameters.AddWithValue("@MovieIDFK", MovieID);

                cmd_video.CommandText = returned;
                Connection_video.Open();
                rent = Convert.ToInt32(cmd_video.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    money = rent;
                }
                else
                {
                    money = rent * Convert.ToInt32(days);
                }


                Query = "Update RentedMovies Set DateReturned='" + DateReturned + "' where RMID = @RMID";
                cmd_video.Parameters.AddWithValue("@DateReurned", DateReturned);
                cmd_video.Parameters.AddWithValue("@RMID", RMID);

                cmd_video.CommandText = Query;

                cmd_video.ExecuteNonQuery();


                Query = "Update Movies set copies = copies+1 where MovieID = @MovieIDFK";
                this.cmd_video.CommandText = this.Query;

                this.cmd_video.ExecuteNonQuery();


                MessageBox.Show("Total Rent is " + money);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }


        }

        public void Cust_top()
        {
            int no1 = 0, high = 0, sum = 0;
            string top = "";
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;
                string Val = "Select IDENT_CURRENT('Coustmer')";

                cmd_video.CommandText = Val;
                Connection_video.Open();
                sum = Convert.ToInt32(cmd_video.ExecuteScalar());

                for (int k = 1; k <= sum; k++)
                {

                    top = "select Count(*) from RentedMovies where CustIDFK= '" + k + "'";


                    cmd_video.CommandText = top;
                    int count = Convert.ToInt32(cmd_video.ExecuteScalar());
                    if (count > high)
                    {
                        high = count;
                        no1 = k;
                    }
                }
                this.Query = "Select FirstName from Coustmer where CustID ='" + no1 + "'";
                this.cmd_video.CommandText = this.Query;
                String FirstName = Convert.ToString(cmd_video.ExecuteScalar());
                MessageBox.Show(FirstName + " (CustID " + no1 + " ) is the top coustomer ");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }

        }


        public void Vid_top()
        {
            int no1 = 0, high = 0, sum = 0;
            string top_vid = "";
            try
            {
                cmd_video.Parameters.Clear();
                cmd_video.Connection = Connection_video;
                string Val = "Select IDENT_CURRENT('Movies')";

                cmd_video.CommandText = Val;
                Connection_video.Open();
                sum = Convert.ToInt32(cmd_video.ExecuteScalar());

                for (int i = 1; i <= sum; i++)
                {

                    top_vid = "select Count(*) from RentedMovies where MovieIDFK= '" + i + "'";


                    cmd_video.CommandText = top_vid;
                    int count = Convert.ToInt32(cmd_video.ExecuteScalar());
                    if (count > high)
                    {
                        high = count;
                        no1 = i;
                    }
                }


                this.Query = "Select Title from Movies where MovieID ='" + no1 + "'";
                this.cmd_video.CommandText = this.Query;
                String Title = Convert.ToString(cmd_video.ExecuteScalar());
                MessageBox.Show(Title + " (MovieID " + no1 + " ) Is The top Movie");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (Connection_video != null)
                {
                    Connection_video.Close();
                }
            }

        }
    }
}
