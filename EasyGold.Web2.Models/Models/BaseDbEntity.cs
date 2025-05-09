namespace EasyGold.Web2.Models
{
    public abstract class BaseDbEntity
    {
        public DateTime rowcreated_at { get; set; }
        public DateTime? rowupdated_at { get; set; }
        public DateTime? rowdeleted_at { get; set; }
    }
}
