using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Recepcion : BaseEntity
    {

        #region Id by intities
        [Key]
        public int IdRecepcion {  get; set; }
        public int IdCliente { get; set; }
        public int IdHabitacion { get; set; }
        #endregion

        #region "Fechas"
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set;}
        public DateTime? FechaSalidaConfirmacion { get; set; }

        #endregion

        #region Costo y cotizaciones
        public decimal? PrecioInicial {  get; set; }
        public decimal? Adelanto {  get; set;}
        public decimal? PrecioRestante {  get; set;}
        public decimal? TotalPagado {  get; set;}
        public decimal? CostoPenalidad {  get; set;}
        public  string? Observacion { get; set;}

        #endregion


    }
}
