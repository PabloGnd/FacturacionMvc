namespace FacturacionMvc.Models
{
    public class VMUsuariosResult
    {
        public List<VMUsuarios> lstVMUsuarios { set; get; }
        public VMUsuarios dtoVMUsuarios { set; get; }
        public int Codigo { set; get; }

        public string Mensaje { set; get; }
    }
}
