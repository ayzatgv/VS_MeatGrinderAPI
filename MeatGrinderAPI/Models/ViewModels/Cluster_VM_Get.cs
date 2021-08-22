namespace MeatGrinderAPI.Models.ViewModels
{
    public class Cluster_VM_Get
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string User_Username { get; set; }
        public Site Site { get; set; }

        public Cluster_VM_Get(Cluster cluster)
        {
            this.ID = cluster.ID;
            this.User_ID = cluster.User.ID;
            this.User_Username = cluster.User.Username;
            this.Site = cluster.Site;
        }
    }
}