using System;
using Npgsql;
using System.Data;

namespace Tugas_PBO_out_dan_ref
{
    class Program
    {
        static void Main(string[] args)
        {
            bool dataStats;
            bool crudStats = false;
            getData getDT = new getData();
            crud crudoperation = new crud();

            if (getDT.ExecuteQuery(out dataStats) == true)
            {
                Console.WriteLine("Berhasil mengambil data pada database");
            }
            else if (getDT.ExecuteQuery(out dataStats) == false)
            {
                Console.WriteLine("Gagal mengambil data pada database");
            }
            if (crudoperation.insert(ref crudStats) == true)
            {
                Console.WriteLine("Berhasil menambahkan data buku baru");
            }
            else if (crudoperation.insert(ref crudStats) == false)
            {
                Console.WriteLine("Gagal menambahkan data buku baru");
            }
            if (crudoperation.update(ref crudStats) == true)
            {
                Console.WriteLine("Berhasil mengubah data pada database");
            }
            else if (crudoperation.update(ref crudStats) == false)
            {
                Console.WriteLine("Gagal mengubah data pada database");
            }
            if (crudoperation.delete(ref crudStats) == true)
            {
                Console.WriteLine("Berhasil menghapus data pada database");
            }
            else if (crudoperation.delete(ref crudStats) == false)
            {
                Console.WriteLine("Gagal menghapus data pada database");
            }
        }
    }

    class getData
    {
        private static NpgsqlConnection dbconnection()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=smp1kalidawer;database=DataBaseBuku;");
        }
        public bool ExecuteQuery(out bool info)
        {
            info = true;
            try
            {
                NpgsqlConnection con = dbconnection();
                con.Open();
                string sql = "select * from buku";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;
            }
            catch (Exception)
            {
                info = false;
                return info;
            }
        }
    }

    class crud
    {
        private static NpgsqlConnection dbconnection()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=smp1kalidawer;database=DataBaseBuku;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = dbconnection();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into buku(id_buku,nama,jumlah_halaman) values(2,'EVEN ANGELS ASK', 495)", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }

        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = dbconnection();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update buku set nama = BAHKAN MALAIKAT PUN BERTANYA, jumlah_halaman = 495 where id_buku = 2", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }

        public bool delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = dbconnection();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from buku where id_buku = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
    }
}