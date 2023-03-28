using RealState.Models;

namespace RealState.ViewModels;

public class InscriptionViewModel
{
    public Inscription? Inscription { get; set; }
    public Cne? Cne { get; set; }
    public Localization? Localization { get; set; }
    
    public List<Enajenante>? Enajenantes { get; set; }

    public List<Adquiriente>? Adquirientes { get; set; }
}
