namespace NatureListService.Models {
    public interface IUser {
        public abstract string Login { get;}
        public abstract string Password { get;}
        public abstract IEnumerable<IRole> Roles { get;}
    }
    public interface IRole {
        public abstract string RoleName { get; set; }
    }
}
