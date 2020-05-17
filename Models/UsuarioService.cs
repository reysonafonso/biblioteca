using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                u.Senha = encryption(u.Senha);
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.Login = u.Login;
                usuario.Nome = u.Nome;
                usuario.Telefone = u.Telefone;
                usuario.Senha = u.Senha;
                usuario.Perfil = u.Perfil;

                bc.SaveChanges();
            }
        }

        public ICollection<Usuario> ListarTodos(FiltrosUsuarios filtro = null)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                
                if(filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "Nome":
                            query = bc.Usuarios.Where(u => u.Nome.Contains(filtro.Filtro));
                        break;

                        case "1":
                            query = bc.Usuarios.Where(u => u.Perfil.Equals(Convert.ToInt32(filtro.Filtro)));
                        break;

                        case "2":
                            query = bc.Usuarios.Where(u => u.Perfil.Equals(Convert.ToInt32(filtro.Filtro)));
                        break;

                        default:
                            query = bc.Usuarios;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuarios;
                }

                return query.OrderByDescending(u => u.Nome).ToList();
            }
        }

        public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }


        public bool Login(string login, string senha)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Any(u => u.Login == login &&  u.Senha == senha);
            }
        }

        public string encryption(String password)  
        {  
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();  
            byte[] encrypt;  
            UTF8Encoding encode = new UTF8Encoding();  
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));  
            StringBuilder encryptdata = new StringBuilder();  
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)  
            {  
                encryptdata.Append(encrypt[i].ToString());  
            }  
            return encryptdata.ToString();  
        } 
    }
}