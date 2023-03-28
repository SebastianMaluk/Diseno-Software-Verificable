using System.ComponentModel.DataAnnotations;

namespace RealState.Models
{
    public class Cne
    {
        public int id { get; set; }
        public string? type { get; set; }

    }

    public enum Cnes
    {
        Compraventa,
        RegularizaciónDePatrimonio,
    }
}
