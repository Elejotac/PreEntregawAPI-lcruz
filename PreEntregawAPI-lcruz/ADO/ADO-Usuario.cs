using PreEntregawAPI_lcruz.Models;
using System.Data.SqlClient;
using System.Data;

namespace PreEntregawAPI_lcruz.ADO
{
    public class ADO_Usuario
    {
        public static List<Usuario> TraeUsuarios()
        {
            var listaUsuarios = new List<Usuario>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "LJ-PC";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM usuario";
                var reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader2.GetValue(0));
                    usuario.Nombre = reader2.GetValue(1).ToString();
                    usuario.Apellido = reader2.GetValue(2).ToString();
                    usuario.NombreUsuario = reader2.GetValue(3).ToString();
                    usuario.Contraseña = reader2.GetValue(4).ToString();
                    usuario.Mail = reader2.GetValue(5).ToString();

                    listaUsuarios.Add(usuario);

                }
                reader2.Close();
                connection.Close();

            }
            return listaUsuarios;
        }

        public static void EliminarUsuario(int id)
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
                cmd.CommandText = "DELETE FROM usuario where id = @idusu";

                var p = new SqlParameter();
                p.ParameterName = "idusu";
                p.SqlDbType = SqlDbType.BigInt;
                p.Value = id;

                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void AgregarUsuario(Usuario usu)
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
                cmd.CommandText = "Insert into Usuario(Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail)" +
                    " Values (@idUsu, @nombreUsu, @apellidoUsu, @nombreUsuarioUsu, @contraseñaUsu, @mailUsu)";

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "idusu";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = usu;

                var parametroNombre = new SqlParameter();
                parametroNombre.ParameterName = "nombreUsu";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                parametroNombre.Value = usu;

                var parametroApe = new SqlParameter();
                parametroApe.ParameterName = "apellidoUsu";
                parametroApe.SqlDbType = SqlDbType.VarChar;
                parametroApe.Value = usu;

                var parametronomusu = new SqlParameter();
                parametronomusu.ParameterName = "nombreUsuarioUsu";
                parametronomusu.SqlDbType = SqlDbType.VarChar;
                parametronomusu.Value = usu;

                var parametrocontra = new SqlParameter();
                parametrocontra.ParameterName = "contraseñaUsu";
                parametrocontra.SqlDbType = SqlDbType.VarChar;
                parametrocontra.Value = usu;

                var parametromail = new SqlParameter();
                parametromail.ParameterName = "mailUsu";
                parametromail.SqlDbType = SqlDbType.VarChar;
                parametromail.Value = usu;

                cmd.Parameters.Add(parametroid);
                cmd.Parameters.Add(parametroNombre);
                cmd.Parameters.Add(parametroApe);
                cmd.Parameters.Add(parametronomusu);
                cmd.Parameters.Add(parametrocontra);
                cmd.Parameters.Add(parametromail);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ModificarUsuario(Usuario usu)
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
                cmd.CommandText = "UPDATE Usuario SET Nombre = @nombreUsu, Apellido = @apellidoUsu, NombreUsuario =  @nombreUsuarioUsu, Contraseña = @contraseñaUsu, Mail = @mailUsu where Id = @idusu";

                var parametroid = new SqlParameter();
                parametroid.ParameterName = "idusu";
                parametroid.SqlDbType = SqlDbType.BigInt;
                parametroid.Value = usu;

                var parametroNombre = new SqlParameter();
                parametroNombre.ParameterName = "nombreUsu";
                parametroNombre.SqlDbType = SqlDbType.VarChar;
                parametroNombre.Value = usu;

                var parametroApe = new SqlParameter();
                parametroApe.ParameterName = "apellidoUsu";
                parametroApe.SqlDbType = SqlDbType.VarChar;
                parametroApe.Value = usu;

                var parametronomusu = new SqlParameter();
                parametronomusu.ParameterName = "nombreUsuarioUsu";
                parametronomusu.SqlDbType = SqlDbType.VarChar;
                parametronomusu.Value = usu;

                var parametrocontra = new SqlParameter();
                parametrocontra.ParameterName = "contraseñaUsu";
                parametrocontra.SqlDbType = SqlDbType.VarChar;
                parametrocontra.Value = usu;

                var parametromail = new SqlParameter();
                parametromail.ParameterName = "mailUsu";
                parametromail.SqlDbType = SqlDbType.VarChar;
                parametromail.Value = usu;

                cmd.Parameters.Add(parametroid);
                cmd.Parameters.Add(parametroNombre);
                cmd.Parameters.Add(parametroApe);
                cmd.Parameters.Add(parametronomusu);
                cmd.Parameters.Add(parametrocontra);
                cmd.Parameters.Add(parametromail);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
