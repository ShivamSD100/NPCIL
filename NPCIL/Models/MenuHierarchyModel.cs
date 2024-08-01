namespace NPCIL.Models
{
    public class MenuHierarchyModel
    {
        public int MenuSno { get; set; }
        public string MenuNameEng { get; set; }
        public int? ParentId { get; set; }
        public int MenuPosition { get; set; }
        public string FullPath { get; set; }
        public int Level { get; set; }
        public int Sequence { get; set; }
    }
}
