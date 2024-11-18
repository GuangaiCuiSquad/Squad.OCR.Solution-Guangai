using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squad.OCR.Solution
{
    public class QrCodeInfo
    {

        public string? A { get; set; } // NIF do emitente
        public string? B { get; set; } // NIF do adquirente
        public string? C { get; set; } // País do adquirente
        public string? D { get; set; } // Tipo de documento
        public string? E { get; set; } // Estado do documento
        public string? F { get; set; } // Data do documento
        public string? G { get; set; } // Identificação única do documento
        public string? H { get; set; } // ATCUD
        public string? I1 { get; set; } // Espaço fiscal (IVA)
        public string? I2 { get; set; } // Base tributável isenta de IVA
        public string? I3 { get; set; } // Base tributável de IVA à taxa reduzida
        public string? I4 { get; set; } // Total de IVA à taxa reduzida
        public string? I5 { get; set; } // Base tributável de IVA à taxa intermédia
        public string? I6 { get; set; } // Total de IVA à taxa intermédia
        public string? I7 { get; set; } // Base tributável de IVA à taxa normal
        public string? I8 { get; set; } // Total de IVA à taxa normal
        public string? I9 { get; set; }
        public string? I10 { get; set; }
        public string? I11 { get; set; }
        public string? I12 { get; set; }
        public string? J1 { get; set; } // Espaço fiscal (Settlement Amount)
        public string? J2 { get; set; } // Base tributável isenta de IVA (Settlement Amount)
        public string? J3 { get; set; } // Base tributável de IVA à taxa reduzida (Settlement Amount)
        public string? J4 { get; set; } // Total de IVA à taxa reduzida (Settlement Amount)
        public string? J5 { get; set; } // Base tributável de IVA à taxa intermédia (Settlement Amount)
        public string? J6 { get; set; } // Total de IVA à taxa intermédia (Settlement Amount)
        public string? J7 { get; set; } // Base tributável de IVA à taxa normal (Settlement Amount)
        public string? J8 { get; set; } // Total de IVA à taxa normal (Settlement Amount)
        public string? K1 { get; set; } // Espaço fiscal (Deductible Amount)
        public string? K2 { get; set; } // Base tributável isenta de IVA (Deductible Amount)
        public string? K3 { get; set; } // Base tributável de IVA à taxa reduzida (Deductible Amount)
        public string? K4 { get; set; } // Total de IVA à taxa reduzida (Deductible Amount)
        public string? K5 { get; set; } // Base tributável de IVA à taxa intermédia (Deductible Amount)
        public string? K6 { get; set; } // Total de IVA à taxa intermédia (Deductible Amount)
        public string? K7 { get; set; } // Base tributável de IVA à taxa normal (Deductible Amount)
        public string? K8 { get; set; } // Total de IVA à taxa normal (Deductible Amount)
        public string? L { get; set; } // Não sujeito / não tributável em IVA / outras situações
        public string? M { get; set; } // Imposto do Selo
        public string? N { get; set; } // Total de impostos
        public string? O { get; set; } // Total do documento com impostos
        public string? P { get; set; }   // Retenções na fonte
        public string? Q { get; set; } // 4 carateres do Hash
        public string? R { get; set; } // Nº do certificado
        public string? S { get; set; } // Outras informações
    }
}
