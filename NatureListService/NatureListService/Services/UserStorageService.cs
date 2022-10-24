using DevExpress.Xpo;
using NatureListService.Models;
using NatureListService.Models.Database;

namespace NatureListService.Services {
    public interface IUserStorageService {
        public abstract Task<IUser> GetUserAsync(LoginDTO loginDTO);
    }
    public static class XpoUserStorageExtensions {
        public static void AddXpoUserStorageService(this IServiceCollection services) {
            services.AddTransient<IUserStorageService, XpoUserStorageService>();
        }
    }
    public class XpoUserStorageService : IUserStorageService {
        readonly UnitOfWork uow;
        public XpoUserStorageService(UserDataModelUnitOfWork uow) {
            this.uow = uow;
        }
        public async Task<IUser> GetUserAsync(LoginDTO loginDTO) {
            XPQuery<User> getUserQuery = new XPQuery<User>(uow);
            User user = await getUserQuery
                .Where(u => u.Login == loginDTO.Login && u.Password == loginDTO.Password)
                .SingleOrDefaultAsync();
            return user;
        }
    }
    internal static class UserStorageInitializerExtension {
        public static IApplicationBuilder InitializeUserStorage(this IApplicationBuilder app) {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var uow = services.GetRequiredService<UserDataModelUnitOfWork>();
            UserStorageInitializer.Initialize(uow, false);
            return app;
        }
    }
    internal class UserStorageInitializer {
        internal static void Initialize(UnitOfWork uow, bool clearOldData) {
            XPQuery<User> getUsersQuery = new XPQuery<User>(uow);
            if(clearOldData)
                uow.Delete(getUsersQuery.ToArray());
            XPQuery<Role> getRolesQuery = new XPQuery<Role>(uow);
            if(clearOldData)
                uow.Delete(getRolesQuery.ToArray());
            uow.CommitChanges();
            List<Role> roles = getRolesQuery.ToList();
            if(!roles.Any()) {
                Role reader = new Role(uow) {
                    RoleName = "Reader"
                };
                Role writer = new Role(uow) {
                    RoleName = "Writer"
                };
                roles.AddRange(new[] {reader, writer});
            }
            if(!getUsersQuery.Any()) {
                User readerUser = new User(uow) {
                    Login = "Reader",
                    Password = "ReaderPassword",
                };
                readerUser.Roles.Add(roles.Single(r => r.RoleName == "Reader"));

                User writerUser = new User(uow) {
                    Login = "Writer",
                    Password = "WriterPassword",
                };
                writerUser.Roles.Add(roles.Single(r => r.RoleName == "Writer"));

                User adminUser = new User(uow) {
                    Login = "Admin",
                    Password = "AdminPassword",
                };
                adminUser.Roles.AddRange(roles);
                uow.CommitChanges();
            }

  
        }
    }
}
