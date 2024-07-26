namespace thesis_exercise.model.DTOs
{
    public class CatalogsDTO
    {
        public IList<CatalogDTO> HardDisks { get; set; }
        public IList<CatalogDTO> Memories { get; set; }
        public IList<CatalogDTO> Processors { get; set; }
        public IList<CatalogDTO> UsbPorts { get; set; }
    }
}
