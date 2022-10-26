using PreEntregawAPI_lcruz.Models;
using System.Data;
using System.Data.SqlClient;

namespace PreEntregawAPI_lcruz.ADO
{
    public class ADO_Producto
    {
        public static List<Producto> TraeProductos()
        {
            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "LJ-PC";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM Producto";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var p = new Producto();

                    p.Id = Convert.ToInt32(reader2.GetValue(0));
                    p.Descripciones = reader2.GetValue(1).ToString();
                    p.Costo = Convert.ToInt32(reader2.GetValue(2));
                    p.PrecioVenta = Convert.ToInt32(reader2.GetValue(3));
                    p.Stock = Convert.ToInt32(reader2.GetValue(4));
                    p.IdUsuario = Convert.ToInt32(reader2.GetValue(5));

                    listaProductos.Add(p);

                }
                reader2.Close();
                connection.Close();

            }
            return listaProductos;
        }

        public static void AgregarProducto(Producto p)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "LJ-PC";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    " Values (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                var paramdes = new SqlParameter();
                paramdes.ParameterName = "Descripciones";
                paramdes.SqlDbType = SqlDbType.VarChar;
                paramdes.Value = p;

                var paramcos = new SqlParameter();
                paramcos.ParameterName = "Costo";
                paramcos.SqlDbType = SqlDbType.Money;
                paramcos.Value = p;

                var paramven = new SqlParameter();
                paramven.ParameterName = "PrecioVenta";
                paramven.SqlDbType = SqlDbType.Money;
                paramven.Value = p;

                var paramstock = new SqlParameter();
                paramstock.ParameterName = "Stock";
                paramstock.SqlDbType = SqlDbType.Int;
                paramstock.Value = p;

                var paramidUsu = new SqlParameter();
                paramidUsu.ParameterName = "IdUsuario";
                paramidUsu.SqlDbType = SqlDbType.BigInt;
                paramidUsu.Value = p;

                cmd.Parameters.Add(paramdes);
                cmd.Parameters.Add(paramcos);
                cmd.Parameters.Add(paramven);
                cmd.Parameters.Add(paramstock);
                cmd.Parameters.Add(paramidUsu);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void EliminarProducto(int id)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "LJ-PC";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Producto where id = @idpro";

                var param = new SqlParameter();
                param.ParameterName = "idpro";
                param.SqlDbType = SqlDbType.BigInt;
                param.Value = id;

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarProducto(Producto p)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "LJ-PC";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta =  @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario where Id = @idpro)";

                var paramid = new SqlParameter();
                paramid.ParameterName = "Idpro";
                paramid.SqlDbType = SqlDbType.BigInt;
                paramid.Value = p;

                var paramdes = new SqlParameter();
                paramdes.ParameterName = "Descripciones";
                paramdes.SqlDbType = SqlDbType.VarChar;
                paramdes.Value = p;

                var paramcos = new SqlParameter();
                paramcos.ParameterName = "Costo";
                paramcos.SqlDbType = SqlDbType.Money;
                paramcos.Value = p;

                var parampreven = new SqlParameter();
                parampreven.ParameterName = "PrecioVenta";
                parampreven.SqlDbType = SqlDbType.Money;
                parampreven.Value = p;

                var paramstock = new SqlParameter();
                paramstock.ParameterName = "Stock";
                paramstock.SqlDbType = SqlDbType.Int;
                paramstock.Value = p;

                var paramidUsu = new SqlParameter();
                paramidUsu.ParameterName = "IdUsuario";
                paramidUsu.SqlDbType = SqlDbType.BigInt;
                paramidUsu.Value = p;

                cmd.Parameters.Add(paramdes);
                cmd.Parameters.Add(paramcos);
                cmd.Parameters.Add(parampreven);
                cmd.Parameters.Add(paramstock);
                cmd.Parameters.Add(paramidUsu);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
