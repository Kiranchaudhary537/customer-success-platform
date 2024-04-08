using Volo.Abp.Authorization.Permissions;

namespace Promact.CustomerSuccess.Platform.Permission
{
  public class Permission : PermissionDefinitionProvider
  {
    public override void Define(IPermissionDefinitionContext context)
    {
      //this is for test purpose
      var project = context.AddGroup("project");
      project.AddPermission("read:project");
      project.AddPermission("create:project");
      project.AddPermission("update:project");
      project.AddPermission("delete:project");
    }
  }
}
