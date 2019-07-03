using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SucursalWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWCFSucursal" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWCFSucursal
    {
        [OperationContract]
        Usuario GetUsuario(string usuario, string pass);
        [OperationContract]
        DataSet GetProducto(string prod);
        [OperationContract]
        DataSet GetCategoria();
        [OperationContract]
        int InsertarProdcuto(Producto prod);
        [OperationContract]
        int EditarProducto(Producto prod);
        [OperationContract]
        int ElimiarProdcuto(Producto prod);
        [OperationContract]
        int InsertarCategoria(Categoria cat);
        [OperationContract]
        int EditarCategoria(Categoria cat);
        [OperationContract]
        int ElimiarCategoria(Categoria cat);
        [OperationContract]
        int RegistrarUsuario(Usuario us);
        [OperationContract]
        DataSet GetSucursal();
        [OperationContract]
        DataSet MostrarProducto();
        [OperationContract]
        DataSet MostrarBitacora();

    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Sucursal : Mensaje
    {
        public int Id { get; set; }
        [DataMember]
        public string StrNombre { get; set; }
    }

    [DataContract]
    public class Usuario : Mensaje
    {
        public int Id { get; set; }
        [DataMember]
        public string StrUsuario { get; set; }
        [DataMember]
        public string StrPass { get; set; }
        [DataMember]
        public DateTime DteFechaRegistro { get; set; }
        [DataMember]
        public bool BitEstatus { get; set; }
        [DataMember]
        public int IdSucursal { get; set; }
    }

    [DataContract]
    public class Categoria : Mensaje
    {
        public int Id { get; set; }
        [DataMember]
        public string StrCategoria { get; set; }
        [DataMember]
        public bool BitEstatus { get; set; }
    }

    [DataContract]
    public class Producto : Mensaje

    {   [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StrProducto { get; set; }
        [DataMember]
        public int IdSucursal { get; set; }
        [DataMember]
        public int IntCantidad { get; set; }
        [DataMember]
        public bool BitEstatus { get; set; }
        [DataMember]
        public int IdCategoria { get; set; }
    }

    [DataContract]
    public class Accion : Mensaje
    {
        public int Id { get; set; }
        [DataMember]
        public string StrNombre { get; set; }
    }

    [DataContract]
    public class Mensaje
    {
        [DataMember]
        public string Mensajes { get; set; }

        [DataMember]
        public bool BanErrores { get; set; }

    }
}   
